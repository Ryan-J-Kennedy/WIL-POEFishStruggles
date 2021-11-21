using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiController : MonoBehaviour
{
    public ParticleSystem confetti;

    public void OnTriggerExit(Collider other) {

        if(other.CompareTag("Player"))
            confetti.Play();
    }

}
