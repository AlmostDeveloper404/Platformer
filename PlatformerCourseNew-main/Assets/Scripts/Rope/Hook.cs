using UnityEngine;

public class Hook : MonoBehaviour
{
    FixedJoint fixedJoint;

    public Rigidbody Rigidbody;

    public Collider Collider;
    public Collider PlayerCollider;

    public Rope Rope;


    private void Start()
    {
        Physics.IgnoreCollision(Collider,PlayerCollider);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!fixedJoint)
        {
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
            {
                fixedJoint.connectedBody = collision.rigidbody;
            }
            Rope.CreateRope();
        }
    }
    

    public void StopConnection()
    {
        if (fixedJoint)
        {
            Destroy(fixedJoint);
        }
    }
}
