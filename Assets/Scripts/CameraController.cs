using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public WaterBoundingScript waterScript;
    public float rotatingSpeed = 20;
    public Transform water;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckWater();
    }

    void CheckWater()
    {
        if(this.transform.position.y > 3f)
        {
            water.rotation = Quaternion.Euler(0, 0, 0);
            waterScript.isUnderwater = false;
        }
        else
        {
            water.rotation = Quaternion.Euler(180, 0, 0);
            waterScript.isUnderwater = true;
        }
    }
}
