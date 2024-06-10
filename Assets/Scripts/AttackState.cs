using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float timeToAttack;
    [SerializeField] private float damageAttack;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
    }

    public override void OnUpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void OnExitState()
    {
        throw new System.NotImplementedException();
    }

   

}
