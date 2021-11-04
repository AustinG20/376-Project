using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float speed;
    public Transform[] waypoints;
    public fearfactor ff;

    public Animator animator;

    private int waypointIndex;
    private float distanceFromWaypoint;

    private float idleCounter;
    private float minIdle;
    private float maxIdle;
    private float selectedIdleTime;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        waypointIndex = 1;
        transform.LookAt(waypoints[waypointIndex].position);
        minIdle = 10f;
        maxIdle = 25f;
        animator.SetBool("idle", false);
        animator.SetBool("isWalking", true);
        selectedIdleTime = Random.Range(minIdle, maxIdle);
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromWaypoint = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(distanceFromWaypoint < 0.5f)
        {
            idleCounter += Time.deltaTime;
            animator.SetBool("idle", true);
            animator.SetBool("isWalking", false);
            speed = 0f;
           // Debug.Log(idleCounter);
            Debug.Log(selectedIdleTime);

            if (idleCounter > selectedIdleTime)
            {
                ChangeIndex();
                speed = 1f;
                animator.SetBool("idle", false);
                animator.SetBool("isWalking", true);
                selectedIdleTime = Random.Range(minIdle, maxIdle);
                idleCounter = 0f;

            }
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void ChangeIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }

        transform.LookAt(waypoints[waypointIndex].position);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "playa")
        {
            ff.scarred(0.75f);
        }
    }
}
