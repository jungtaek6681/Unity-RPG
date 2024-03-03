using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] Transform follow;
    [SerializeField] float distance;
    [SerializeField] float speed;
    [SerializeField] float yOffset;

    private float xRotation;
    private float yRotation;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate()
    {
        yRotation = Mathf.Clamp(yRotation, 10f, 80f);

        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
        transform.position = follow.position - distance * transform.forward + Vector3.up * yOffset;
    }

    private void OnLook(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        xRotation += input.x * speed;
        yRotation -= input.y * speed;
    }
}
