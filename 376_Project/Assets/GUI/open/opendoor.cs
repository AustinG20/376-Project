using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public GameObject button;
    public Transform leftdoor;
    public Transform rightdoor;
    //public GameObject bc;
    //public GameObject key;
    public pickupkey puk;
    public BoxCollider bc;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playa" && puk.keypick)
        {
            button.SetActive(true);
        }
    }
    public void closed()
    {
        button.SetActive(false);
        leftdoor.Rotate(0,90,0);
        rightdoor.Rotate(0,-90,0);
        Destroy(bc);
        //Debug.Log("problem here");
    }
}
