using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pin_controller : MonoBehaviour
{

    public bool state = false;
    [SerializeField] private float offset;
    public int counter;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown("w"))
        {
            counter++;
            Debug.Log("counting");
        }

        if(counter >= 3)
        {
            //Debug.Log("load scene");
            TimerScript.NextLevel();
            SceneManager.LoadScene("NextLevel");
        }

        if(timer >= 30)
        {
            SceneManager.LoadScene("Gameover");
        }
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
