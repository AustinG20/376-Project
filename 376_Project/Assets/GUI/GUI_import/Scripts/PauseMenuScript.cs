using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// https://www.youtube.com/watch?v=JivuXdrIHK0
public class PauseMenuScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenu;
    public GameObject PlayerSound;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l")){
            if(isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume(){
        print("Resume called");
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    void Pause(){
        // fixing bug w/ footsteps sound looping if esc is pressed while walking
        PlayerSound.GetComponent<AudioSource>().Stop();
        PlayerSound.SetActive(false); 

        print("Pause called");
        PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void QuitGame(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("menu");
    }

}
