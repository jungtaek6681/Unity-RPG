using System.Collections;
using UnityEngine;

public class SoundGenerator : MonoBehaviour
{
    [SerializeField] LayerMask targetLayerMask;
    [SerializeField] float range;
    [SerializeField] float repeatTime;

    private void OnEnable()
    {
        generateRoutine = StartCoroutine(GenerateRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(generateRoutine);
    }

    Coroutine generateRoutine;
    IEnumerator GenerateRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(repeatTime);
            GenerateSound();
        }
    }

    Collider[] colliders = new Collider[20];
    public void GenerateSound()
    {
        int size = Physics.OverlapSphereNonAlloc(transform.position, range, colliders, targetLayerMask);
        for (int i = 0; i < size; i++)
        {
            IListenable listenable = colliders[i].GetComponent<IListenable>();
            listenable?.Listen(transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
