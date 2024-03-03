using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] Transform viewPoint;
    [SerializeField] LayerMask targetLayerMask;
    [SerializeField] LayerMask obstacleLayerMask;
    [SerializeField] float range;
    [SerializeField, Range(0, 360)] float angle;

    private float preAngle;
    private float cosAngle;
    private float CosAngle
    {
        get
        {
            if (preAngle == angle)
                return cosAngle;

            preAngle = angle;
            cosAngle = Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad);
            return cosAngle;
        }
    }

    private void Update()
    {
        FindTarget();
    }

    Collider[] colliders = new Collider[20];
    private void FindTarget()
    {
        int size = Physics.OverlapSphereNonAlloc(viewPoint.position, range, colliders, targetLayerMask);
        for (int i = 0; i < size; i++)
        {
            Vector3 dirToTarget = (colliders[i].transform.position - viewPoint.position).normalized;

            if (Vector3.Dot(viewPoint.forward, dirToTarget) < CosAngle)
                continue;

            float distToTarget = Vector3.Distance(colliders[i].transform.position, viewPoint.position);
            if (Physics.Raycast(viewPoint.position, dirToTarget, distToTarget, obstacleLayerMask))
                continue;

            Debug.DrawRay(viewPoint.position, dirToTarget * distToTarget, Color.red);
            return;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(viewPoint.position, range);

        Vector3 rightDir = Quaternion.Euler(0, angle * 0.5f, 0) * viewPoint.forward;
        Vector3 leftDir = Quaternion.Euler(0, angle * -0.5f, 0) * viewPoint.forward;

        Debug.DrawRay(viewPoint.position, rightDir * range, Color.cyan);
        Debug.DrawRay(viewPoint.position, leftDir * range, Color.cyan);
    }
}
