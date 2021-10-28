using UnityEngine;

public class Rocket : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] float Speed;
    [SerializeField] float lerpSpeed;

    private void Start()
    {
        playerTransform = PlayerHealth.instance.transform;      
    }

    private void Update()
    {
        Vector3 rocketPos = transform.position;
        rocketPos += Time.deltaTime*transform.forward*Speed;
        rocketPos.z = 0;
        transform.position = rocketPos;
        Vector3 dir = playerTransform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir ,-Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*lerpSpeed);
    }
}
