using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScreen : MonoBehaviour
{
    public void ReturnToMainMenu(){
        SceneManager.LoadScene("menu"); // TODO: possibly move to next build index in queue (build settings)
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // TODO: possibly move to next build index in queue (build settings)
    }
}
