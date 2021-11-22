using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public Transform[] points;
    Transform target;
    public float speed;
    int currentPoint = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        //Sets target
        target = points[currentPoint];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks if the shark reached target
        if(transform.position == target.position)
        {
            //Checks whether to go to next target or loop to start
            if(target != points[points.Length - 1])
            {
                currentPoint++;
            }
            else
            {
                currentPoint = 0;
            }
            target = points[currentPoint];
        }

        //Move and look at target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);
    }
}
