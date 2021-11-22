using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGroupMovement : MonoBehaviour
{
    public GameObject MoveArea;
    BoxCollider Area;
    float maxY, minY;
    float maxX, minX;
    float maxZ, minZ;

    Vector3 moveLocation;

    // Start is called before the first frame update
    void Start()
    {
        Area = MoveArea.GetComponent<BoxCollider>();
        Vector3 pos = MoveArea.transform.position;

        moveLocation = new Vector3(
            Random.Range(Area.bounds.min.x, Area.bounds.max.x), 
            Random.Range(Area.bounds.min.y, Area.bounds.max.y), 
            Random.Range(Area.bounds.min.z, Area.bounds.max.z));

        this.transform.position = moveLocation;

        StartCoroutine(ChangeSpot());
    }

    IEnumerator ChangeSpot()
    {
        yield return new WaitForSeconds(2);

        moveLocation = new Vector3(
            Random.Range(Area.bounds.min.x, Area.bounds.max.x),
            Random.Range(Area.bounds.min.y, Area.bounds.max.y),
            Random.Range(Area.bounds.min.z, Area.bounds.max.z));
        this.transform.position = moveLocation;

        StartCoroutine(ChangeSpot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
