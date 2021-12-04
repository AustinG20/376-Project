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
    private GameObject butler;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        waypointIndex = 1;
        transform.LookAt(waypoints[waypointIndex].position);
        minIdle = 10f;
        maxIdle = 15f;
        animator.SetBool("idle", false);
        animator.SetBool("isWalking", true);
        selectedIdleTime = Random.Range(minIdle, maxIdle);
        butler = GameObject.Find("butler");
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
                speed = 0.5f;
                animator.SetBool("idle", false);
                animator.SetBool("isWalking", true);
                selectedIdleTime = Random.Range(minIdle, maxIdle);
                idleCounter = 0f;

            }
        }
        Patrol();
        if (butler.transform.position.y > 2.24f)
        {
            Vector3 pos = new Vector3(butler.transform.position.x, 2.24f, butler.transform.position.z);
            butler.transform.position = pos;
        }
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
            ff.scarred(1.0f);
        }
    }
}
