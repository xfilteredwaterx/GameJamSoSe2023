using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    // how fast the character can move
    public float maxMovementSpeed;

    // how fast the character can turn
    public float rotationSpeed;

    // How far in m the distance check work
    public float groundCheckDistance = 0.1f;

    // Influence the gravity 
    public float gravityMultiplier = 1f;

    // Component to move character
    public CharacterController characterController;

    // Cache the camera transform
    private Transform cameraTransform;    

    // How fast the charakter moves to the ground (gravity speed)
    private float ySpeed;

    public ControllScheme controllScheme;

    // Walk Particles
    public MMF_Player walkFeedback;
    public MMF_Player jumpFeedback;

    private Animator anim;
    private int speedParameterHash;
    private int isWalkingParameterHash;
    private int isAttackingParamterHash;
    // Start is called before the first frame update
    void Start()
    {
        ySpeed = 0;
        cameraTransform = Camera.main.transform;
        anim = GetComponentInChildren<Animator>();
        speedParameterHash = Animator.StringToHash("speed");
        isWalkingParameterHash = Animator.StringToHash("isMoving");
        isAttackingParamterHash = Animator.StringToHash("isAttacking");
    }

    // Update is called once per frame
    void Update()
    {
        HandleAttack();
        HandleJump();
        // Stores inputs
        float verticalInput = controllScheme.Vertical();
        float horizontalInput = controllScheme.Horizontal();

        // Create Vector from inputs
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        // Should walk? (left or right shift held)
        bool shouldWalk = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);


        // Set speed to half of input when charakter should walk
        // otherwise use horizontal input
        float speed = shouldWalk ? inputMagnitude * 0.333f : inputMagnitude;

        // to fast and not already ared as "audible"
        if (speed < 0.5f && gameObject.GetComponent<Audible>() != null)
        {
            Destroy(GetComponent<Audible>());
        }
        else if (speed >= 0.5f && gameObject.GetComponent<Audible>() == null) 
        {
            gameObject.AddComponent<Audible>();
        }

        Animations(speed, inputMagnitude);
        // Make movement direction depend on camera rotation
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up)
            * movementDirection;
        
        // Rotate the character to movement direction
        if (movementDirection != Vector3.zero)
        {
            if(!walkFeedback.IsPlaying)
            {
                walkFeedback?.PlayFeedbacks();
            }

            Quaternion targetCharacterRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetCharacterRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (walkFeedback.IsPlaying)
            {
                walkFeedback?.StopFeedbacks();
            }
        }

        movementDirection *= speed;
        // Calculate gravity
        movementDirection.y = ySpeed;


        // Move the character        
        characterController.Move(movementDirection  * maxMovementSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Check if the chracter is on ground (Perform a raycast)
    /// </summary>
    /// <returns>True if the raycasts hit smthg. in distance</returns>
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, characterController.height * 0.5f + groundCheckDistance);
    }

    /// <summary>
    /// Visualize the raycast for testing purposes
    /// </summary>
    private void OnDrawGizmos()
    {
        if(characterController!=null)
        {
            Debug.DrawRay(transform.position, Vector3.down * (characterController.height * 0.5f + groundCheckDistance), IsGrounded() ? Color.cyan : Color.red);
        }        
    }

    private void Animations(float speed,float inputMagnitude)
    {
        // Set animator isWalking parameter depending on input
        //anim.SetBool(isWalkingParameterHash, inputMagnitude > 0);

        // Set animaotr speed parameter with damping (moves the character via root motion)
        anim.SetFloat(speedParameterHash, speed, 0, Time.deltaTime);
    }

    private void HandleAttack()
    {
        anim.SetBool(isAttackingParamterHash, controllScheme.Interact());
    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpFeedback.PlayFeedbacks();
            ySpeed = 2;
        }
        ySpeed = IsGrounded() && ySpeed <= 0.2f ? ySpeed = 0 : ySpeed += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
       

    }
}
