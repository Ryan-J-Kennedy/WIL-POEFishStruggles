using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoatController : MonoBehaviour
{
    Transform fishingRod;
    Transform hook;
    public float fishingRodSpeed;
    Transform player;
    public Transform rodPos;

    public bool hooked = false;

    // Start is called before the first frame update
    void Start()
    {
        //Finding objects in scene and initilising.
        fishingRod = this.gameObject.transform.Find("Fishing rod");
        hook = fishingRod.gameObject.transform.Find("Hook");
        player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        Hooked();

        Vector3 playerHeight = new Vector3(fishingRod.transform.position.x, player.position.y + 1, fishingRod.transform.position.z);
        //Moving hook down to the height of the player

        fishingRod.position = Vector3.MoveTowards(fishingRod.position, playerHeight, 2);

        //if (hook.position.y > player.position.y)
        //{
        //    fishingRod.transform.position -= new Vector3(0f, fishingRodSpeed, 0f);
        //}
        //else if(hook.position.y < player.position.y)
        //{
        //    fishingRod.transform.position += new Vector3(0f, fishingRodSpeed, 0f);
        //}
    }

    //When a fish is hooked moving the hook up to top
    public void Hooked()
    {
        if (hook.position.y < rodPos.position.y && hooked)
        {
            fishingRod.transform.position -= new Vector3(0f, -fishingRodSpeed * 2, 0f);
        }
    }
}
