using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Auteur : Hanfaoui Mariyam
// Script qui ouvre le coffre en appuyant sur E
// Vid�o source qui m'as aid� : https://www.youtube.com/watch?v=90vVwpNFppw
public class InteractionCloture : MonoBehaviour
{
    // D�claration des variables
    public GameObject Instruction; // Instruction pour le collider
    public GameObject InstructionView; // Box de collision qui affiche les instructions
    public bool Action = false;

    // On cache l'instruction et le coffre ouvert au d�but
    void Start()
    {
        Instruction.SetActive(false);
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
        if (CollisionKey.keyCompteur > 0)
        {
            Instruction.SetActive(false);
            Action = false;
        }
    }
    #endregion
}

