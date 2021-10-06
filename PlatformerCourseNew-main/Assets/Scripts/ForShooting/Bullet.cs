using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitAreaObjects;

    private void Start()
    {
        Destroy(gameObject,4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject EffectGO= Instantiate(HitAreaObjects,transform.position,Quaternion.identity);
        Destroy(EffectGO,2f);

        DestroyBullet();
    }

    public void DestroyBullet()
    {

        Destroy(gameObject);
    }
}
