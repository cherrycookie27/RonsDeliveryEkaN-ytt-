using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Move;
    private bool FacingRight = true;

    public float speed;
    private Animator anim;
    public float fallDamageThreshold = 2f;
    public PlayerHealth playerhealth;
    public int damage;

    [SerializeField] private AudioSource walkSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if ((Move > 0 && !FacingRight) || (Move < 0 && FacingRight))
        {
            Flip();
        }

        if (Move == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (rb.velocity.x != 0)
        {
            if (!walkSoundEffect.isPlaying)
            {
                walkSoundEffect.Play();
            }
        }
        else
        {
            walkSoundEffect.Stop();
        }

        if (rb.velocity.y < -fallDamageThreshold)
        {
            TakeFallDamage();
        }
    }

    // Function to flip the player sprite and update the facing direction
    void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void TakeFallDamage()
    {
        playerhealth.TakeDamage(damage);
    }
}
