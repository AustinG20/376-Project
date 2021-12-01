using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    public Text TimerText;
    public static float GlobalTime = 0;
    public static float LevelTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes(), Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        LevelTime += Time.deltaTime;
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes(), Seconds());
    }

    float Minutes(){
        return Mathf.FloorToInt(LevelTime / 60);
    }

    float Seconds(){
        return Mathf.FloorToInt(LevelTime % 60);
    }

    public static void NextLevel(){
        GlobalTime += LevelTime;
        LevelTime = 0;
        print("AFTER NEXT LEVEL TIMER SCRIPT");
        print("Global time = " + GlobalTime);
        print("Level time = " + LevelTime);
    }
}
