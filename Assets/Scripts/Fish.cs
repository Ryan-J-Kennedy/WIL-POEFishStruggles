using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Transform groupLeader;
    Vector3 posToLeader;
    FishGroup group;
    GameController gc;

    bool canMove = true;
    Transform trap;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        posToLeader = transform.position - groupLeader.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    void Movement()
    {
        if (canMove && groupLeader.GetComponent<PlayerMovement>().canMove)
        {
            Vector3 pos = groupLeader.position + posToLeader;
            transform.position = Vector3.MoveTowards(transform.position, pos, 7f * Time.deltaTime);
            transform.LookAt(pos);

        }
        else if(!canMove)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, trap.position, 100);
        }
    }

    public void SetLeader(Transform _groupleader, FishGroup _group)
    {
        groupLeader = _groupleader;
        group = _group;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fish") || other.CompareTag("Player"))
        {
            if (other.CompareTag("Fish") && !other.GetComponent<Fish>().canMove)
            {
                return;
            }
            else if(other.CompareTag("Player") && !other.GetComponent<PlayerMovement>().canMove)
            {
                return;
            }
            Vector3 newPos = group.NewPos();
            posToLeader = newPos - groupLeader.position;
            transform.position = newPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            trap = other.gameObject.transform;
            canMove = false;
            //rb.velocity = Vector3.zero;
            other.GetComponentInParent<FishBoatController>().hooked = true;
            other.tag = "Untagged";
            group.fishNumber--;
        }
        else if (other.CompareTag("Food"))
        {
            gc.foodAmount++;
            GameObject.Destroy(other.gameObject);
        }
    }
}
