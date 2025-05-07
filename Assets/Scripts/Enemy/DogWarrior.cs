using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWarrior : EnemyBase
{
    private void OnEnable()
    {
        EnemyAnimationController.OnAttackComplete += EnemyAnimationController_OnAttackComplete;
    }
    private void OnDisable()
    {
        EnemyAnimationController.OnAttackComplete -= EnemyAnimationController_OnAttackComplete;
    }
    private void EnemyAnimationController_OnAttackComplete()
    {
        if (GetPlayerDistance() >= enemySO.GetAttackDistance())
            SetEnemyState(EnemyStates.Chasing);
    }

    public override void HandleAttackState()
    {
        animationController.AttackAnimation();
    }
}
