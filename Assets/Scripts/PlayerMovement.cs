using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Tail child object
    private GameObject tail;
    //Rigidbody on player
    private Rigidbody rb;

    //Tail rotate points
    public Transform left;
    public Transform right;

    [Header("Movement Settings")]
    public float tailRotationSpeed;
    public float moveForce;
    public float turningSpeed;

    bool canMove = true;
    Transform trap;

    // Start is called before the first frame update
    void Start()
    {
        //Finding values from scene
        tail = GameObject.Find("PlayerTail");
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Call movement method
        Movement();
        HeightMovement();

        Vector3 currentRotation = this.transform.rotation.eulerAngles;
        currentRotation.z = 0.0f;
        this.transform.localRotation = Quaternion.Euler(currentRotation);
    }

    void HeightMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Rotate player
            if (this.transform.rotation.x < 0.30)
            {
                this.transform.Rotate(turningSpeed * Time.deltaTime, 0f, 0f);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Rotate player
            if (this.transform.rotation.x > -0.30)
            {
                this.transform.Rotate(-turningSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }

    void Movement()
    {
        if(canMove == false)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, trap.position, 100);
        }

        if (Input.GetKey(KeyCode.A))
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
        else if (Input.GetKey(KeyCode.D))
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
            tail.transform.rotation = Quaternion.RotateTowards(tail.transform.rotation, this.transform.rotation, tailRotationSpeed * Time.deltaTime);
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
        }
    }
}
