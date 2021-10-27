using UnityEngine;

public class HealLoot : MonoBehaviour
{
    [SerializeField] int health;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.AddHealth(health);
            Destroy(gameObject);
        }
    }
}
