using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float defaultDeltaTime;

    private void Start()
    {
        defaultDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            
            Time.timeScale = 0.2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = defaultDeltaTime * Time.timeScale;
        
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = defaultDeltaTime;
    }
}
