using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Auteur : Hanfaoui Mariyam
// Script qui met le jeu en pause ou en continue
// Vid�os utilis� : https://youtu.be/G1AQxNAQV8g, https://www.youtube.com/watch?v=qjgZTVEUqgo

public class ControleJeu : MonoBehaviour
{
    // D�claration des variables
    public GameObject pauseMenu;
    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // M�thode qui v�rifie si le bouton Escape a �t� appuyer
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Continuer();
            }
            else
            {
                Pause();
            }
        }
    }

    // M�thode qui fait pause au jeu
    #region
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        // Afficher le curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion

    // M�thode qui continue le jeu
    #region
    public void Continuer()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        // D�sactiver le curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion

    // M�thode qui affiche le menu
    #region
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    #endregion
}