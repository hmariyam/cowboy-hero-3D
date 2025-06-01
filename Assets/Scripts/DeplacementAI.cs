using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.AI;
using System.Drawing;
using UnityEngine.UIElements;
// Auteur : Hanfaoui Mariyam
// Script qui déplace les agents selon les points de déplacement établi dans le jeu
public class DeplacementAI : MonoBehaviour
{
    // Déclaration des variables
    public Transform[] points; // Création d'un tableau où stocker les PathPoints
    NavMeshAgent agent; // Création du NavMeshAgent, le composant qui permet de naviguer sur une zone navigable
    NavMeshSurface surface; // Création d'un NavMeshSurface
    int destinationIndex = 0;
    public Animator animator; // Création d'un animator
 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // pour récuperer l'agent
        surface = GetComponent<NavMeshSurface>(); // pour récupérer la surface
        surface.BuildNavMesh();
        if (agent != null) // vérifier si l'agent n'est pas vide
        {
            agent.destination = points[0].position; // on demande à l'agent de se diriger au point premier du tableau des points position
        }
    }
 
    void Update()
    {
        // Méthode qui permet aux agents de marcher d'un point à un autre
        #region
        // Calcule le chemin et vérifie la distance entre les points
        if (!agent.pathPending && agent.remainingDistance <= 0.1f)
        {
            // Activer l'animation de marche de l'agent
            animator.SetBool("IsWalking", true);
            // Loop à travers les points déterminé dans l'inspector du jeu pour savoir
            // la position du point prochain
            destinationIndex = (destinationIndex + 1) % points.Length;
            // Permet à l'agent de se diriger au prochain point
            agent.SetDestination(points[destinationIndex].position);
        }
        #endregion
    }
}