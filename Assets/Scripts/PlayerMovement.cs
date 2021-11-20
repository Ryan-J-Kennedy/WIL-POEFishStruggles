using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Tail child object
    public GameObject tail;
    //Rigidbody on player
    private Rigidbody rb;
    GameController gc;

    //Tail rotate points
    public Transform left;
    public Transform right;
    public Transform middle;

    [Header("Movement Settings")]
    public float tailRotationSpeed;
    public float moveForce;
    public float turningSpeed;

    [HideInInspector]
    public bool canMove = true;
    Transform trap;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Finding values from scene
        //tail = GameObject.Find("PlayerTail");
        rb = this.GetComponent<Rigidbody>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Call movement method
        Movement();
        HeightMovement();

        Vector3 currentRotation = this.transform.rotation.eulerAngles;
        currentRotation.z = 180.0f;
        this.transform.localRotation = Quaternion.Euler(currentRotation);
    }

    void HeightMovement()
    {
        Vector3 rotation = this.transform.rotation.eulerAngles;
        rotation.x += Input.GetAxis("Vertical") * turningSpeed * Time.deltaTime;

        //if(rotation.x > 40f)
        //{
        //    rotation.x = 40f;
        //}
        //else if(rotation.x < -40f)
        //{
        //    rotation.x = -40f;
        //}

        //rotation.x = Mathf.Clamp(rotation.x, -40f, 40f);

        this.transform.rotation = Quaternion.Euler(rotation);

    }

    void Movement()
    {
        if(canMove == false)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, trap.position, 100);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Rotate player when moving tail
            this.transform.Rotate(0f, -turningSpeed * Time.deltaTime, 0f);

            //Rotating tail to rotate point
            tail.transform.rotation = Quaternion.RotateTowards(tail.transform.rotation, right.rotation, tailRotationSpeed * Time.deltaTime);

            //Adding force to move player if the tail is moving
            if(tail.transform.rotation != right.transform.rotation && canMove)
            {
                rb.AddRelativeForce(Vector3.back * moveForce);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Rotate player when moving tail
            this.transform.Rotate(0f, turningSpeed * Time.deltaTime, 0f);

            //Rotating tail to rotate point
            tail.transform.rotation = Quaternion.RotateTowards(tail.transform.rotation, left.rotation, tailRotationSpeed * Time.deltaTime);

            //Adding force to move player if the tail is moving
            if (tail.transform.rotation != left.transform.rotation && canMove)
            {
                rb.AddRelativeForce(Vector3.back * moveForce);
            }
        }
        else //Returning the tail to neutral if no inputs
        {
            tail.transform.rotation = Quaternion.RotateTowards(tail.transform.rotation, middle.rotation, tailRotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            trap = other.gameObject.transform;
            canMove = false;
            rb.velocity = Vector3.zero;
            other.GetComponentInParent<FishBoatController>().hooked = true;
            gc.TurnOnDialouge();
        }
        else if (other.CompareTag("Food"))
        {
            gc.foodAmount++;
            GameObject.Destroy(other.gameObject);
        }
        else if (other.CompareTag("Current"))
        {
            currentTime = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Current"))
        {
            Current current = other.GetComponent<Current>();
            float currentForce = current.strength;
            if (current.additive)
                currentForce = current.strength + currentTime;

            rb.AddForce(current.transform.forward * currentForce);
            currentTime += 0.1f;
        }
    }
}
