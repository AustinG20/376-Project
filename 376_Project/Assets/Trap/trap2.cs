using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    public GameObject firetrap;
    private bool controlfire;
    private float timer;
    public fearfactor ff;

    public GameObject trapcamera;
    public GameObject mccamera;
    public GameObject buttons;
    //public GameObject mc;
    public GameObject trap;
    public MCMovement mm;

    // Start is called before the first frame update
    void Start()
    {
        //timer = 0.0f;
        //controlfire = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;

        if(timer >= 10 && controlfire)
        {
            firetrap.Stop();
            timer = 0.0f;
            controlfire = false;
        }
        else if(timer < 10 && controlfire == false)
        {
            firetrap.Play();
            controlfire = true;
        }*/
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playa")
        {
            ff.scarred(0.5f);
            //mc.SetActive(false);
            mm.speed = 0.0f;
            firetrap.SetActive(true);
            mccamera.SetActive(false);
            trapcamera.SetActive(true);
            buttons.SetActive(true);
        }
    }

    public void continuegame()
    {

        //mc.SetActive(true);
        mm.speed = 1.0f;
        mccamera.SetActive(true);
        trapcamera.SetActive(false);
        trap.SetActive(false);
        buttons.SetActive(false);
    }
}
