using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_controller : MonoBehaviour
{
    [SerializeField] public int current_position;
    [SerializeField] public int position;
    [SerializeField] private float step = 1;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        int row = (current_position - 1) / 3;
        int column = (current_position - 1) - (row * 3);
        target = new Vector3(column * 13 - 13, -row * 13 + 13, 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
