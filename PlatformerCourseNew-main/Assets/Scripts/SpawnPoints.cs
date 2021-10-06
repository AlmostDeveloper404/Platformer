using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public Transform[] points;
    public Transform Acorn;

    private void Start()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    public void CreateAcorns()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Instantiate(Acorn,points[i].position,points[i].rotation);
        }
    }
}
