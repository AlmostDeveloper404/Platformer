using UnityEngine;

    public enum RopeState 
    { 
        Fly,
        Active,
        Disable
    }
public class Rope : MonoBehaviour
{
    [SerializeField]private Transform Spawn;
    [SerializeField]private float Speed = 15f;

    [SerializeField] Hook hook;

    SpringJoint springJoint;

    public RopeState CurrentRopeState;

    public Transform RopeStart;

    float _length;
    [SerializeField] float ropeMaxLength;

    public LineRendererCreation LineRendererCreation;
    public PlayerMovement PlayerMovement;




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shot();
        }
        if (CurrentRopeState==RopeState.Fly)
        {
            float distance= Vector3.Distance(RopeStart.position, hook.transform.position);
            if (distance > ropeMaxLength)
            {
                hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disable;
                LineRendererCreation.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentRopeState==RopeState.Active)
            {
                if (!PlayerMovement.isGrounded)
                {
                    PlayerMovement.Jump();

                }
            }
            DestroyRope();
        }

        if (CurrentRopeState==RopeState.Fly || CurrentRopeState==RopeState.Active)
        {
            LineRendererCreation.Draw(RopeStart.position,hook.transform.position,_length);
        }
    }

    void Shot()
    {
        _length = 1f;

        if (springJoint)
        {
            Destroy(springJoint);
        }
        hook.gameObject.SetActive(true);

        hook.StopConnection();
        hook.transform.position = Spawn.position;
        hook.transform.rotation = Spawn.rotation;
        hook.Rigidbody.velocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
    }

    public void CreateRope()
    {
        if (!springJoint)
        {
            springJoint= gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = hook.Rigidbody;
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.anchor = RopeStart.localPosition;
            springJoint.connectedAnchor = Vector3.zero;
            springJoint.spring = 100f;
            springJoint.damper = 5f;

            _length = Vector3.Distance(RopeStart.position,hook.transform.position);
            springJoint.maxDistance = _length/1.5f;

            CurrentRopeState = RopeState.Active;
        }
    }

    public void DestroyRope()
    {
        if (springJoint)
        {
            Destroy(springJoint);
            hook.gameObject.SetActive(false);
            CurrentRopeState = RopeState.Disable;
            LineRendererCreation.Hide();
        }
    }
}
