using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement : MonoBehaviour
{
    private float moveVert;
    private float moveHorz;

    Animator animator;

    public CharacterController controller;
    public Transform cam;

    private float speed = 1.0f;
    private float turnSpeed = 0.8f;
    private float turnVelocity;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveHorz = Input.GetAxis("Horizontal");
        moveVert = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorz, 0, moveVert).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isWalking", true);

            if (animator.GetBool("scared"))
            {
                speed = 0.5f;
            }

            if (Input.GetKey(KeyCode.LeftShift) && animator.GetBool("scared"))
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);
                speed = 1.0f;
            }
            else
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isRunning", false);
            }

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("backwardsWalk", true);
        }
        else
        {
            animator.SetBool("backwardsWalk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && animator.GetBool("scared"))
        {
            animator.SetBool("isRunning", true);
            speed = 0.60f;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}

