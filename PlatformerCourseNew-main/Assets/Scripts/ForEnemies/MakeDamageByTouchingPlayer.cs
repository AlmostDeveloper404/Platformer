using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageByTouchingPlayer : MonoBehaviour
{
    [SerializeField] int DamageAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody!=null)
        {
            PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(DamageAmount);
            }

        }
    }
}
