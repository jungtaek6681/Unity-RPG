using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterController controller;
    [SerializeField] float moveSpeed;

    private Vector3 moveDir;
    private float ySpeed;

    private void Update()
    {
        Move();
        Fall();
    }

    private void Move()
    {
        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }

    private void Fall()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (controller.isGrounded && ySpeed < 0)
        {
            ySpeed = 0;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;

        animator.SetBool("Move", input.sqrMagnitude > 0);
    }
}
