using UnityEngine;

public class Boots : MonoBehaviour
{
    Animator animator;
    public Transform playerBodyTransform;
    public Rigidbody playerRigidBody;

    public Transform BootsTarget;

    float maxPlayerSpeed;

    private void Awake()
    {
        maxPlayerSpeed = playerRigidBody.GetComponent<PlayerMovement>().MaxSpeed;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float dot = Vector3.Dot(-playerBodyTransform.forward,playerRigidBody.velocity);

        float sign = Mathf.Sign(dot);

        transform.position = BootsTarget.position;

        float _playerSpeed =sign* Mathf.Abs(playerRigidBody.velocity.x) / maxPlayerSpeed;
        animator.SetFloat("Speed",_playerSpeed);
    }
}
