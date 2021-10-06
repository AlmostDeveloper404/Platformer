using UnityEngine;

public class JumpGun : MonoBehaviour
{
    Rigidbody playerRB;
    public Transform FirePoint;
    public float Force;
    public Gun GunScript;

    public float GunReloading;
    bool isReadyToUse = true;

    public JumpGunDisplay jumpGunDisplay;

    float _timer;

    private void Start()
    {

        playerRB = GetComponentInParent<Rigidbody>();
    }
    private void Update()
    {
        if (isReadyToUse)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isReadyToUse = false;
                UseJumpGun();
            }
        }
        else
        {           
                Reload();            
        }
    }

    void UseJumpGun()
    {
        playerRB.AddForce(-FirePoint.forward * Force, ForceMode.VelocityChange);
        _timer = GunReloading;
    }

    void Reload()
    {

        _timer -= Time.unscaledDeltaTime;
        jumpGunDisplay.DisplayReload(_timer,GunReloading);
        if (_timer < 0f)
        {
            jumpGunDisplay.StopDisplay();
            isReadyToUse = true;
        }
    }
}
