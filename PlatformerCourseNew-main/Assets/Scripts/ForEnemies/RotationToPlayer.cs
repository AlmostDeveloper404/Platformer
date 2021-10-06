using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToPlayer : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] float lertSpeed=4f;
    [SerializeField] float angleToRotateRight = -160f;
    [SerializeField] float angleToRotateLeft = -20f;

    private void Start()
    {
        playerHealth = PlayerHealth.instance;
    }

    private void Update()
    {
        if (playerHealth.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, angleToRotateRight, 0f), lertSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, angleToRotateLeft, 0f), lertSpeed * Time.deltaTime);
        }

    }
}
