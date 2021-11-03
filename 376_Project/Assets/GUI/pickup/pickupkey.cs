using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupkey : MonoBehaviour
{
    public GameObject button;
    public GameObject key;
    public bool keypick = false;

    public void OnTriggerEnter(Collider other)
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
        keypick = true;
    }
}
