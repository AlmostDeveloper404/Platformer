using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayManager : MonoBehaviour
{
    List<GameObject> hearts=new List<GameObject>();
    public GameObject heartPref;

    #region Singleton
    public static HealthDisplayManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More Than One HealthDisplayManager!");
            return;
        }
        instance = this;
    }

    #endregion


    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heartPrefGO= Instantiate(heartPref,transform);
            hearts.Add(heartPrefGO);
        }
    }

    public void DisplayHealth(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i<currentHealth);
        }
    }
}
