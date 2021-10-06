using UnityEngine;

public class RotateToTargerEuler : MonoBehaviour
{
    public Vector3 LeftEuler;
    public Vector3 RightEuler;

    Vector3 _targetEuler;

    [SerializeField] float rotationSpeed;

    private void Start()
    {
        _targetEuler = LeftEuler;
    }

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler),Time.deltaTime*rotationSpeed);
    }

    public void RotateRight()
    {
        _targetEuler = RightEuler;
    }

    public void RotateLeft()
    {
        _targetEuler = LeftEuler;
    }
}
