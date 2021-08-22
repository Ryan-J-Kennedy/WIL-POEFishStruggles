using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject body;
    private GameObject tail;

    public Transform left;
    public Transform right;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.Find("PlayerBody");
        tail = GameObject.Find("PlayerTail");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            tail.transform.rotation = Quaternion.RotateTowards(tail.transform.rotation, right.rotation, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tail.transform.rotation = Quaternion.RotateTowards(tail.transform.rotation, left.rotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            tail.transform.rotation = Quaternion.RotateTowards(tail.transform.rotation, Quaternion.Euler(0f,0f,0f), rotationSpeed * Time.deltaTime);
        }
    }
}
