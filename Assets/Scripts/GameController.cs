using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int foodAmount = 0;
    public int foodNeeded = 10;
    public Transform dayImage;
    public Text foodText;
    public GameObject dialouge;
    public GameObject deathPanel;
    public Text deathFact;
    Story story;
    public bool inOcean = false;
    bool dialougeStarted = false;
    bool dialougeSaid = false;

    public Current[] currents;

    string[] facts = { "Today, each person eats on average 19.2kg of fish a year – around twice as much as 50 years ago ", "In 2013 around 93 million tonnes of fish were caught world-wide", "About 38.5 million tonnes of bycatch results from current preferred fishing practice each year", "Over just 40 years there has been a decrease recorded in marine species of 39%" };

    // Start is called before the first frame update
    void Start()
    {
        story = GameObject.Find("Story").GetComponent<Story>();
    }

    public void Death()
    {
        deathPanel.SetActive(true);
        deathFact.text = facts[Random.Range(0, facts.Length)];
    }

    public void TurnOnDialouge()
    {
        dialouge.SetActive(true);
    }

    private void Update()
    {
        if (inOcean)
        {
            if (foodAmount == 0 && dialougeStarted)
            {
                story.SetDialouge("There isn’t enough food on the Coastline. Swim deeper");
                dialougeStarted = true;
            }
            else if (foodAmount == 4)
                story.SetDialouge("The Reef is out of shrimp, you need to go to the Abyss…");
            else if (foodAmount == foodNeeded && !dialougeSaid)
            {
                story.SetDialouge("You’ve grown full over your long life, return to Tutorial River to start your own family");
                dialougeSaid = true;

                foreach (Current current in currents)
                {
                    current.strength = 0;
                    current.additive = false;
                }
            }
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("River");
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        dayImage.Rotate(new Vector3(0f, 0f, 0.1f));
        foodText.text = "Food: " + foodAmount + "/" + foodNeeded;

    }
}
