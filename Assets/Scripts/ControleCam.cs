using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Auteurs : Leen Al Harash - Mariyam Hanfaoui

public class ControleCam : MonoBehaviour {

    // D�claration des variables
    public GameObject camFPS;
    public GameObject camTP;
    public Transform player;
    public Vector3 offset;
    private bool isFPS = true;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update() {

        // M�thode qui change de cam�ra selon si le joueur appuie sur 'C' ou pas
        if (Input.GetKeyDown(KeyCode.C)) {
            isFPS = !isFPS;
            if (isFPS) {
                ActiverCamFPS();
            } else {
                ActiverCamTP();
            }
        }
    }

    // M�thode qui active la cam�ra de troisi�me personne
    #region
    void ActiverCamTP() {
        camFPS.SetActive(false);
        camTP.SetActive(true);
    }
    #endregion

    // M�thode qui active la cam�ra FPS
    #region
    void ActiverCamFPS() {
        camTP.SetActive(false);
        camFPS.SetActive(true);
    }
    #endregion
}