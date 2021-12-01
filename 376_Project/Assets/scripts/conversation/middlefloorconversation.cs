using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middlefloorconversation : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    public GameObject bg;
    public GameObject ft1;
    public GameObject ft2;
    public GameObject ft3;
    public GameObject ft4;

    public GameObject cbg1;
    public GameObject cbg2;

    public GameObject kt1;
    public GameObject kt2;

    public GameObject changebutton;
    public int controltext = 0;
    public int playerchoice = 0;

    public void conversation()
    {
        controltext++;

        switch (controltext)
        {
            case 1:
                //Time.timeScale = 0;

                ft2.SetActive(true);
                ft1.SetActive(false);
                break;
            case 2:
                //ft2.SetActive(false);
               // ft3.SetActive(true);
                cbg1.SetActive(true);
                cbg2.SetActive(true);
                kt1.SetActive(true);
                kt2.SetActive(true);
                changebutton.SetActive(false);
                //ft2.SetActive(false);
                break;
            case 3:
                ft2.SetActive(false);

                if (playerchoice == 1)
                {
                    ft3.SetActive(true);
                }
                if (playerchoice == 2)
                {
                    ft4.SetActive(true);
                }

                break;
                
            case 4:

                bg.SetActive(false);
                camera1.SetActive(true);
                camera2.SetActive(false);
                break;
                /*
            case 5:

                if (playerchoice == 1)
                {
                    cbg1.SetActive(true);
                    kt1.SetActive(false);
                    playerchoice = 0;
                }
                if (playerchoice == 2)
                {
                    cbg2.SetActive(true);
                    kt2.SetActive(false);
                    playerchoice = 0;
                }

                changebutton.SetActive(false);

                break;

            case 6:
                bg.SetActive(false);
                camera1.SetActive(true);
                camera2.SetActive(false);
                //Time.timeScale = 1;
                break;
                */
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
}
