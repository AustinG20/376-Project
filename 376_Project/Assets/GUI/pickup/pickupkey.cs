using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupkey : MonoBehaviour
{
    public GameObject button;
    public GameObject key;
    public GameObject keyIndicator;
    public bool keypick = false;
    public firstfloorconvo ffc;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "playa")
        {
            button.SetActive(true);
        }
    }
    public void closed()
    {
        button.SetActive(false);
        key.SetActive(false);
        keyIndicator.SetActive(true);
        keypick = true;
        ffc.keyconnvo();
    }
}
