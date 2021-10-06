using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPref;
    public Transform FirePoint;
    public float Speed;
    public float FireRate;
    public GameObject FlashEffect;

    public AudioSource ShotSound;

    [SerializeField]float _timer;

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer>=FireRate)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }

        }
    }

    public virtual void Shoot()
    {
        _timer = 0;

        GameObject bulletGO = Instantiate(BulletPref, FirePoint.position, FirePoint.rotation);
        bulletGO.GetComponent<Rigidbody>().velocity = transform.forward * Speed;
        Destroy(bulletGO, 2f);

        FlashEffect.SetActive(true);
        Invoke("DisableFlash",.1f);

        ShotSound.volume = Random.Range(0.1f,0.25f);
        ShotSound.pitch = Random.Range(0.7f,1.2f);
        ShotSound.Play();
    }

    void DisableFlash()
    {
        FlashEffect.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int amountToAdd)
    {

    }
}
