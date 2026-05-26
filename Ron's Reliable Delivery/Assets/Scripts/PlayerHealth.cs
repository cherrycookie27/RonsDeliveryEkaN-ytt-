using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;

    public float deathDelay = 1f;
    public int health;
    public int maxHealth = 3;

    void Start()
    {
        health = maxHealth;  
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 1)
        {
            anim.SetTrigger("IsDead");

            Invoke("LoseScreen", deathDelay);
        }
    }

    private void LoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }
}
