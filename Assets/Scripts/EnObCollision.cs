//Leen Al Harash
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//EnObCollision - Ennemie Obstacle Collision
public class EnObCollision : MonoBehaviour {
    [SerializeField] private AudioClip audioHitScorpion = null;
    public AudioSource perso_AudioSource;
    private Rigidbody rb;

    private void Start() {
        perso_AudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    //si on touche un enemie/un obstacle on perd un coeur, si les coeurs = 0 , le cowboy meurt
    private void HandleScorpionCollision(Transform scorpionTransform) {
        PlayHitSound();
        HealthManager.health--;

        if (HealthManager.health <= 0) {
            SceneManager.LoadScene("Lose");
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Scorpions") || collision.transform.CompareTag("cowboyEnemie")) {
            HandleScorpionCollision(collision.transform);
        }
    }

    // Pour mourir directement
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Quicksand") || other.CompareTag("Tornade")){
            SceneManager.LoadScene("Lose");
        }
    }

    //sound s'il touche des obstacles/ennemies
    private void PlayHitSound() {
        if (audioHitScorpion != null && perso_AudioSource != null) {
            perso_AudioSource.PlayOneShot(audioHitScorpion);
        }
    }
}