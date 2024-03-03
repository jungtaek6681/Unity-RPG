using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cinemachine;

    private void OnEnable()
    {
        if (cinemachine != null)
        {
            cinemachine.gameObject.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        if (cinemachine != null)
        {
            cinemachine.gameObject.SetActive(false);
        }
    }
}
