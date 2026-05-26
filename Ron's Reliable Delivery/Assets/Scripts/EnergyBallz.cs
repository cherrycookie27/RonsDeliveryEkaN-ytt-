using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallz : MonoBehaviour
{

    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //collectSound.Play();

            EnergyBar energyBar = FindObjectOfType<EnergyBar>();
            EnergyBar timer = energyBar;

            if (timer != null)
            {
                timer.CollectibleCollected();
            }

            Destroy(gameObject);
        }
    }
}
