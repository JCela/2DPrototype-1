using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    
	private Vector3 moveDirection = Vector3.zero;
    private CharacterController cc;
	public SpriteRenderer playerSprite;
	//private Rigidbody2D rb;

	public Transform startDash;
	public Transform endDash;
	
	private float speed = 10f;
	private float jumpSpeed = 8.0f;
	private float gravity = 20.0f;
	private float dashLength;
	private float dashStartTime;
	private bool isGrounded = false;

	private float dashTimer = 0f;

	void Start () {
		cc = GetComponent<CharacterController>();
		//rb = GetComponent<Rigidbody2D>();
		dashStartTime = Time.time;
		dashStartTime  = Vector3.Distance(startDash.position, endDash.position);
	}
	
	void Update()
	{
		dashTimer -= 1f;
		if (this.tag == "Player1") {
			
			float translationP1 = Input.GetAxis("JoyP1") * speed;
			moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
			this.cc.Move(moveDirection * Time.deltaTime);
			
			
			if (translationP1 < 0)
			{
				StartCoroutine(PlayerMoveLeftCoroutine());

			}
			if (translationP1 > 0)
			{
				StartCoroutine(PlayerMoveRightCoroutine());
			}
			if (cc.isGrounded)
			{
				if (Input.GetButton("JumpP1"))
				{
					this.moveDirection.y = jumpSpeed;
				}
				else
				{
					this.moveDirection.y = 0;
				}

				if (Input.GetButton("DashP1") && dashTimer < 0f)
				{
					StartCoroutine(PlayerDashCoroutine());
				}
				
			}

		}
		if (this.tag == "Player2")
		{
			
			float translationP2 = Input.GetAxis("JoyP2") * speed;
			moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
			this.cc.Move(moveDirection * Time.deltaTime);
			
			if (translationP2 < 0)
			{
				StartCoroutine(PlayerMoveLeftCoroutine());

			}
			if (translationP2 > 0)
			{
				StartCoroutine(PlayerMoveRightCoroutine());
			}
			if (cc.isGrounded)
			{
				if (Input.GetButton("JumpP2"))
				{
					this.moveDirection.y = jumpSpeed;
				}
				else
				{
					this.moveDirection.y = 0;
				}
				
			}
			if (Input.GetButton("DashP2"))
			{
				StartCoroutine(PlayerDashCoroutine());
			}
		}
	}
	IEnumerator PlayerDashCoroutine()
	{
		float distCovered = (dashStartTime * speed+ 20);

		// Fraction of journey completed = current distance divided by total distance.
		float fracJourney = distCovered / dashLength;

		// Set our position as a fraction of the distance between the markers.
		transform.position = Vector3.Lerp(startDash.position, endDash.position, fracJourney);
		dashTimer = 200f;
		yield return 60;
		yield break;
		;
	}
	IEnumerator PlayerMoveLeftCoroutine()
	{
		
		//this.cc.Move(transform.right * -speed *Time.deltaTime);
		this.playerSprite.flipX = true;
		yield break;
	}
	IEnumerator PlayerMoveRightCoroutine()
	{
		
		//this.cc.Move(transform.right * speed *Time.deltaTime);
		this.playerSprite.flipX = false;
		yield break;
	}
}
