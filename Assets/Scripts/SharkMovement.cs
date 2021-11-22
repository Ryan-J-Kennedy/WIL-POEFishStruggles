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
        target = points[currentPoint];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position == target.position)
        {
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

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);
    }
}
