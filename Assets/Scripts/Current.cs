using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
    public Transform direction;
    public float strength;

    // Start is called before the first frame update
    void Start()
    {
        direction = transform.GetChild(0);
    }
}
