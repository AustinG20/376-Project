using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CinematicEffects;

public class fearfactor : MonoBehaviour
{
    public LensAberrations la;
    public GameObject EndGameBackground;
    public GameOverScreen gs;
    private const float FFMAX = -1.5f;
    // Start is called before the first frame update
    void Start()
    {
        la.vignette.intensity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scarred(float fear)
    {
        la.vignette.intensity -= fear;
        
        if(la.vignette.intensity <= FFMAX){
            // EndGameBackground.GetComponent<GameOverScreen>().endGame();
            gs.endGame();
        }
    }
}
