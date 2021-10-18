using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] float Speed;
    [SerializeField] float lerpSpeed;

    private void Start()
    {
        playerTransform = PlayerHealth.instance.transform;
        
    }

    private void Update()
    {
        transform.position += Time.deltaTime*transform.forward*Speed;
        Vector3 dir = playerTransform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir ,-Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*lerpSpeed);
    }
}
