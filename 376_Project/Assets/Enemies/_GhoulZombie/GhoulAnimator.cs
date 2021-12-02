using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhoulAnimator : MonoBehaviour
{

    
    public NavMeshAgent agent;
    // public Animator animator;
    public Animation animation;

    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponentInChildren<Animator>();
        animation = GetComponentInChildren<Animation>();


    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude;
        if (speed > 0.1)
        {
            
        }


       // animator.SetFloat("speed", speed, .1f, Time.deltaTime);
    }
}
