using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openchest : MonoBehaviour
{
    public GameObject button;
    public GameObject ochest;
    public GameObject cchest;
    public GameObject bc;
    public GameObject key;

    public firstfloorconvo ffc;

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
        cchest.SetActive(false);
        ochest.SetActive(true);
        bc.SetActive(false);
        key.SetActive(true);
        ffc.camera1.SetActive(false);
        ffc.camera2.SetActive(true);
        ffc.bg.SetActive(true);
        ffc.controltext++;
    }
}
