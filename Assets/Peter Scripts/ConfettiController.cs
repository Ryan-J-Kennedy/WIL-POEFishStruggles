using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiController : MonoBehaviour
{
    public ParticleSystem confetti;

    public void OnTriggerEnter(Collider other) {

        confetti.Play();
    }

}
