using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private float speed = 50f;
	private bool isGrounded;
	private float jumpBuffer = 10;
	public LayerMask ground_layers;
	public Transform top_left_gc; //this is badly named sorry guys, it is the ground check that needs to be assigned in the inspector
	private float gcRadius = 0.2f;

	private static int currentMat;
	
	void Start ()
	{
		sr = gameObject.GetComponent<SpriteRenderer>();
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		currentMat = MaterialGrabber.material;  //Once integration is complete.
		//currentMat = 1;
		jumpBuffer -= 1;
		isGrounded = Physics2D.OverlapCircle(top_left_gc.position, gcRadius , ground_layers);
	
		if (this.tag == "Player1")
		{
			if (currentMat == 0)
			{
				this.rb.gravityScale = 10;
				Debug.Log("STEEL");
			}
			else if(currentMat == 1){
				Debug.Log("ICE");
				this.rb.gravityScale = 2;
				//this.rb.linearDr
				rb.drag = 0;
			}
			else if(currentMat == 2){
				Debug.Log("WOOD");
				this.rb.gravityScale = 2;
			}
			else if(currentMat == 3){
				Debug.Log("COPPER");
				this.rb.gravityScale = 7;
			}
				
			float translationP1 = Input.GetAxis("JoyP1") * speed;
			if ((translationP1 < 0 || Input.GetKey(KeyCode.A)) && currentMat != 0)
			{
				StartCoroutine(PlayerMoveLeftCoroutine());

			}
			if ((translationP1 > 0 || Input.GetKey(KeyCode.D)) && currentMat != 0)
			{
				StartCoroutine(PlayerMoveRightCoroutine());
			}
			if (isGrounded == true && jumpBuffer < 0)
			{
				if (Input.GetButton("JumpP1"))
				{
					StartCoroutine(PlayerMoveUpCoroutine());
					isGrounded = false;
					jumpBuffer = 10;
				}
			}

		}

		//if (this.tag == "Player2")
		//{
		//	float translationP2 = Input.GetAxis("JoyP2") * speed;
		//	if (translationP2 < 0 || Input.GetKey(KeyCode.J))
		//	{
		//		StartCoroutine(PlayerMoveLeftCoroutine());
//
		//	}
		//	if (translationP2 > 0 || Input.GetKey(KeyCode.L))
		//	{
		//		StartCoroutine(PlayerMoveRightCoroutine());
		//	}
		//	if (isGrounded == true && jumpBuffer < 0)
		//	{
		//		if (Input.GetButton("JumpP2"))
		//		{
		//			StartCoroutine(PlayerMoveUpCoroutine());
		//			isGrounded = false;
		//			jumpBuffer = 10;
		//		}
		//	}
		//}
	}

	IEnumerator PlayerMoveLeftCoroutine()
	{
		rb.AddForce(transform.right * -speed);
		yield break;
	}
	IEnumerator PlayerMoveRightCoroutine()
	{
		rb.AddForce(transform.right* speed);
		yield break;
	}
	IEnumerator PlayerMoveUpCoroutine()
	{
		rb.AddForce(transform.up* speed*20);
		yield break;
	}
	
}
