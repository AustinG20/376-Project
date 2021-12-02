using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorend : MonoBehaviour
{
    public GameObject gm;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "playa")
        {
            gm.SetActive(true);
        }
    }
}
