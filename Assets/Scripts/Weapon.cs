using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] new Collider collider;
    [SerializeField] LayerMask layerMask;
    [SerializeField] int damage;

    public void EnableAttack()
    {
        collider.enabled = true;
    }

    public void DisableAttack()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (layerMask.Contain(other.gameObject.layer))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            damagable?.TakeDamage(damage);
        }
    }
}
