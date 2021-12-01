using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    //the enemy var
    private NavMeshAgent agent;

    //kevin var
    private GameObject kevin;

    //variables to check distance
    private float distance;
    private float bossSightRange;
    private bool inChaseRange;

    private Animator animator;

    private float health;


    // Start is called before the first frame update
    void Start()
    {
        kevin = GameObject.Find("Kevin M");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        inChaseRange = false;
        bossSightRange = 8f;
        health = 400f;
    }

    // Update is called once per frame
    void Update()
    {
        //check distance between kevin and boss
        distance = Vector3.Distance(kevin.transform.position, this.transform.position);

        //If kevin is less than 5f away he is in sight
        if (distance <= bossSightRange)
        {
            inChaseRange = true;
            animator.SetBool("inRange", true);

        }
        else
        {
            inChaseRange = false;
            animator.SetBool("inRange", false);
        }


        //Chase kevin if he is in sight
        if (inChaseRange)
        {
            agent.isStopped = false;
            ChaseKevin();
        }
        else
            agent.isStopped = true;
    }

    private void ChaseKevin()
    {
        //Make the enemy chase kevin
        agent.SetDestination(kevin.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            health -= 5;

            if(health <= 0)
            {
                Destroy(this);
            }
        }
    }
}
