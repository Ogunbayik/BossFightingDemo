using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAnimationController : MonoBehaviour
{
    public static event Action OnAttackComplete;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetMoveAnimation(bool isMoving)
    {
        animator.SetBool(Consts.EnemyAnimationParameters.IS_MOVE_PARAMETER, isMoving);
    }
    private void OnEnable()
    {
        OnAttackComplete += EnemyAnimationController_OnAttackComplete;
    }
    private void OnDisable()
    {
        OnAttackComplete -= EnemyAnimationController_OnAttackComplete;
    }
    private void EnemyAnimationController_OnAttackComplete()
    {
        ResetAttackAnimation();
    }

    public void AttackAnimation()
    {
        animator.SetBool(Consts.EnemyAnimationParameters.IS_ATTACK_PARAMETER, true);
    }
    public void ResetAttackAnimation()
    {
        animator.SetBool(Consts.EnemyAnimationParameters.IS_ATTACK_PARAMETER, false);
    }

    public void AttackAnimationComplete()
    {
        OnAttackComplete?.Invoke();
    }
}
