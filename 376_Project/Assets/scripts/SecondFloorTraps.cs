using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloorTraps : MonoBehaviour
{
    public fearfactor ff;

    private GameObject gargoyleOne;
    private GameObject gargoyleTwo;
    private GameObject gargoyleThree;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "statueTrigger")
        {
            ff.scarred(0.5f);
            GameObject statueTrigger;
            statueTrigger = GameObject.Find("statueTrigger");
            statueTrigger.SetActive(false);
        }

        if (other.gameObject.tag == "Sword")
        {
            ff.scarred(0.25f);
        }

        if (other.gameObject.name == "gargoyleTrigger")
        {
            ff.scarred(0.5f);

            gargoyleOne = GameObject.Find("gargoyleOne");
            gargoyleTwo = GameObject.Find("gargoyleTwo");
            gargoyleThree = GameObject.Find("gargoyleThree");

            Vector3 gargoyleOnePos = new Vector3(-45.59f, 1.7f, 13.626f);
            gargoyleOne.transform.position = gargoyleOnePos;

            Vector3 gargoyleOneRotation = new Vector3(0, -180, -90);
            gargoyleOne.transform.eulerAngles = gargoyleOneRotation;

            Vector3 gargoyleTwoPos = new Vector3(-48f, 1.45f, 6.06f);
            gargoyleTwo.transform.position = gargoyleTwoPos;

            Vector3 gargoyleTwoRotation = new Vector3(0, 0, -90);
            gargoyleTwo.transform.eulerAngles = gargoyleTwoRotation;

            Vector3 gargoyleThreePos = new Vector3(-45.49f, 1.6f, 0.72f);
            gargoyleThree.transform.position = gargoyleThreePos;

            Vector3 gargoyleThreeRotation = new Vector3(0, -180, -90);
            gargoyleThree.transform.eulerAngles = gargoyleThreeRotation;

        }
    }
}
