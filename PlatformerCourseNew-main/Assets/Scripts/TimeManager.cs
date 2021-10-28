using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float defaultDeltaTime;

    public UnityEvent OnTimeStopEvent;
    public UnityEvent OnTimeBackEvent;

    public Slider TimeSlider;
    public GameObject SliderPanal;

    bool isFreezed = false;

    float MaxFreezeTime = 3f;
    [SerializeField]float _timer;

    private void Start()
    {
        SliderPanal.SetActive(false);
        _timer = MaxFreezeTime;
        defaultDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        TimeSlider.value = _timer / MaxFreezeTime;
        if (Input.GetMouseButton(1) && _timer>0f)
        {
            FreezeTime();
        }
        else
        {
            
            RevertTime();
        }
        Time.fixedDeltaTime = defaultDeltaTime * Time.timeScale;
        
    }

    public void FreezeTime()
    {
        _timer -= Time.unscaledDeltaTime/2;
        if (_timer<0.2f)
        {
            return;
        }
        if (_timer > 0)
        {            
            if (!isFreezed)
            {
                OnTimeStopEvent.Invoke();
                isFreezed = true;
                SliderPanal.SetActive(true);
            }
        }
        else
        {
            RevertTime();
        }
        Time.timeScale = 0.2f;
    }

    public void RevertTime()
    {
        
        if (_timer < MaxFreezeTime)
        {
            _timer += Time.deltaTime;
            if (_timer > MaxFreezeTime)
            {
                _timer = MaxFreezeTime;
                SliderPanal.SetActive(false);
            }
        }

        if (isFreezed)
        {
            OnTimeBackEvent.Invoke();
            isFreezed = false;
        }
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = defaultDeltaTime;
    }
}
