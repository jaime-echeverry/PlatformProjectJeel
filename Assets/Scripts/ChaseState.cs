using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField]
    private float speedChase;

    private Transform target;

    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
        target = FindObjectOfType<Player>().transform;
    }

    public override void OnUpdateState()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speedChase * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) > 0.5f) {
            myController.ChangeState(myController.attackState);
        }
    }


    public override void OnExitState()
    {
        throw new System.NotImplementedException();
    }

 
}
