using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGroupMovement : MonoBehaviour
{
    public GameObject MoveArea;
    BoxCollider Area;

    Vector3 moveLocation;

    // Start is called before the first frame update
    void Start()
    {
        Area = MoveArea.GetComponent<BoxCollider>();
        Vector3 pos = MoveArea.transform.position;

        //Gets a postion within the area they can swim
        moveLocation = new Vector3(
            Random.Range(Area.bounds.min.x, Area.bounds.max.x), 
            Random.Range(Area.bounds.min.y, Area.bounds.max.y), 
            Random.Range(Area.bounds.min.z, Area.bounds.max.z));

        this.transform.position = moveLocation;

        //Calls the change spot coroutine
        StartCoroutine(ChangeSpot());
    }

    IEnumerator ChangeSpot()
    {
        //Waits and then chooses and new random pos
        yield return new WaitForSeconds(Random.Range(1.5f, 3f));

        moveLocation = new Vector3(
            Random.Range(Area.bounds.min.x, Area.bounds.max.x),
            Random.Range(Area.bounds.min.y, Area.bounds.max.y),
            Random.Range(Area.bounds.min.z, Area.bounds.max.z));
        this.transform.position = moveLocation;

        StartCoroutine(ChangeSpot());
    }
}
