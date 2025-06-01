using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Auteur : Hanfaoui Mariyam
// Script qui ouvre le coffre en appuyant sur E
// Vidéo source qui m'as aidé  : https://www.youtube.com/watch?v=90vVwpNFppw
public class InteractionCoffre2 : MonoBehaviour
{
    // D claration des variables
    public GameObject Instruction; // Instruction pour le coffre
    public GameObject Instruction2; // Instruction pour le pistolet/bouteille d'eau
    public GameObject CoffreOuvert;
    public GameObject CoffreFermer;
    public GameObject InstructionView; // Box de collision qui affiche les instructions
    public GameObject Bouteille;
    public bool Action = false;
    public bool Action2 = false;
    public Collider boxCollider;

    // On cache l'instruction et le coffre ouvert au d but
    void Start()
    {
        Instruction.SetActive(false);
        Instruction2.SetActive(false);
        CoffreOuvert.SetActive(false);
    }

    // Lorsque le joueur rentre dans la zone de collision établi autour
    // du coffre, l'instruction apparait
    #region
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "MainPlayer")
        {
            Instruction.SetActive(true);
            Action = true;
            Action2 = true;
            boxCollider.enabled = false;
        }
    }
    #endregion

    // Lorsqu'il sort, l'instruction disparait
    #region
    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }
    #endregion

    // Méthode qui permet d'ouvrir le coffre lorsque le joueur appuie sur la touche 'X'
    // et pour prendre le pistolet lorsque le joueur appuie sur la touche 'T'
    #region
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Action == true)
            {
                Instruction.SetActive(false);
                CoffreFermer.SetActive(false);
                Action = false;
                CoffreOuvert.SetActive(true);
                Instruction2.SetActive(true);
            }
        }

        // Méthode pour prendre la bouteille du coffre ouvert
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Action2 == true)
            {
                Instruction2.SetActive(false);
                Bouteille.SetActive(false);
                Action2 = false;
                InstructionView.SetActive(false); // Désactiver l'instructionView pour éviter de voir la premi re instruction
                SceneManager.LoadSceneAsync(2); // Démarrer la scène de victoire

            }
        }
    }
    #endregion
}