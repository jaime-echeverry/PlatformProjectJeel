using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("PlayerDetection"))
        {
            StartCoroutine(ChasePlayer(collision));
        }
       
    }

    IEnumerator ChasePlayer(Collider2D collision)
    {
        while (true)
        {
            while (transform.position != collision.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, collision.transform.position, speedPatrol * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }

}
