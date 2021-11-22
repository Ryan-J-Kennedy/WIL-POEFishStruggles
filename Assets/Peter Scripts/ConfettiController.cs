using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiController : MonoBehaviour
{
    public ParticleSystem confetti;

    public void OnTriggerExit(Collider other) {
        //Thow confetti if player leaves trigger
        if(other.CompareTag("Player"))
            confetti.Play();
    }

}
