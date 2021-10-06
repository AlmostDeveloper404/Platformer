using UnityEngine;

public class TakeDamageByTrigger : MonoBehaviour
{
    EnemyHealth enemyHealth;
    [SerializeField] int DamageAmount=1;
    [SerializeField] bool DieOnAnyTrigger;


    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet)
        {
            bullet.DestroyBullet();
            enemyHealth.TakeDamage(DamageAmount);
        }
        if (DieOnAnyTrigger)
        {
            enemyHealth.TakeDamage(100);
        }
    }
}
