using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin_controller : MonoBehaviour
{

    public bool state = false;
    [SerializeField] private float offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        UpdatePosition();
        state = !state;
    }

    public void UpdatePosition()
    {
        //move towards the up or down position
        if (state)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, -offset, 0), offset);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, offset, 0), offset);
        }
    }

    public void ResetPosition()
    {
        if (state)
            UpdatePosition();
        state = false;
    }
}
