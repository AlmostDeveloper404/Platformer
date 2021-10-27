using UnityEngine;

public class Hen : MonoBehaviour
{
    Rigidbody _rigidbody;
    Transform player;

    public float Speed=3f;
    public float AccelerationTime=1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 dir = (player.position - _rigidbody.position).normalized;
        Vector3 force = _rigidbody.mass * (Speed*dir- _rigidbody.velocity) / AccelerationTime;

        _rigidbody.AddForce(force);
    }

    
}
