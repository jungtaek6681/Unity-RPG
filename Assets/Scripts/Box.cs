using UnityEngine;

public class Box : MonoBehaviour
{
    public void GetItem(PlayerInteractor playerInteractor)
    {
        Debug.Log($"Interact with {playerInteractor.name} and Get item");
    }

    public void Break()
    {
        Destroy(gameObject);
    }
}
