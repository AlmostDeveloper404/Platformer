using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionWithPlayer : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody!=null)
        {
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(damage);
            }

        }
    }
}
