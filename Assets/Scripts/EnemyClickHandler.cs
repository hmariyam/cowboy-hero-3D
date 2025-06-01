using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClickHandler : MonoBehaviour {
    void Update() {
        if (Input.GetMouseButtonDown(0)) { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                cowboyEnHealth enemy = hit.collider.GetComponent<cowboyEnHealth>();
                if (enemy != null) {
                    enemy.TakeDamage();
                }
            }
        }
    }
}
