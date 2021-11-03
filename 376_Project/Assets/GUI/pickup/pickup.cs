using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject button;
    public GameObject torchdown;
    public GameObject torchup;
    public bool hastorch;

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
        torchdown.SetActive(false);
        torchup.SetActive(true);
        hastorch = true;
    }
}
