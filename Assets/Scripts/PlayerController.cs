using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	private Animator anim;
	private CharacterController controller;

	private float moveY;

	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float jumpSpeed;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController>();
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		Move();
		Rotate();
		Jump();
	}

	private void Move()
	{
		Vector3 fowardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
		Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;

		Vector3 moveInput = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
		if (moveInput.sqrMagnitude > 1f) moveInput.Normalize();

		anim.SetFloat("XInput", Input.GetAxis("Horizontal"));
		anim.SetFloat("YInput", Input.GetAxis("Vertical"));

		Vector3 moveVec = fowardVec * moveInput.z + rightVec * moveInput.x;

		controller.Move(moveVec * moveSpeed * Time.deltaTime);

		anim.SetFloat("MoveSpeed", moveSpeed);
	}

	private void Rotate()
	{
		transform.forward = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
	}

	private void Jump()
	{
		moveY += Physics.gravity.y * Time.deltaTime;

		if (Input.GetButtonDown("Jump"))
		{
			moveY = jumpSpeed;
		}
		else if (controller.isGrounded && moveY < 0)
		{
			moveY = 0;
		}

		controller.Move(Vector3.up * moveY * Time.deltaTime);
	}
}
