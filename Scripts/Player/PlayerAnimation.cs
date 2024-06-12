using UnityEngine;

public static class PlayerAnimationData
{
    public static class Params
    {
        public static readonly int Walk = Animator.StringToHash("isWalk");
        public static readonly int Jump = Animator.StringToHash("isJump");
        public static readonly int Attack = Animator.StringToHash("isAttack");
    }
}

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
 
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetWalk(bool isWalking)
    {
        _animator.SetBool(PlayerAnimationData.Params.Walk, isWalking);
    }

    public void SetJump(bool isJumping)
    {
        _animator.SetBool(PlayerAnimationData.Params.Jump, isJumping);
    }
}
