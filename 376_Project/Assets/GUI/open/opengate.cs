using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class opengate : MonoBehaviour
{
    public GameObject button;
   // public pickupkey puk;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playa")
        {
            button.SetActive(true);
        }
    }
    public void open()
    {
        button.SetActive(false);
        SceneManager.LoadScene("lock_picking");
    }
}
