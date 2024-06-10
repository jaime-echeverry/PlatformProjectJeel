using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;
    [Header("Movement System")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform feets;
    [SerializeField] private float  floorRayCastDetection;
    [SerializeField] private LayerMask whatCanBeJumped;

    [Header("Combat System")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask damageHitbox;
    [SerializeField] private float damage;
    [SerializeField] private GameObject explosion;


    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        Jump();

        LaunchAttack();
    }

    private void LaunchAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
    }

    private void Attack() {
        Collider2D[] touchedColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, damageHitbox);
        foreach (Collider2D item in touchedColliders)
        {
            var instantiatedExplosion = Instantiate(explosion, attackPoint.position, Quaternion.identity);
            Destroy(instantiatedExplosion,0.3f);
            LifeSystem lifeSystemEnemy = item.gameObject.GetComponent<LifeSystem>();
            lifeSystemEnemy.ReceiveDamage(damage);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsOnFloor())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }

    private bool playerIsOnFloor() {
        return Physics2D.Raycast(feets.position, Vector3.down, floorRayCastDetection, whatCanBeJumped);
    }

    private void Movement()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputH * movementSpeed, rb.velocity.y);

        if (inputH != 0)
        {
            animator.SetBool("running", true);
            if (inputH > 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            animator.SetBool("running", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("void"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else if (collision.CompareTag("Fireball")) {
            Debug.Log("FIREEE");
        }
    }

}
