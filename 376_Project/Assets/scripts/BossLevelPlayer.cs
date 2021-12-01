using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLevelPlayer : MonoBehaviour
{
    private Text currentHP;
    private double hp;
    GameObject swords;

    private float counterOne;
    private float killCounter;
    private float counterTwo;
    private float hideCounter;

    private bool swordsKill;
    private bool hide;
    // Start is called before the first frame update
    void Start()
    {
        killCounter = 2f;
        hideCounter = 2f;

        swordsKill = false;
        hide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(swordsKill == true)
        {
            counterOne += Time.deltaTime;
            if(counterOne > killCounter)
            {
                swords.transform.Translate(3.8f, 0, 0);
                hide = true;
                counterOne = 0;
                swordsKill = false;
            }
        }

        if (hide == true)
        {
            counterTwo += Time.deltaTime;
            if (counterTwo >= hideCounter && hide == true)
            {
                swords.transform.Translate(-3.8f, 0, 0);
                counterTwo = 0;
                hide = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            currentHP = GameObject.Find("HP").GetComponent<Text>();
            hp = double.Parse(currentHP.text);

            hp -= 5f;

            currentHP.text = hp.ToString();
        }

        if(other.gameObject.name == "triggerOne" && swordsKill == false)
        {
            swords = GameObject.Find("Swords");
            swordsKill = true;
        }

        if (other.gameObject.name == "triggerTwo"){ 

        }
    }
}
