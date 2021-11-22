using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGroup : MonoBehaviour
{
    public GameObject fish;
    public int fishNumber;
    public float maxRange;
    public float fishSpeed;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fishNumber; i++)
        {
            SpawnFish();
        }
    }

    void SpawnFish()
    {
        float posX = Random.Range(this.transform.position.x - maxRange, this.transform.position.x + maxRange);
        float posZ = Random.Range(this.transform.position.z, this.transform.position.z + maxRange);
        float posY = Random.Range(this.transform.position.y - maxRange, this.transform.position.y + maxRange);

        while(posX > transform.position.x - 1 && posX < transform.position.x + 1)
        {
            posX = Random.Range(this.transform.position.x - maxRange, this.transform.position.x + maxRange);
        }

        GameObject fishObject = Instantiate(fish, new Vector3(posX, posY, posZ), Quaternion.Euler(0, 90, 0));
        fishObject.GetComponent<Fish>().SetLeader(this.transform, this, fishSpeed);
    }

    public Vector3 NewPos()
    {
        float posX = Random.Range(this.transform.position.x - maxRange, this.transform.position.x + maxRange);
        float posZ = Random.Range(this.transform.position.z, this.transform.position.z + maxRange);
        float posY = Random.Range(this.transform.position.y - maxRange, this.transform.position.y + maxRange);

        while (posX > transform.position.x - 1 && posX < transform.position.x + 1)
        {
            posX = Random.Range(this.transform.position.x - maxRange, this.transform.position.x + maxRange);
        }

        return new Vector3(posX, posY, posZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
