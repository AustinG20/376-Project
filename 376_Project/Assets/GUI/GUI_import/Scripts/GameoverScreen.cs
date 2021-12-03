using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScreen : MonoBehaviour
{
    //public GameObject gameover;

    public void ReturnToMainMenu(){
        Time.timeScale = 1;
        //gameover.SetActive(false);
        SceneManager.LoadScene("menu"); // TODO: possibly move to next build index in queue (build settings)
    }

    public void RestartGame(){
        Time.timeScale = 1;
        //gameover.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // TODO: possibly move to next build index in queue (build settings)
    }
}
