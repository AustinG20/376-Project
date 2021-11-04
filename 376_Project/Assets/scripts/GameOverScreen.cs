using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void endGame(){
        Debug.Log("END GAME CALLED");
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("last floor chamber");
    }

    public void MainMenuButton(){
        //Load main menu
    }

}
