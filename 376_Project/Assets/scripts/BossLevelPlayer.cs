using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private bool skeletonChase;
    private bool skeletonReturn;

    private float skeletonSpeed;

    private GameObject skeleton;
    private GameObject stopAt;

    private float skeletonCounter;
    private float skeletonTime;
    private Vector3 skeletonPosition;

    private bool hasKey;

    private GameObject doorOne;
    private GameObject doorTwo;

    private GameObject finalKey;

    public AI bossAI;

    private bool isBossDead;

    private bool hasFinalKey;
    public Button keyButton;
    public GameObject keyButtonUI;

    public Button exitButton;
    public GameObject exitButtonUI;
    private GameObject secretExit;

    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        killCounter = 2f;
        hideCounter = 2f;

        swordsKill = false;
        hide = false;
        skeletonChase = false;
        skeletonReturn = false;

        skeletonTime = 5f;

        hasKey = false;
        hasFinalKey = false;

        skeleton = GameObject.Find("Skeleton");
        stopAt = GameObject.Find("triggerTwo");
    }

    // Update is called once per frame
    void Update()
    {
        isBossDead = bossAI.bossDead;
        if (swordsKill == true)
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

        if(skeletonChase == true)
        {
            skeletonSpeed = 3f;
            skeleton.transform.Translate(Vector3.right * skeletonSpeed * Time.deltaTime);
        }

        if (skeleton.transform.position.z > stopAt.transform.position.z)
        {
            skeletonChase = false;
            skeletonSpeed = 0f;
            skeletonCounter += Time.deltaTime;
            if (skeletonCounter >= skeletonTime)
            {
                skeletonReturn = true;
                skeletonCounter = 0f;
            }
        }

        if (skeletonReturn == true)
        {
            skeletonSpeed = 3f;
            skeleton.transform.Translate(Vector3.left * skeletonSpeed * Time.deltaTime);
            if (skeleton.transform.position.z <= skeletonPosition.z)
            {
                skeletonSpeed = 0f;
                skeletonReturn = false;
            }
        }

        currentHP = GameObject.Find("HP").GetComponent<Text>();
        hp = double.Parse(currentHP.text);

        if(hp <= 0)
        {
            SceneManager.LoadScene("outdoor");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            currentHP = GameObject.Find("HP").GetComponent<Text>();
            hp = double.Parse(currentHP.text);

            hp -= 2f;

            currentHP.text = hp.ToString();
        }

        if(other.gameObject.name == "triggerOne" && swordsKill == false && hide == false)
        {
            swords = GameObject.Find("Swords");
            swordsKill = true;
        }

        if (other.gameObject.name == "triggerTwo" && skeletonChase == false && skeletonReturn == false)
        {
            skeletonPosition = skeleton.transform.position;
            skeletonChase = true;
        }

        if (other.gameObject.tag == "Skeleton")
        {
            currentHP = GameObject.Find("HP").GetComponent<Text>();
            hp = double.Parse(currentHP.text);

            hp -= 10f;

            currentHP.text = hp.ToString();
        }

        if (other.gameObject.tag == "BossSword")
        {
            currentHP = GameObject.Find("HP").GetComponent<Text>();
            hp = double.Parse(currentHP.text);

            hp -= 25f;

            currentHP.text = hp.ToString();
        }

        if (other.gameObject.name == "bossRoomKey")
        {
            hasKey = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "doorTriggerOne" && hasKey == true)
        {
            doorOne = GameObject.Find("bossDoorOne");
            doorTwo = GameObject.Find("bossDoorTwo");

            Vector3 doorOnePos = new Vector3(138.76f, 83.33f, -108.5f);
            doorOne.transform.position = doorOnePos;

            Vector3 doorOneRotation = new Vector3(0, -180, 0);
            doorOne.transform.eulerAngles = doorOneRotation;

            Vector3 doorTwoPos = new Vector3(135f, 83.33f, -108.6f);
            doorTwo.transform.position = doorTwoPos;

            Vector3 doorTwoRotation = new Vector3(0, -180, 0);
            doorTwo.transform.eulerAngles = doorTwoRotation;

            hasKey = false;
        }

        if (other.gameObject.name == "chestTrigger" && isBossDead)
        {
            keyButtonUI.SetActive(true);

            keyButton.onClick.AddListener(collectKey);
        }

        if (other.gameObject.name == "exitTrigger" && hasFinalKey)
        {
            exitButtonUI.SetActive(true);

            exitButton.onClick.AddListener(collapseWall);
        }

        if (other.gameObject.name == "WinTrigger")
        {
            winScreen.SetActive(true);
        }
    }

    void collectKey()
    {
        keyButtonUI.SetActive(false);
        finalKey = GameObject.Find("finalKey");
        Destroy(finalKey);
        hasFinalKey = true;
    }

    void collapseWall()
    {
        exitButtonUI.SetActive(false);
        secretExit = GameObject.Find("SecretExit");
        Destroy(secretExit);
    }
}
