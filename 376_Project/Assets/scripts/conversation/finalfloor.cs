using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalfloor : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject deathcamera;

    public GameObject bg;
    public GameObject ft1;
    public GameObject ft2;
    public GameObject ft3;
    public GameObject ft4;
    public GameObject ft5;
    public GameObject ft6;
    
    public GameObject cbg1;
    public GameObject cbg2;

    public GameObject kt1;
    public GameObject kt2;

    public GameObject changebutton;
    public int controltext = 0;
    public int playerchoice = 0;

    public GameObject meteor;

    public GameObject win;

    public void conversation()
    {
        controltext++;

        switch (controltext)
        {
            case 1:

                ft2.SetActive(true);
                ft1.SetActive(false);
                break;
            case 2:

                ft2.SetActive(false);
                bg.SetActive(false);
                camera1.SetActive(true);
                camera2.SetActive(false);
                break;

            case 3:

                ft3.SetActive(true);
                bg.SetActive(true);
                camera1.SetActive(false);
                camera2.SetActive(true);
                break;

            case 4:

                ft3.SetActive(false);
                ft4.SetActive(true);
                break;

            case 5:

                cbg1.SetActive(true);
                cbg2.SetActive(true);
                kt1.SetActive(true);
                kt2.SetActive(true);
                changebutton.SetActive(false);
                break;

            case 6:

                if (playerchoice == 1)
                {
                    ft5.SetActive(true);
                    bg.SetActive(false);
                    camera1.SetActive(true);
                    camera2.SetActive(false);
                    win.SetActive(true);
                }
                if (playerchoice == 2)
                {
                    ft6.SetActive(true);
                }

                break;

            case 8:

                bg.SetActive(false);
                camera1.SetActive(false);
                camera2.SetActive(false);
                deathcamera.SetActive(true);
                meteor.SetActive(true);
                break;
        }
    }

    public void firstchoice()
    {
        playerchoice = 1;
        cbg2.SetActive(false);
        cbg1.SetActive(false);
        changebutton.SetActive(true);
        conversation();
    }
    public void secondchoice()
    {
        playerchoice = 2;
        cbg2.SetActive(false);
        cbg1.SetActive(false);
        changebutton.SetActive(true);
        conversation();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            conversation();
        }
    }
}
