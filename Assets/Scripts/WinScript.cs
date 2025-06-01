using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
//Leen Al Harash

public class WinScript : MonoBehaviour {    
    public void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReStartGame(){
        //initialisation de compteur
        CollisionBalle.balleCompteur = 0;
        SceneManager.LoadSceneAsync(1);
    }
    
    public void QuitGame(){
        Application.Quit();
    }
}