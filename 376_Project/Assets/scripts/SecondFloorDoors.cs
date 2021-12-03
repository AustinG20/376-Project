using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloorDoors : MonoBehaviour
{
    public openchestFloorTwo script;

    public GameObject doorOne;
    public GameObject doorTwo;
    public GameObject keyIndicator;
    private bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hasKey = script.hasKey;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playa" && hasKey)
        {
            Vector3 doorOneRotation = new Vector3(0, 0, 0);
            doorOne.transform.eulerAngles = doorOneRotation;

            Vector3 doorTwoRotation = new Vector3(0, -180, 0);
            doorTwo.transform.eulerAngles = doorTwoRotation;

            keyIndicator.SetActive(false);
        }
    }
}
