using UnityEngine;

public class AttackEveryNSecond : MonoBehaviour
{
    SetAnimationTrigger setAnimTrigger;

    float timer;
    public float FireRate = 4f;

    private void Start()
    {
        setAnimTrigger = GetComponentInChildren<SetAnimationTrigger>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>FireRate)
        {
            timer = 0;
            setAnimTrigger.PlayAttackAnim();
        }
    }

    
}
