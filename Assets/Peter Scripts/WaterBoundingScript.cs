using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterBoundingScript : MonoBehaviour
{
    public GameObject BoundingBox, Player;
    public Volume Post;
    public Color UnderwaterColour;

    public bool isUnderwater = false;

    //Effects
    private Vignette vg;
    private DepthOfField dof;
    private ColorAdjustments ca;

    void Start() {
        Post.profile.TryGet(out dof);
        Post.profile.TryGet(out ca);
        Post.profile.TryGet(out vg);
    }

    void FixedUpdate() {
        if(BoundingBox.GetComponent<BoxCollider>().bounds.Contains(Player.transform.position))
        {
            isUnderwater = true;
        }
        else
        {
            isUnderwater = false;
        }

        if(isUnderwater)
        {
            vg.intensity.value = 0.35f;
            dof.focusDistance.value = 2f;
            ca.colorFilter.value = UnderwaterColour;
        }
        else
        {
            vg.intensity.value = 0.292f;
            dof.focusDistance.value = 5f;
            ca.colorFilter.value = Color.white;
        }
    }
}
