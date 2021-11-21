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
    }

}
