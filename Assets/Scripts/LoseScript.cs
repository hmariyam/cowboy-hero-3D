using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
// Leen Al Harash

public class LoseScript : MonoBehaviour {
    public void Start(){
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RePlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void ReturnToMenu(){
        SceneManager.LoadSceneAsync(0);
    }
}