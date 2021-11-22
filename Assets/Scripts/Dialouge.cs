using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialouge : MonoBehaviour
{
    public string dialouge;

    GameController gc;
    Story story;
    bool passed = false;

    private void Start()
    {
        story = GameObject.Find("Story").GetComponent<Story>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (passed == false)
            {
                story.StartTutorial2();
                gc.inOcean = true;
                passed = true;
            }
        }
    }
}
