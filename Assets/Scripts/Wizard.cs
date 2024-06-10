using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float attackTime;
    [SerializeField] private float damageAttack;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AttackRoutine() {
        while (true)
        {
            animator.SetTrigger("atacar");
            yield return new WaitForSeconds(attackTime);
        }
    }

    private void LauchBall() {
        Instantiate(fireBall, spawnPoint.position, transform.rotation);

    }
}
