using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    public GameObject PrefabToCreate;

    public void Create()
    {
        Instantiate(PrefabToCreate,transform.position,transform.rotation);
    }
}
