using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject dialouge;
    public Text dialougeText;

    public GameObject EndGame;
    public Text endGameText;

    public GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tutorial());
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void SetDialouge(string _dialouge)
    {
        StartCoroutine(dialougeTime(_dialouge));
    }

    public void StartTutorial2()
    {
        StartCoroutine(Tutorial2());
    }

    public void StartTutoria3()
    {
        StartCoroutine(Tutorial3());
    }

    IEnumerator dialougeTime(string _dialouge)
    {
        dialouge.SetActive(true);
        dialougeText.text = _dialouge;

        yield return new WaitForSeconds(7);

        dialouge.SetActive(false);
    }

    IEnumerator Tutorial()
    {
        dialouge.SetActive(true);
        dialougeText.text = "You hatch from your egg and find yourself in Tutorial River";

        yield return new WaitForSeconds(6);

        dialougeText.text = "Alternate between A and D to propel yourself forward";

        yield return new WaitForSeconds(8);

        dialougeText.text = "Press W to move upwards";

        yield return new WaitForSeconds(5);

        dialougeText.text = "Press S to move downwards";

        yield return new WaitForSeconds(5);

        dialougeText.text = "Swim down the river to the ocean. Adventure awaits!";

        yield return new WaitForSeconds(8);

        dialouge.SetActive(false);
    }

    IEnumerator Tutorial2()
    {
        dialouge.SetActive(true);
        dialougeText.text = "Lookout for shrimp blowing bubbles. Eat them to grow";

        yield return new WaitForSeconds(7);

        dialougeText.text = "Watch out for fishing hooks. They will catch your brothers and sisters";

        yield return new WaitForSeconds(7);

        dialougeText.text = "If you are caught, you die";

        yield return new WaitForSeconds(5);

        dialouge.SetActive(false);
    }

    IEnumerator Tutorial3()
    {
        EndGame.SetActive(true);
        int numEggs = 350 * gc.foodAmount;
        endGameText.text = "You return home and lay " + numEggs + " eggs";

        yield return new WaitForSeconds(6);

        endGameText.text = "Only " + numEggs * 0.2 + " hatch";

        yield return new WaitForSeconds(8);

        endGameText.text = "Due to a variety of factors such as pollution, overfishing and the ocean’s temperature rising, only " + 350 * gc.foodAmount * 0.02 + " of your eggs will live to adulthood";

        yield return new WaitForSeconds(8);

        endGameText.text = "While you were playing our game, roughly " + Time.realtimeSinceStartup * 5000000 + " fish were caught";
    }
}
