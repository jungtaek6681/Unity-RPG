using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] bool debug;

    [SerializeField] LayerMask layerMask;
    [SerializeField] float range;

    Collider[] colliders = new Collider[20];
    private void Interact()
    {
        int size = Physics.OverlapSphereNonAlloc(transform.position, range, colliders, layerMask);
        for (int i = 0; i < size; i++)
        {
            IInteractable interactable = colliders[i].GetComponent<IInteractable>();
            interactable?.Interact(this);
        }
    }

    private void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (debug == false)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
