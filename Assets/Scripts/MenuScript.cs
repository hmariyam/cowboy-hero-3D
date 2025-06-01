using UnityEngine;
using UnityEngine.SceneManagement; 
//Leen Al Harash

public class MenuScript : MonoBehaviour {
    public void Start(){
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}