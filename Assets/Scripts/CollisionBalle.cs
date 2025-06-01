using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
//Leen Al Harash

public class CollisionBalle : MonoBehaviour {
    // Variables
    public static int balleCompteur = 0;
    public TMP_Text balleCompteurText;
    public AudioClip audioColletingItems = null; 
    public AudioClip audioShooting = null; 
    public AudioSource perso_AudioSource;

    private void Start() {
        //Initialize
        balleCompteurText.text = ":" + balleCompteur;
    }

    //Pour collecter et ajouter +1 au compteur
    private void OnTriggerEnter(Collider trigger) {
        if (trigger.CompareTag("Bullets") && trigger.gameObject.activeSelf) {
            Destroy(trigger.gameObject);
            balleCompteur++;
            balleCompteurText.text = ": " + balleCompteur;

            PlayerPrefs.SetInt("CompteurBalle", balleCompteur);
            PlayerPrefs.Save();

            //Audio pour collecter
            if (audioColletingItems != null && perso_AudioSource != null) {
                AudioSource.PlayClipAtPoint(audioColletingItems, transform.position);
            }
        }

        if (trigger.CompareTag("cowboyEnemie")) {
            cowboyEnHealth enemy = trigger.GetComponent<cowboyEnHealth>();
            if (enemy != null) {
                enemy.TakeDamage();
            }
            Destroy(gameObject);
        }
    }

    //pour diminuer le compteur
    private void Update() {
        if (Input.GetMouseButtonDown(0)) { //left mouse click
            if (balleCompteur > 0) { //only allow shooting if there are bullets left
                balleCompteur--;
                balleCompteurText.text = ":" + balleCompteur;

                PlayerPrefs.SetInt("CompteurBalle", balleCompteur);
                PlayerPrefs.Save();
            }

            //Audio pour tirer
            if (audioShooting!= null && perso_AudioSource != null) {
                AudioSource.PlayClipAtPoint(audioShooting, transform.position);
            }
        }
    }
}