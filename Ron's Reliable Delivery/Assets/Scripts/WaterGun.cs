using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject dropletPrefab;
    [SerializeField] AudioSource watersound;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(dropletPrefab, shootingPoint.position, transform.rotation);
            watersound.Play();
        }
    }
}
