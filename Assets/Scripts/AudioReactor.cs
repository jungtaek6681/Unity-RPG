using UnityEngine;

public class AudioReactor : MonoBehaviour, IListenable
{
    public void Listen(Vector3 sourcePos)
    {
        Debug.DrawLine(transform.position, sourcePos, Color.blue, 0.5f);
    }
}
