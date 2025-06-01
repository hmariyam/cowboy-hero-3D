using static Cinemachine.CinemachineImpulseManager.ImpulseEvent;
using UnityEngine;
using System.Collections;
// Auteur : Hanfaoui Mariyam et Leen Al Harash
// Script qui effectue le déplacement et le saut du joueur
// Source du raffinement de la méthode Grounded() : https://stackoverflow.com/questions/77836782/why-is-my-character-stuck-in-the-jump-animation
// Source qui raffine la méthode de saut : https://stackoverflow.com/questions/62391105/how-to-add-jump-in-c-sharp-script-in-unity3d-using-character-controller
public class PlayerController : MonoBehaviour
{
    // Déclaration des variables
    public CharacterController characterController;
    public Animator animator;
    public float vitesse = 5f;
    public float gravity;
    float vitesseRotation = 700f;
    public float jumpForce = 8f;
    private Vector3 directionMove;
    public LayerMask groundLayer;
    public float raycastDistance = 0.6f;
    private bool isGrounded;
    private bool isJumping;
    private Camera mainCamera;
 
    private void Start()
    {
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
 
        // Appliquer de la gravité au tout début pour éviter que le personnage
        // ne soit pas sur le sol
        gravity = -20f;
 
        // Bloquer la souris
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Bloquer la souris
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    void Update()
    {
        // Méthode de déplacement du personnage
        #region
        // Récupère les entrées de déplacement (axe horizontal et vertical)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
 
        // Crée un vecteur de direction basé sur les entrées du joueur
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
 
        // Si le joueur se déplace
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("IsMoving", true);
            // Rotation du joueur en fonction de la direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
 
            // Rotation du joueur vers la direction désirée
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, vitesseRotation * Time.deltaTime);
 
            // Déplacement du joueur
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            transform.Translate(moveDirection * vitesse * Time.deltaTime, Space.World);
        } else {
            animator.SetBool("IsMoving", false);
        }
 
        // Effectuer le déplacement du personnage
        characterController.Move(directionMove * Time.deltaTime);
        #endregion
 
        // Appel de la méthode Grounded dans le boolean isGrounded
        isGrounded = Grounded();
 
        // Gestion du saut
        #region
        // Vérifier si le personnage est sur le sol
        if (isGrounded && directionMove.y < 0)
        {
 
            isJumping = false;
            animator.SetBool("IsJumping", false);
 
            // Pour rester sur le sol
            directionMove.y = -2f;
 
        }
 
        // Vérifie si la barre d'espace est enfoncé qui permet au joueur du sauter
        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            animator.SetBool("IsJumping", true);
            isJumping = true;
            directionMove.y = jumpForce;
        } else
        {
            animator.SetBool("IsJumping", false);
        }
 
        // Appliquer de la gravité sur le personnage
        directionMove.y += gravity * Time.deltaTime;
        #endregion
    }
 
    // Méthode qui vérifie si le personnage est sur le sol ==> Méthode de Leen
    #region
    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1f, groundLayer);
    }
    #endregion
}