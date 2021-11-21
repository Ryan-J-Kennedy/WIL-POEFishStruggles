using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorConfetti : MonoBehaviour
{
    public ParticleSystem confetti;

    public void OnTriggerEnter(Collider other) {

        confetti.Play();
    }
}
