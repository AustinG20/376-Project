using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class openchestFloorTwo : MonoBehaviour
{
    public GameObject button;
    public GameObject buttonTwo;
    public GameObject ochest;
    public GameObject cchest;
    public GameObject bc;
    public GameObject key;
    public GameObject keyIndicator;

    public bool hasKey;

    void Start()
    {
        hasKey = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playa")
        {
            button.SetActive(true);
            button.GetComponent<Button>().onClick.AddListener(closed);
        }

    }
    private void closed()
    {
        bc.SetActive(false);
        button.SetActive(false);
        cchest.SetActive(false);
        ochest.SetActive(true);
        key.SetActive(true);
        buttonTwo.SetActive(true);
        buttonTwo.GetComponent<Button>().onClick.AddListener(getKey);

    }

    private void getKey()
    {
        key.SetActive(false);
        buttonTwo.SetActive(false);
        hasKey = true;
        keyIndicator.SetActive(true);
        button.SetActive(false);
    }
}
