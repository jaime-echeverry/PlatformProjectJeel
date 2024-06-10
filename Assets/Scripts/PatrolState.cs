using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float patrolSpeed;
    private Transform destiny;

    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
        StartCoroutine(PatrolSiteToSite());
    }
    public override void OnUpdateState()
    {

        myController.ChangeState(myController.chaseState); 
    }
    public override void OnExitState()
    {
        StopAllCoroutines();
    }

    private IEnumerator PatrolSiteToSite() {
        destiny = pointA;
        while (true) {
            while (transform.position != destiny.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, destiny.position, patrolSpeed * Time.deltaTime);
                yield return null;
            }

            if (destiny == pointA)
            {
                destiny = pointB;
            }
            else {
                destiny = pointA;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myController.ChangeState(myController.chaseState);
        }
    }

}
