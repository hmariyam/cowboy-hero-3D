using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

// Auteur : Leen Al Harash
public class SuivreJoueur : MonoBehaviour {
    private GameObject player;
    NavMeshAgent agent;
    NavMeshSurface surface;
    Bounds bakeBounds;
    public Animator animator;

    void Start() {
        player = GameObject.FindGameObjectWithTag("MainPlayer");
        agent = GetComponent<NavMeshAgent>();
        surface = GetComponent<NavMeshSurface>();
        //acces a la zone de bake des obstacles
        bakeBounds = surface.navMeshData.sourceBounds;
    }

    //movement d'agent
    private void Update() {
        if (bakeBounds.Contains(player.transform.position)) {
            Debug.Log("L'agent ne vous suit pas");
        } else {
            agent.SetDestination(player.transform.position);
            animator.SetBool("IsWalking", true);
        }
    }
}