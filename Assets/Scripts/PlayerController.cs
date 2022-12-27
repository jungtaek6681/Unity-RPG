using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState { Normal, Battle }

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	private Animator anim;
	private CharacterController controller;

	private PlayerState state;
	private float moveY;

	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float jumpSpeed;

	[SerializeField]
	private WeaponHolder weaponHolder;
	[SerializeField]
	private float attackRange;
	[SerializeField, Range(0f, 360f)]
	private float attackAngle;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController>();
	}

	private void Start()
	{
		state = PlayerState.Normal;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		switch (state)
		{
			case PlayerState.Normal:
				Move();
				Rotate();
				Jump();
				ChangeForm();
				break;
			case PlayerState.Battle:
				Move();
				Rotate();
				Jump();
				Attack();
				ChangeForm();
				break;
		}
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

	private void Attack()
	{
		if (!Input.GetButtonDown("Fire1"))
			return;

		anim.SetTrigger("Attack");
		Invoke("OnAttackHit", 0.4f);
	}

	public void OnAttackStart()
	{
		Debug.Log("공격 시작");
		//weaponHolder.StartAttack();
	}

	public void OnAttackHit()
	{
		Debug.Log("공격 타이밍");

		// 1. 범위내에 있는가
		Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
		for(int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject.name != "Cube")
				continue;

			Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;

			// 2. 각도내에 있는가
			if (Vector3.Dot(transform.forward, dirToTarget) < Mathf.Cos(attackAngle * 0.5f * Mathf.Deg2Rad))
				continue;

			Destroy(colliders[i].gameObject);
		}
	}

	public void OnAttackEnd()
	{
		Debug.Log("공격 끝");
		//weaponHolder.EndAttack();
	}

	private void ChangeForm()
	{
		if (!Input.GetButtonDown("Fire2"))
			return;

		if (state == PlayerState.Normal)
		{
			state = PlayerState.Battle;
			weaponHolder.ShowWeapon();
			anim.SetTrigger("ChangeForm");
			anim.SetLayerWeight(1, 1);
		}
		else if (state == PlayerState.Battle)
		{
			state = PlayerState.Normal;
			weaponHolder.HideWeapon();
			anim.SetTrigger("ChangeForm");
			anim.SetLayerWeight(1, 0);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);

		Vector3 rightDir = AngleToDir(transform.eulerAngles.y + attackAngle * 0.5f);
		Vector3 leftDir = AngleToDir(transform.eulerAngles.y - attackAngle * 0.5f);
		Debug.DrawRay(transform.position, rightDir * attackRange, Color.blue);
		Debug.DrawRay(transform.position, leftDir * attackRange, Color.blue);
	}

	private Vector3 AngleToDir(float angle)
	{
		float radian = angle * Mathf.Deg2Rad;
		return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
	}
}
