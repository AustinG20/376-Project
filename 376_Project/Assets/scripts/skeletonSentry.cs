using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonSentry : MonoBehaviour
{
    private GameObject player;

    private float distance;
    private bool playerInSight;
    Vector3 lookPosition;

    public Transform firingPoint;
    public GameObject rock;
    private GameObject thrownRock;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Kevin M");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        //If less than 5f thwomp looks at mario
        if (distance < 5f)
        {
            lookPosition = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            this.transform.LookAt(lookPosition);

            thrownRock = Instantiate(rock, firingPoint);
        }
    }

    private void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        thrownRock.GetComponent<Rigidbody>().velocity = transform.right * 1f;
    }
}
