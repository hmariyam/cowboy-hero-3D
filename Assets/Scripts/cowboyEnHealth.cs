using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Leen Al Harash

//pour diminuer les counter d'ennemies
public class cowboyEnHealth : MonoBehaviour {
    public int health = 1;

    public void TakeDamage() {
        health--;
        Debug.Log("Enemy hit! Remaining health: " + health);

        if (health <= 0) {
            cowboyEnManager.DecreaseEnemyCount(); //update UI
            Destroy(gameObject);
        }
    }
}
