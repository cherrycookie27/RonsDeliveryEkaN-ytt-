using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float speed = 10f;

    private bool isFacingRight = true;

    void Update()
    {
        // Move the bullet in the appropriate direction
        if (isFacingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    // Function to set the direction the player is facing
    public void SetFacingDirection(bool facingRight)
    {
        isFacingRight = facingRight;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Map"))
        {
            Destroy(gameObject);
        }
    }
}
