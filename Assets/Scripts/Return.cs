using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    GameController gc;
    Story story;
    bool returning = false;

    private void Start()
    {
        story = GameObject.Find("Story").GetComponent<Story>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (returning)
            {
                story.StartTutoria3();
                gc.inOcean = true;
            }
            else
            {
                returning = true;
            }
        }
    }
}
