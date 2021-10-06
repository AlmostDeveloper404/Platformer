using UnityEngine;

public class SetAnimationTrigger : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Pref;
    Animator animator;

    public string AnimationName = "Attack";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAttackAnim()
    {
        animator.SetTrigger(AnimationName);
    }
    public void Attack()
    {
        Instantiate(Pref,FirePoint.position,FirePoint.rotation);
    }
}
