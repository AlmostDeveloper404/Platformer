using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void DisplayScreen()
    {
        StartCoroutine(ShowDamageEffect());
    }


    IEnumerator ShowDamageEffect()
    {
        image.enabled = true;
        for (float t = 1f; t > 0; t-=Time.deltaTime)
        {

            image.color = new Color(1,0,0,t);
            yield return null;
        }
        image.enabled = false;
    }

}
