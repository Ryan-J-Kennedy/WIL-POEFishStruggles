using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMineController : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject chain, mine;

    public void OnTriggerEnter(Collider other) {
        chain.SetActive(false);
        mine.SetActive(false);

        explosion.Play();
        //Check what hits the mine and calls death methods
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().Death();
        }
        else if (other.CompareTag("Fish"))
        {
            other.GetComponent<Fish>().Death();
        }
    }

}
