using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Transform groupLeader;
    Vector3 posToLeader;
    FishGroup group;
    GameController gc;
    Animator ani;
    bool spawning = true;
    float moveSpeed;

    bool trapped = false;
    bool canMove = true;
    Transform trap;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        posToLeader = transform.position - groupLeader.position;
        moveSpeed = Random.Range(moveSpeed - 1, moveSpeed + 1);

        StartCoroutine(StopSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    IEnumerator StopSpawn()
    {
        yield return new WaitForSeconds(3);

        spawning = false;
    }

    void Movement()
    {
        if (groupLeader.gameObject.CompareTag("Player"))
        {
            if (!groupLeader.GetComponent<PlayerMovement>().canMove)
                return;
        }

        if (canMove)
        {
            Vector3 pos = groupLeader.position + posToLeader;
            transform.position = Vector3.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);
            transform.LookAt(pos);

        }
        else if(trapped)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, trap.position, 100);
        }
    }

    public void Death()
    {

    }

    public void SetLeader(Transform _groupleader, FishGroup _group, float _moveSpeed)
    {
        groupLeader = _groupleader;
        group = _group;
        moveSpeed = _moveSpeed;
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.CompareTag("Fish") || other.CompareTag("Player")) && spawning)
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
        else if (other.CompareTag("Water"))
        {
            posToLeader.y -= 0.1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            trap = other.gameObject.transform;
            canMove = false;
            trapped = true;
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
