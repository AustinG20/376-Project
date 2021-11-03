using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    public GameObject firetrap;
    private bool controlfire;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        controlfire = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 10 && controlfire)
        {
            firetrap.SetActive(false);
            timer = 0.0f;
            controlfire = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playa" && controlfire == false)
        {
            firetrap.SetActive(true);
            controlfire = true;
        }
    }
}
