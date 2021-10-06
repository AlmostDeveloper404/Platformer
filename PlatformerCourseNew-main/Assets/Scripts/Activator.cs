using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Activator : MonoBehaviour
{
    
    
    Transform player;

    public List<GameObject> ObjectsToHide = new List<GameObject>();
    public float HideDistance=20f;


    private void Start()
    {
        player = PlayerHealth.instance.transform;
    }

    private void Update()
    {
        foreach (GameObject objectToHide in ObjectsToHide)
        {
            if (objectToHide!=null)
            {
                float DistanceToPlayer = Vector3.Distance(player.position,objectToHide.transform.position);
                objectToHide.SetActive(DistanceToPlayer<=HideDistance);

            }
        }
        
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (player==null)
        {
            return;
        }
        Handles.DrawWireDisc(player.position,Vector3.back,HideDistance);
    }
#endif
}
