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

	void Start ()
	{
		sr = gameObject.GetComponent<SpriteRenderer>();
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		jumpBuffer -= 1;
		Ray groundCheckRay = new Ray(this.transform.position, this.transform.up*-1);
		float groundCheckRayLength = 0.43f;
		Debug.DrawRay(groundCheckRay.origin, groundCheckRay.direction * groundCheckRayLength, Color.yellow);
		if (Physics.Raycast(groundCheckRay, groundCheckRayLength))
		{
			isGrounded = true;
		}
		if (this.tag == "Player1")
		{
			
			float translationP1 = Input.GetAxis("JoyP1") * speed;
			if (translationP1 < 0)
			{
				StartCoroutine(PlayerMoveLeftCoroutine());

			}
			if (translationP1 > 0)
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

		if (this.tag == "Player2")
		{
			float translationP2 = Input.GetAxis("JoyP2") * speed;
			if (translationP2 < 0)
			{
				StartCoroutine(PlayerMoveLeftCoroutine());

			}
			if (translationP2 > 0)
			{
				StartCoroutine(PlayerMoveRightCoroutine());
			}
			if (isGrounded == true && jumpBuffer < 0)
			{
				if (Input.GetButton("JumpP2"))
				{
					StartCoroutine(PlayerMoveUpCoroutine());
					isGrounded = false;
					jumpBuffer = 10;
				}
			}
		}
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
