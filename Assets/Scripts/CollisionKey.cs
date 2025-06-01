using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
// Auteur : Hanfaoui Mariyam
// Script qui d�sactive le collider du mur pour passer � la zone 2 � partir de 
// l'acquisition de la cl�
// Source qui m'as permis de d�sactiver un collider : https://discussions.unity.com/t/how-can-i-disable-a-specific-box-collider-of-an-object-when-my-player-walk-in-it-solved/717356/8
public class CollisionKey : MonoBehaviour
{
    // D�claration des variables
    int keyCompteurAffichage = 0;
    public static int keyCompteur = 0;
    public TMP_Text keyCompteurText;
    public Collider murCollider;

    public AudioClip audioColletingKey = null; 
    public AudioSource perso_AudioSource;

    void Start()
    {
        print(murCollider); // Ligne de d�bogage
    }

    // M�thode pour l'acquisition de la cl� et la d�sactivation du collider du mur
    #region
    private void OnTriggerEnter(Collider other)
    {
        // V�rifier si le collider comprend le tag Key pour obtenir la cl�
        if(other.CompareTag("Key") && other.gameObject.activeSelf)
        {
            print("Vous �tes rentr� en collision");
            Destroy(other.gameObject);
            keyCompteur += 1;
            keyCompteurAffichage = keyCompteur;
            // Affichage du compteur
            //keyCompteurText.text = ": " + keyCompteurAffichage; --> � d�commenter plus tard
            // Attribuer le compteur � une cl�
            PlayerPrefs.SetInt("CompteurKey", CollisionKey.keyCompteur);
            // Sauvegarder le compteur
            PlayerPrefs.Save();
            // D�sactiver le collider du mur afin que le joueur puisse passer
            murCollider.enabled = false;
        }
        
        //audio
        if (audioColletingKey != null && perso_AudioSource != null) {
            AudioSource.PlayClipAtPoint(audioColletingKey, transform.position);
        }
    }
    #endregion
}
