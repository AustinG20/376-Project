using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board_controller : MonoBehaviour
{

    [SerializeField] private int dimensions;
    [SerializeField] private List<GameObject> blocks;
    private GameObject source;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Plane p = new Plane(Camera.main.transform.forward, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                source = hit.collider.gameObject.transform.parent.gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {

            //Plane p = new Plane(Camera.main.transform.forward, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                CalculateMove(source, hit.collider.gameObject.transform.parent.gameObject);
            }
        }
    }

    private void CalculateMove(GameObject source, GameObject destination)
    {
        print("calculate move");
        
        if (destination.GetComponent<block_controller>().position == dimensions * dimensions)
        {
            if (ValidMove(source.GetComponent<block_controller>().current_position, destination.GetComponent<block_controller>().current_position))
            {
                Swap(source, destination);
                CheckBoardState();
            }
        }
    }

    private bool ValidMove(int start_pos, int end_pos)
    {
        if (end_pos <= dimensions * dimensions)
        {
            start_pos -= 1;
            end_pos -= 1;

            int start_row = start_pos / dimensions;
            int start_column = start_pos - start_row * dimensions;
            int end_row = end_pos / dimensions;
            int end_column = end_pos - end_row * dimensions;
            int x_dif = start_column - end_column;
            int y_dif = start_row - end_row;

            return (Mathf.Abs(x_dif + y_dif) == 1);
        }
        else
        {
            return false;
        }
    }

    private void Swap(GameObject source, GameObject destination)
    {
        int source_pos = source.GetComponent<block_controller>().current_position;
        int destination_pos = destination.GetComponent<block_controller>().current_position;

        source.GetComponent<block_controller>().current_position = destination_pos;
        destination.GetComponent<block_controller>().current_position = source_pos;

        source_pos = source.GetComponent<block_controller>().current_position;
        destination_pos = destination.GetComponent<block_controller>().current_position;

        int row = (source_pos - 1) / dimensions;
        int column = (source_pos - 1) - row * dimensions;
        source.GetComponent<block_controller>().target = new Vector3(column * 13 - 13, -row * 13 + 13, 90);
        
        row = (destination_pos - 1) / dimensions;
        column = (destination_pos - 1) - row * dimensions;
        destination.GetComponent<block_controller>().target = new Vector3(column * 13 - 13, -row * 13 + 13, 90);
    }

    private void CheckBoardState()
    {
        //see if puzzle is solved
        for(int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].GetComponent<block_controller>().current_position != blocks[i].GetComponent<block_controller>().position)
            {
                return;
            }
        }
        //TODO: puzzle is complete
    }
}
