using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Auteur : Hanfaoui Mariyam
// Script qui ouvre le coffre en appuyant sur E
// Vid�o source qui m'as aid� : https://www.youtube.com/watch?v=90vVwpNFppw
public class InteractionCoffre : MonoBehaviour
{
    // D�claration des variables
    public GameObject Instruction; // Instruction pour le coffre
    public GameObject Instruction2; // Instruction pour le pistolet/bouteille d'eau
    public GameObject CoffreOuvert;
    public GameObject CoffreFermer;
    public GameObject InstructionView; // Box de collision qui affiche les instructions
    public GameObject Pistolet;
    public GameObject Pistolet2;
    public bool Action = false;
    public bool Action2 = false;
    public Collider boxCollider;

    // On cache l'instruction et le coffre ouvert au d�but
    void Start()
    {
        Instruction.SetActive(false);
        Instruction2.SetActive(false);
        CoffreOuvert.SetActive(false);
        Pistolet2.SetActive(false);
    }

    // Lorsque le joueur rentre dans la zone de collision �tabli autour
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

    // M�thode qui permet d'ouvrir le coffre lorsque le joueur appuie sur la touche 'X'
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

        // M�thode pour prendre le pistolet du coffre ouvert
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Action2 == true)
            {
                Instruction2.SetActive(false);
                Pistolet.SetActive(false);
                Action2 = false;
                InstructionView.SetActive(false); // D�sactiver l'instructionView pour �viter de voir la premi�re instruction
                Pistolet2.SetActive(true); // Cowboy tiens le pistolet

            }
        }
    }
    #endregion
}