using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    public float lookRadius = 3;
    public bool followplayer;
    Transform player;
    public fearfactor fearFactor;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = PlayerManager.instance.player.transform;
        followplayer = true;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius && followplayer)
        {
            ChasePlayer();
        }
       
       

        // Choose the next destination point when the agent gets
        // close to the current one.
       else if (!agent.pathPending && agent.remainingDistance < 1f)
            GotoNextPoint();
    }



    void ChasePlayer()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius && followplayer)
        {

            agent.SetDestination(player.position);

            if (distance <= agent.stoppingDistance + 2.5f)
            {
                // attack the target
                fearFactor.scarred(1.0f);
                followplayer = false;
                //  agent.SetDestination(restPoint.transform.position);
                // GotoNextPoint();
                // face the target

                FaceTarget();
            }

            

        }


        void FaceTarget()
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }
    }
}
