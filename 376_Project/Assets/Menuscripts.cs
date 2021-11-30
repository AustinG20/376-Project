using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menuscripts : MonoBehaviour
{   
    public GameObject mainMenu, optionsMenu;
    public AudioMixer audioMixer;

    public void PlayGame(){
        SceneManager.LoadScene("last floor chamber"); // TODO: possibly move to next build index in queue (build settings)
    }

    public void OpenOptions(){
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackButton(){
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SetVolume(float volume){
        // print("Volume:" + volume);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}
