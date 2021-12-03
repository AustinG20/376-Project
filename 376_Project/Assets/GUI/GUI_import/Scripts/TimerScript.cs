using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    public Text TimerText;
    public static float GlobalTime = 0;
    public static float LevelTime = 450;

    public GameObject gameover;


    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes(), Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        LevelTime -= Time.deltaTime;
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes(), Seconds());

        if(LevelTime <= 0.0f)
        {
            Time.timeScale = 0;
            LevelTime = 450;
            gameover.SetActive(true);
        }
    }

    float Minutes(){
        return Mathf.FloorToInt(LevelTime / 60);
    }

    float Seconds(){
        return Mathf.FloorToInt(LevelTime % 60);
    }


    public static void NextLevel(int levelnum){

        Debug.Log("Time");
    }
}
