using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float health;
    private float damage;
    private Animator anim;
    private Rigidbody2D rb;

    private float distance;
    private bool isHit = false;
    [SerializeField] AudioSource dyingsound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isHit)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if (distance < 22)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                anim.SetBool("IsWalking", true);
            }

            if (distance > 22)
            {
                anim.SetBool("IsWalking", false);
            }
        }

        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            anim.SetTrigger("IsDead");
            isHit = true;
            dyingsound.Play();

            Destroy(gameObject, 1f);
        }
    }
}
