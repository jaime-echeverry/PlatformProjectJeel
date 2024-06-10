using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public PatrolState patrolState = new PatrolState();
    [HideInInspector]
    public AttackState attackState = new AttackState();
    [HideInInspector]
    public ChaseState chaseState = new ChaseState();

    State currentState;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null) { 
            currentState.OnUpdateState();
        }
    }

    public void ChangeState(State newState) {
        if (currentState != null) {
            currentState.OnExitState();
        }
        currentState = newState;
        currentState.OnEnterState(this);
    }
}
