using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int foodAmount = 0;
    public Transform dayImage;
    public Text foodText;
    public GameObject dialouge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TurnOnDialouge()
    {
        dialouge.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dayImage.Rotate(new Vector3(0f, 0f, 0.1f));
        foodText.text = "Food: " + foodAmount;
    }
}
