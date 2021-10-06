using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    [SerializeField]float lerpSpeed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,target.position,Time.deltaTime*lerpSpeed);
    }
}
