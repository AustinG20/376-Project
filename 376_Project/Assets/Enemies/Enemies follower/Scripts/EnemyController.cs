using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 3;

    Transform target;
    public NavMeshAgent agent;
    public fearfactor fearFactor;
    public GameObject restPoint;
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
            FaceTarget();
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance + 1)
            {
                // attack the target
                fearFactor.scarred(1.0f);
                followplayer = false;
               // agent.SetDestination(restPoint.transform.position);
                // face the target
                

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
}
 