using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blick : MonoBehaviour
{
   

    public Renderer[] renderers;

    public void DisplayBlick()
    {
        StartCoroutine(BlickDisplay());
    }

    IEnumerator BlickDisplay()
    {
        for (float t = 0f; t < 1f; t+=Time.deltaTime)
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                for (int r = 0; r < renderers[i].materials.Length; r++)
                {
                    renderers[i].materials[r].SetColor("_EmissionColor",new Color(Mathf.Sin(t*30)*0.5f+0.5f ,0f,0f,0f));

                }
            }
           
            yield return null;
        }
    }
}
