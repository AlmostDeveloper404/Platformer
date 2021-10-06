using UnityEngine;
using UnityEngine.UI;

public class JumpGunDisplay : MonoBehaviour
{
    public Text ReloadText;
    public Image ReloadImage;
    public Image LoadImage;

    private void Start()
    {
        StopDisplay();
    }

    public void DisplayReload(float timer,float reloadingTime)
    {
        ReloadText.enabled = true;
        ReloadImage.enabled = true;
        LoadImage.color = new Color(0.4254445f, 0.007843141f, 0.5647059f,0.5f);
        ReloadImage.fillAmount = timer / reloadingTime;
        ReloadText.text = Mathf.Ceil(timer).ToString();
    }

    public void StopDisplay()
    {
        ReloadText.enabled = false;
        ReloadImage.enabled = false;
        LoadImage.color = new Color(0.4254445f, 0.007843141f, 0.5647059f, 1f);
    }
}
