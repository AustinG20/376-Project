using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollScript : MonoBehaviour
{
    public GameObject[] path;
    public int currentPoint;
    public GameObject currentGoal;
    // We dont need the exact position so we will round it
    public float roundingDistance = 0.1f;

    public float lookRadius = 3;

    Transform target;
    public NavMeshAgent agent;
    public fearfactor fearFactor;
   // public GameObject restPoint;
    public bool followplayer;


    public void Start()
    {
        followplayer = true;
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && followplayer)
        {

            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // attack the target
                fearFactor.scarred(1.0f);
                followplayer = false;
                agent.SetDestination(currentGoal.transform.position);
                // face the target
                FaceTarget();

            }
        }
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    // We are using the AntiVaxer Start method


    // the checkDistance is called from the base class FixedUpdate
    // which mean this checkDistance is called from this class FixedUpdate



    private void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}