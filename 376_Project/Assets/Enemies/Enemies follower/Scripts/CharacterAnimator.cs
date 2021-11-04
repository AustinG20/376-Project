using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{

    
    public NavMeshAgent agent;
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat("speed", speed, .1f, Time.deltaTime);
    }
}
