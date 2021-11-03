using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap1 : MonoBehaviour
{
    public GameObject mc;
    public GameObject mccamera;
    public GameObject skeleton;
    public GameObject trapcamera;
    public GameObject trap;
    public GameObject buttons;

    public fearfactor ff;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "playa")
        {
            mc.SetActive(false);
            mccamera.SetActive(false);
            skeleton.SetActive(true);
            trapcamera.SetActive(true);
            buttons.SetActive(true);
            ff.scarred(0.5f);
        }
    }

    public void continuegame(){

        mc.SetActive(true);
        mccamera.SetActive(true);
        //skeleton.SetActive(false);
        trapcamera.SetActive(false);
        trap.SetActive(false);
        buttons.SetActive(false);
    }
}
