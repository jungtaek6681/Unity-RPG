using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Weapon weapon;

    private void StartAttack()
    {
        weapon.EnableAttack();
    }

    private void EndAttack()
    {
        weapon.DisableAttack();
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Attack();
        }
    }
}
