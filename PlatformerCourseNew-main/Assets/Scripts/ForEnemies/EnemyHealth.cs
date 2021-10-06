using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health=1;

    public UnityEvent EventOnTakeDamage;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
        else
        {
            EventOnTakeDamage.Invoke();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
