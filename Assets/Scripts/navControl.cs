using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{

    public GameObject Target;
    private NavMeshAgent agent;
    bool isWalking = true;
    private Animator animator;
    



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        GetComponent<NavMeshAgent>().speed = 5;
        GetComponent<Animator>().speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            Debug.Log("Walking");
            agent.destination = Target.transform.position;
        }
        else
        {
            Debug.Log("Atacking");
            agent.destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Red")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
        }
    }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Red")
            {
            isWalking = true;
            animator.SetTrigger("WALK");
            }
        }
}

