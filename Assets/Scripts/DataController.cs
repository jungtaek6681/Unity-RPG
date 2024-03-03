using UnityEngine;

public class DataController : MonoBehaviour
{
    [ContextMenu("Save")]
    public void Save()
    {
        Debug.Log("Save");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        Debug.Log("Load");
    }
}
