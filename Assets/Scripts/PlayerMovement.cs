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

    public GameObject[] currentParticles;

    [HideInInspector]
    public bool canMove = true;
    bool trapped = false;
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
    void FixedUpdate()
    {
        //Call movement method
        Movement();
        HeightMovement();

        //Add gravitiy if the player is above the water level
        if (transform.position.y > 3f)
            rb.useGravity = true;
        else
            rb.useGravity = false;

        Vector3 currentRotation = this.transform.rotation.eulerAngles;
        currentRotation.z = 180.0f;
        this.transform.localRotation = Quaternion.Euler(currentRotation);
    }

    void HeightMovement()
    {
        //Rotate player up and down
        Vector3 rotation = this.transform.rotation.eulerAngles;
        rotation.x += Input.GetAxis("Vertical") * turningSpeed * Time.deltaTime;

        this.transform.rotation = Quaternion.Euler(rotation);

    }

    public void Death()
    {
        gc.Death();
    }

    void Movement()
    {
        //If stuck in trap and cant move
        if(canMove == false)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, trap.position, 100);
        }

        //Key inputs
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
        //Get caught by the trap and stop moving
        if (other.CompareTag("Trap"))
        {
            trap = other.gameObject.transform;
            canMove = false;
            trapped = true;
            rb.velocity = Vector3.zero;
            other.GetComponentInParent<FishBoatController>().hooked = true;
            Death();
            //gc.TurnOnDialouge();
        }
        //Pick up food
        else if (other.CompareTag("Food"))
        {
            gc.foodAmount++;
            GameObject.Destroy(other.gameObject);
        }
        //Reset current time
        else if (other.CompareTag("Current"))
        {
            currentTime = 0;
        }
        else if (other.CompareTag("Shark"))
        {
            Death();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Add current and direction
        if (other.CompareTag("Current"))
        {
            Current current = other.GetComponent<Current>();
            float currentForce = current.strength;
            if (current.additive)
                currentForce = current.strength + currentTime;

            rb.AddForce(current.transform.forward * currentForce);
            currentTime += 0.1f;

            foreach (GameObject go in currentParticles)
            {
                go.SetActive(true);
                //go.transform.rotation = Quaternion.Euler(-current.transform.forward);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Remove current particle effect
        if (other.CompareTag("Current"))
        {
            foreach (GameObject go in currentParticles)
            {
                go.SetActive(false);
            }
        }
    }
}
