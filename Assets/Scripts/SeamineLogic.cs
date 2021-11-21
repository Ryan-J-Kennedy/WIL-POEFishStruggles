using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamineLogic : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject seaMine, chain;

    public void OnTriggerEnter(Collider other) {
        seaMine.SetActive(false);
        chain.SetActive(false);
        explosion.Play();
    }
}
