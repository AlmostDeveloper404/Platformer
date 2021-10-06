using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    EnemyHealth enemyHealth;
    public int Damage;
    public bool DieOnAnyColission;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Bullet>())
        {
            enemyHealth.TakeDamage(Damage);
        }
        if (DieOnAnyColission)
        {
            enemyHealth.TakeDamage(100);
        }
        
    }

}
