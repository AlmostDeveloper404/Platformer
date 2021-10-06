using UnityEngine;
using UnityEngine.Events;

public class Patrolling : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    public Transform Left;
    public Transform Right;

    public float Speed;

    public float StopTime;

    public Direction CurrentDirection;

    private bool isStopped = false;

    public UnityEvent RightTurn;
    public UnityEvent LeftTurn;

    public Transform RaycastPoint;

    private void Start()
    {
        Left.parent = null;
        Right.parent = null;
    }
    private void Update()
    {
        if (isStopped==true)
        {
            return;
        }
        if (CurrentDirection==Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime*Speed,0f,0f);
            if (transform.position.x<Left.position.x)
            {
                CurrentDirection = Direction.Right;
                isStopped = true;
                Invoke("StartWalking",StopTime);
                RightTurn.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x > Right.position.x)
            {
                CurrentDirection = Direction.Left;
                isStopped = true;
                Invoke("StartWalking", StopTime);

                LeftTurn.Invoke();
            }
        }

        RaycastHit rayInfo;
        if(Physics.Raycast(RaycastPoint.position,Vector3.down,out rayInfo))
        {
            transform.position = rayInfo.point;

        }

    }

    void StartWalking()
    {
        isStopped = false;
    }

}
