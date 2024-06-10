using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected float life;
    [SerializeField] protected Transform[] points;
    [SerializeField] protected float speedPatrol;
    [SerializeField] protected float attackDamage;

    private Vector3 currentDestiny;
    private int currentIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentDestiny = points[currentIndex].position;
        StartCoroutine(Patrol());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            while (transform.position != currentDestiny)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentDestiny, speedPatrol * Time.deltaTime);
                yield return null;
            }
            DefineNewDestiny();
        }

    }

    protected void DefineNewDestiny()
    {
        currentIndex += 1;
        if (currentIndex >= points.Length)
        {
            currentIndex = 0;
        }
        currentDestiny = points[currentIndex].position;
        focusOnDestiny();
    }


    protected void focusOnDestiny()
    {
        if (currentDestiny.x > transform.position.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDetection"))
        {
            Debug.Log("Detectado!");
        }
        else
        {
            LifeSystem lifeSystemPlayer = collision.gameObject.GetComponent<LifeSystem>();
            SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            StartCoroutine(SwitchColor(spriteRenderer));
            lifeSystemPlayer.ReceiveDamage(attackDamage);
        }
    }

    IEnumerator SwitchColor(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(2);
        spriteRenderer.color = Color.white;
    }
}
