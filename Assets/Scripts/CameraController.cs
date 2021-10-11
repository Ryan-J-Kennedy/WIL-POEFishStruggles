using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    public float rotatingSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        Rotate();
    }

    void Rotate()
    {
        rotatingSpeed = Mathf.Abs(player.rotation.y - this.transform.rotation.y) * 200;

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, player.rotation, rotatingSpeed * Time.deltaTime);
    }

    void FollowPlayer()
    {
        Vector3 playerPos = player.position;
        this.transform.position = playerPos;
    }
}
