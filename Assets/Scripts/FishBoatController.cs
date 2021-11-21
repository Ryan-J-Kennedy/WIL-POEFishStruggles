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

        //Moving hook down to the height of the player
        if (hook.position.y > player.position.y)
        {
            fishingRod.transform.position -= new Vector3(0f, fishingRodSpeed, 0f);
        }
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
