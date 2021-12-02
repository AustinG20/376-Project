using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CinematicEffects;

public class fearfactor : MonoBehaviour
{
    public LensAberrations la;
    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        la.vignette.intensity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(la.vignette.intensity <= -3.0f)
        {
            gameover.SetActive(true);
        }
    }

    public void scarred(float fear)
    {
        la.vignette.intensity -= fear;
    }
}
