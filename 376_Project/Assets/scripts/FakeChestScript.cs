using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeChestScript : MonoBehaviour
{
    public GameObject button;
    public GameObject ochest;
    public GameObject cchest;
    public GameObject bc;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playa")
        {
            button.SetActive(true);
            button.GetComponent<Button>().onClick.AddListener(fakeClosed);
        }

    }
    private void fakeClosed()
    {
        button.SetActive(false);
        cchest.SetActive(false);
        ochest.SetActive(true);
        bc.SetActive(false);
    }
}