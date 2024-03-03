using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterController controller;
    [SerializeField] float moveSpeed;

    private Vector3 moveInput;
    private float ySpeed;

    private void Update()
    {
        Move();
        Fall();
    }

    private void Move()
    {
        Vector3 forwardDir = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        Vector3 rightDir = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized;

        Debug.DrawRay(transform.position, forwardDir, Color.blue);
        Debug.DrawRay(transform.position, rightDir, Color.green);

        controller.Move(forwardDir * moveInput.z * moveSpeed * Time.deltaTime);
        controller.Move(rightDir * moveInput.x * moveSpeed * Time.deltaTime);

        if (moveInput.sqrMagnitude > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(forwardDir * moveInput.z + rightDir * moveInput.x);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 10f * Time.deltaTime);
        }
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
        moveInput.x = input.x;
        moveInput.z = input.y;

        animator.SetBool("Move", input.sqrMagnitude > 0);
    }
}
