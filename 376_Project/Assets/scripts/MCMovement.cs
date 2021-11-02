using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;
    private float moveVert;
    private float moveHorz;

    private Vector3 movement;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        rotationSpeed = 300.0f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorz = Input.GetAxis("Horizontal");
        moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorz, 0, moveVert);
        movement.Normalize();

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
