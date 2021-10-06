using UnityEngine;

public class Carrot : MonoBehaviour
{
    Transform playerTransform;
    Rigidbody _rigidbody;
    [SerializeField] float speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        playerTransform = FindObjectOfType<PlayerHealth>().transform;
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = dir * speed;
    }
}
