using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    Rigidbody _rigidBody;
    [SerializeField] Vector3 Force;
    [SerializeField] float MaxRotation;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.AddRelativeForce(Force,ForceMode.VelocityChange);
        _rigidBody.angularVelocity = new Vector3(
            Random.Range(-MaxRotation,MaxRotation), 
            Random.Range(-MaxRotation, MaxRotation), 
            Random.Range(-MaxRotation, MaxRotation)
            );
        
    }

    
}
