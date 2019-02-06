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
	public Transform top_left_gc;
	private float gcRadius = 0.2f;
	
	void Start ()
	{
		sr = gameObject.GetComponent<SpriteRenderer>();
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		jumpBuffer -= 1;
		isGrounded = Physics2D.OverlapCircle(top_left_gc.position, gcRadius , ground_layers);
	
		if (this.tag == "Player1")
		{
			
			float translationP1 = Input.GetAxis("JoyP1") * speed;
			if (translationP1 < 0 || Input.GetKey(KeyCode.A))
			{
				StartCoroutine(PlayerMoveLeftCoroutine());

			}
			if (translationP1 > 0 || Input.GetKey(KeyCode.D))
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
