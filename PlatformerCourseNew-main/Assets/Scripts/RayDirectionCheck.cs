using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDirectionCheck : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        Gizmos.DrawRay(ray);
    }
}
