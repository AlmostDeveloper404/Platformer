using UnityEngine;

public class Aim : MonoBehaviour
{

    public Transform target;
    public float slerpSpeed;
    public float desiredAngle = 60f;

    public Transform PlayerTransform;

    public PlayerMovement playerMovement;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        GunRotation();
        PlayerRotation();
    }

    private void LateUpdate()
    {
        Crosshair();
    }

    void Crosshair()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);

        Vector3 collisionPoint = ray.GetPoint(distance);
        target.position = collisionPoint;

    }

    void GunRotation()
    {
        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    void PlayerRotation()
    {
        if (playerMovement.isGrounded)
        {
            if (target.position.x > PlayerTransform.position.x)
            {
                Quaternion desiredPos = Quaternion.Euler(0f, -desiredAngle, 0f);
                PlayerTransform.rotation = Quaternion.Slerp(PlayerTransform.rotation, desiredPos, slerpSpeed * Time.deltaTime);
            }
            else if (target.position.x < PlayerTransform.position.x)
            {
                Quaternion desiredPos = Quaternion.Euler(0f, desiredAngle, 0f);
                PlayerTransform.rotation = Quaternion.Slerp(PlayerTransform.rotation, desiredPos, slerpSpeed * Time.deltaTime);
            }

        }
        
    }




}
