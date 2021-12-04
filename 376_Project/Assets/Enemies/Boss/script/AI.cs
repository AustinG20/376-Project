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
    private float bossAttackRange;
    private bool inAttackRange;

    private Animator animator;

    public float health;

    public GameObject closedChest;
    public GameObject openChest;

    private GameObject doorOne;
    private GameObject doorTwo;

    public bool bossDead;
    public GameObject bossdeath;
    public GameObject bosswalk;

    // Start is called before the first frame update
    void Start()
    {
        kevin = GameObject.Find("Kevin M");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        inChaseRange = false;
        bossSightRange = 6f;
        bossAttackRange = 2f;
        inAttackRange = false;
        bossDead = false;
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

        if(distance <= bossAttackRange)
        {
            agent.isStopped = true;
            animator.SetBool("inAttackRange", true);
        }
        else
        {
            agent.isStopped = false;
            animator.SetBool("inAttackRange", false);
        }


        //Chase kevin if he is in sight
        if (inChaseRange)
        {
            agent.isStopped = false;
            ChaseKevin();
        }
        else
        {
            agent.isStopped = true;
            bosswalk.SetActive(false);
        }
    }

    private void ChaseKevin()
    {
        //Make the enemy chase kevin
        agent.SetDestination(kevin.transform.position);
        bosswalk.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            health -= 25;

            if(health <= 0)
            {
                bossdeath.SetActive(true);
                Destroy(this.gameObject, 0.3f);
                openChest.SetActive(true);
                closedChest.SetActive(false);
                bossDead = true;
            }
        }

        if (other.gameObject.name == "closeDoor")
        {
            doorOne = GameObject.Find("bossDoorOne");
            doorTwo = GameObject.Find("bossDoorTwo");

            Vector3 doorOnePos = new Vector3(137.82f, 83.33f, -107.9292f);
            doorOne.transform.position = doorOnePos;

            Vector3 doorOneRotation = new Vector3(0, 270, 0);
            doorOne.transform.eulerAngles = doorOneRotation;

            Vector3 doorTwoPos = new Vector3(135.84f, 83.34f, -107.9292f);
            doorTwo.transform.position = doorTwoPos;

            Vector3 doorTwoRotation = new Vector3(0, 90, 0);
            doorTwo.transform.eulerAngles = doorTwoRotation;
        }
    }
}
