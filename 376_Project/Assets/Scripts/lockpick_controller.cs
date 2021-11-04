using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockpick_controller : MonoBehaviour
{

    [SerializeField] private GameObject lock_;
    [SerializeField] private float pin_offset;
    [SerializeField] private float step = 10;
    [SerializeField] private int pins = 3;
    private int pick_position = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 offset = new Vector3(1 * step, 0, 0);
            if (MoveLockpick(offset))
                pick_position++;

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 offset = new Vector3(-1 * step, 0, 0);
            if (MoveLockpick(offset))
                pick_position--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && pick_position != 0)
        {
            lock_.GetComponent<lock_controller>().PushPin(pick_position - 1);
        }
    }

    private bool MoveLockpick(Vector3 offset)
    {
        //check if lock pick can move further
        if (offset.x > 0 && pick_position < pins)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + offset, step);
            return true;
        }
        else if (offset.x < 0 && pick_position > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + offset, step);
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
