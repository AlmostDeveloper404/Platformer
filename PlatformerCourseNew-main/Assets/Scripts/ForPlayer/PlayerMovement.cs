using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody _rigidbody;

    [SerializeField]float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float friction;
    [SerializeField]float availableSurfaceAngleForJump = 45f;
    [SerializeField] float scaleRate;

    public Transform CeilingCheckPoint;

    public Transform capsule;

    public float MaxSpeed;

    [SerializeField]bool isGrounded = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (Input.GetButton("Crouch") || !isGrounded)
        {
            
            capsule.localScale = Vector3.Lerp( capsule.localScale,new Vector3(1f,0.5f,1f),Time.deltaTime*scaleRate);
        }
        else
        {
            if (isCeilingAbove())
            {
                return;
            }
            capsule.localScale = Vector3.Lerp(capsule.localScale, new Vector3(1f,1f,1f), Time.deltaTime * scaleRate);
        }
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float speedMultiplier = 1f;

        if (!isGrounded)
        {
            speedMultiplier = 0.2f;
            if (_rigidbody.velocity.x > MaxSpeed && horizontal > 0)
            {
                speedMultiplier = 0f;
            }
            if (_rigidbody.velocity.x < -MaxSpeed && horizontal < 0)
            {
                speedMultiplier = 0f;
            }
        }

        

        _rigidbody.AddForce(horizontal * moveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);

        if (isGrounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }
    void Jump()
    {
        _rigidbody.AddForce(0f, jumpForce, 0f, ForceMode.VelocityChange);
    }

    bool isCeilingAbove()
    {
        Ray ray = new Ray(CeilingCheckPoint.position,Vector3.up);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,out hitInfo,1f))
        {
            return true;
        }
        return false;
    }
    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angleToSurfaceNormal = Vector3.Angle(collision.contacts[i].normal,Vector3.up);
            if (angleToSurfaceNormal < availableSurfaceAngleForJump)
            {
                isGrounded = true;
            }

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
