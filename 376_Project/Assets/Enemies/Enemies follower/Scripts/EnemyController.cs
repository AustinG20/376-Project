using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private float lookRadius = 5f;

    Transform target;
    public NavMeshAgent agent;
    public fearfactor fearFactor;
    public GameObject restPoint;
    public bool followplayer;

    private bool resetting;
    private float counter;
    private float resetCounter;
    private GameObject ghoul;

    public GameObject sound;
    public GameObject gatesound;

    public void Start()
    {
        followplayer = true;
        resetting = false;
        target = GameObject.Find("Kevin M").transform;
        counter = 0f;
        resetCounter = 3f;

        agent = GetComponent<NavMeshAgent>();
        ghoul = GameObject.Find("Ghoul");
    }

    public void Update()
    {
        float distance = Vector3.Distance(target.position, this.transform.position);

        if (distance <= lookRadius && followplayer)
        {
           
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                // attack the target
                fearFactor.scarred(0.5f);
                followplayer = false;
                agent.SetDestination(restPoint.transform.position);
                // face the target
                resetting = true;
                FaceTarget();

            }
        }

        if(resetting == true){
            counter += Time.deltaTime;
            if (counter > resetCounter)
            {
                followplayer = true;
                counter = 0f;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gateButton")
        {
            sound.SetActive(true);
            gatesound.SetActive(true);
            GameObject gate;
            gate = GameObject.Find("Gate");
            ghoul.SetActive(false);
            Destroy(gate, 0.3f);
        }
    }
}
 