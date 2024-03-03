using UnityEngine;
using UnityEngine.Events;

public class InteractAdapter : MonoBehaviour, IInteractable
{
    public UnityEvent<PlayerInteractor> OnInteracted;

    public void Interact(PlayerInteractor interactor)
    {
        OnInteracted?.Invoke(interactor);
    }
}
