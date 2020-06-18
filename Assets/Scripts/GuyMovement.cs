using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
	//Config parameters
	[Header("Movement values")]
	[SerializeField] float moveSpeed;

	//Cache
	Rigidbody2D rb;
	Animator animator;
	Vector2 movement;

	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}


	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("horizontal", movement.x);
		animator.SetFloat("vertical", movement.y);
		animator.SetFloat("speed", movement.sqrMagnitude); //magnitude?
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
