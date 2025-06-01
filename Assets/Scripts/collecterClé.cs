using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Leen Al Harash

public class collecterClé : MonoBehaviour {
    public AudioClip audioColletingKey = null; 
    public AudioSource perso_AudioSource;

    //Audio
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Key")) {
            if (audioColletingKey != null && perso_AudioSource != null) {
                AudioSource.PlayClipAtPoint(audioColletingKey, transform.position);
            }
        }
    }
}
