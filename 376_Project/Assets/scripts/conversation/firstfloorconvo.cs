using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstfloorconvo : MonoBehaviour
{
    public GameObject fairy;
    public GameObject camera1;
    public GameObject camera2;

    public GameObject bg;
    public GameObject ft1;
    public GameObject ft2;
    public GameObject ft3;
    public GameObject ft4;
    public GameObject ft5;
    public GameObject ft6;
    public GameObject ft7;
    public GameObject ft8;
    public GameObject ft9;
    public GameObject ft10;
    public GameObject ft11;
    public GameObject ft12;

    public GameObject cbg1;
    public GameObject cbg2;
   // public GameObject cbg3;
    public GameObject kt1;
    public GameObject kt2;
    public GameObject kt3;
    public GameObject kt4;
    public GameObject kt5;
    public GameObject kt6;

    public GameObject changebutton;
    public int controltext = 0;
    public int playerchoice = 0;

    public void conversation()
    {
        controltext++;

        switch (controltext)
        {
            case 1:
                Time.timeScale = 0;

                ft2.SetActive(true);
                ft3.SetActive(false);
                break;
            case 2:
                ft2.SetActive(false);
                ft3.SetActive(true);
                break;
            case 3:
                cbg1.SetActive(true);
                cbg2.SetActive(true);
              //  cbg3.SetActive(true);
                kt1.SetActive(true);
                kt2.SetActive(true);
                kt3.SetActive(true);
                kt4.SetActive(false);
                changebutton.SetActive(false);
                break;
            case 4:

                if (playerchoice == 1)
                { 
                    ft4.SetActive(true);
                    //playerchoice = 0;
                }
                if (playerchoice == 2)
                {
                    ft5.SetActive(true);
                   //playerchoice = 0;
                }
                /*
                if (playerchoice == 3)
                {
                    ft6.SetActive(true);
                    //cbg3.SetActive(true);
                    //playerchoice = 0;
                }*/
                ft3.SetActive(false);

                break;
            case 5:

                if (playerchoice == 1)
                {
                    cbg1.SetActive(true);
                    kt1.SetActive(false);
                    kt4.SetActive(true);
                    playerchoice = 0;
                }
                if (playerchoice == 2)
                {
                    ft5.SetActive(true);
                    cbg2.SetActive(true);
                    kt2.SetActive(false);
                    kt5.SetActive(true);
                    playerchoice = 0;
                }
                /*
                if (playerchoice == 3)
                {
                    ft6.SetActive(true);
                    kt3.SetActive(false);

                    kt6.SetActive(true);
                    //cbg3.SetActive(true);
                    playerchoice = 0;
                }
                */
                changebutton.SetActive(false);
                
                break;
            case 6:

                if (playerchoice == 1)
                {
                    ft4.SetActive(false);
                    ft5.SetActive(false);
                    ft6.SetActive(false);
                    ft7.SetActive(true);
                    cbg2.SetActive(false);
               //     cbg3.SetActive(false);
                    playerchoice = 0;
                }
                if (playerchoice == 2)
                {
                    cbg1.SetActive(false);
                   //cbg3.SetActive(false);
                    ft4.SetActive(false);
                    ft5.SetActive(false);
                    ft6.SetActive(false);
                    ft8.SetActive(true);
                    playerchoice = 0;
                }
                /*
                if (playerchoice == 3)
                {
                    ft4.SetActive(false);
                    ft5.SetActive(false);
                    ft6.SetActive(false);
                    ft9.SetActive(true);
                    cbg1.SetActive(false);
                    cbg2.SetActive(false);
                    playerchoice = 0;
                }
                */
                break;
            case 7:

                ft7.SetActive(false);
                ft8.SetActive(false);
                ft9.SetActive(false);
                ft1.SetActive(true);
                break;
            case 8:
                bg.SetActive(false);
                camera1.SetActive(true);
                camera2.SetActive(false);
                fairy.SetActive(true);
                Time.timeScale = 1;
                break;

            case 9:
                bg.SetActive(false);
                camera1.SetActive(true);
                camera2.SetActive(false);
                break;
            case 10:
                bg.SetActive(false);
                camera1.SetActive(true);
                camera2.SetActive(false);
                break;
            case 11:
                bg.SetActive(false);
                camera1.SetActive(true);
                camera2.SetActive(false);
                break;
        }
    }

    public void firstchoice()
    {
        playerchoice = 1;
        cbg2.SetActive(false);
       // cbg3.SetActive(false);
        cbg1.SetActive(false);
        //controltext++;
        changebutton.SetActive(true);
    }
    public void secondchoice()
    {
        playerchoice = 2;
        cbg2.SetActive(false);
        cbg1.SetActive(false);
     //   cbg3.SetActive(false);
        //controltext++;
        changebutton.SetActive(true);
    }
    /*
    public void thirdchoice()
    {
        playerchoice = 3;
        cbg2.SetActive(false);
        cbg1.SetActive(false);
        cbg3.SetActive(false);
        //controltext++;
        changebutton.SetActive(true);
    }
    */
    public void trapconnvo()
    {
        //ft1.SetActive(false);
        bg.SetActive(true);
        ft10.SetActive(true);
        ft11.SetActive(false);
        //conversation();
        changebutton.SetActive(true);
    }

    public void keyconnvo()
    {
        ft1.SetActive(false);
        //ft10.SetActive(false);
        bg.SetActive(true);
        ft11.SetActive(true);
        //conversation();
        changebutton.SetActive(true);
    }

    public void monsterconnvo()
    {
        ft10.SetActive(false);
        bg.SetActive(true);
        ft12.SetActive(true);
        //conversation();
        changebutton.SetActive(true);
    }
}
