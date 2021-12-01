using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    public Text TimerText;
    public static float GlobalTime = 0;
    public static float LevelTime = 0;
    public static float StartLevelTime = 200;
    public static float middleLevelTime = 400;
    public static float finalLevelTime = 600;

    // Start is called before the first frame update
    void Start()
    {
        LevelTime = StartLevelTime;
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes(), Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        LevelTime -= Time.deltaTime;
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes(), Seconds());
    }

    float Minutes(){
        return Mathf.FloorToInt(LevelTime / 60);
    }

    float Seconds(){
        return Mathf.FloorToInt(LevelTime % 60);
    }

    public static void NextLevel(int levelnum){

        switch (levelnum)
        {
            case 1:
                GlobalTime += (StartLevelTime - LevelTime);
                LevelTime = StartLevelTime;
                break;
            case 2:
                GlobalTime += (middleLevelTime - LevelTime);
                LevelTime = middleLevelTime;
                break;
            case 3:
                GlobalTime += (finalLevelTime - LevelTime);
                LevelTime = finalLevelTime;
                break;
        }
        /*
        GlobalTime += (StartLevelTime - LevelTime);
        LevelTime = StartLevelTime;
        print("AFTER NEXT LEVEL TIMER SCRIPT");
        print("Global time = " + GlobalTime);
        print("Level time = " + LevelTime);
        */
    }
}
