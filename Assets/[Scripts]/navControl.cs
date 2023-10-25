using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{
    public GameObject Target;

    public NavMeshAgent agent;

    bool isWalking = true;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.speed = (2f);
        agent.speed = (2f);
        if (isWalking)
        {
            agent.destination = Target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Blue")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Blue")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
