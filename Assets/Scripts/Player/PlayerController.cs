using UnityEngine;
using Yarn.Unity;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public enum GroundType
{
    None,
    Soft,
    Hard
}

public class PlayerController : MonoBehaviour
{
    readonly Vector3 normalScale = new Vector3(0.1f, 0.1f, 0.1f);
    readonly Vector3 flippedScale = new Vector3(-0.1f, 0.1f, 0.1f);
    readonly Quaternion flippedRotation = new Quaternion(0, 0, 1, 0);

    [Header("Character")]
    [SerializeField] Animator animator = null;
    [SerializeField] Transform puppet = null;
    [SerializeField] GameObject Diary;
    [SerializeField] GameObject optionInGame;
    //[SerializeField] PlayerAudio audioPlayer = null;

    [Header("Movement")]
    [SerializeField] float acceleration = 0.0f;
    [SerializeField] float maxSpeed = 0.0f;
    [SerializeField] float jumpForce = 0.0f;
    [SerializeField] float minFlipSpeed = 0.1f;
    [SerializeField] float jumpGravityScale = 1.0f;
    [SerializeField] float fallGravityScale = 1.0f;
    [SerializeField] float groundedGravityScale = 1.0f;
    [SerializeField] bool resetSpeedOnLand = false;
    [SerializeField] public Animator anim;
    [SerializeField] public Animator animOption;
    public bool isGroundHard;

    private Rigidbody2D controllerRigidbody;
    private Collider2D controllerCollider;
    private LayerMask softGroundMask;
    private LayerMask hardGroundMask;

    private Vector2 movementInput;
    private bool jumpInput;

    private Vector2 prevVelocity;
    public GroundType groundType;
    private bool isFlipped;
    public bool isJumping;
    private bool isFalling;

    private int animatorGroundedBool;
    private int animatorRunningSpeed;

    private DialogueRunner dialogueRunner = null;

    void Start()
    {
        controllerRigidbody = GetComponent<Rigidbody2D>();

        controllerCollider = GetComponent<Collider2D>();
        softGroundMask = LayerMask.GetMask("Ground Soft");
        hardGroundMask = LayerMask.GetMask("Ground Hard");

        animatorGroundedBool = Animator.StringToHash("grounded");
        animatorRunningSpeed = Animator.StringToHash("speed");

        dialogueRunner = FindObjectOfType<DialogueRunner>();

    }

    void Update()
    {
        // Remove all player control when we're in dialogue
        if (dialogueRunner.IsDialogueRunning == true)
        {
            Debug.Log("Is Dialogue");
            return;
        }


        // Horizontal movement
        if(Diary.activeInHierarchy){DiarySummon();}

        else if (optionInGame.activeInHierarchy)
        {
            OptionInGameMenu();
        }

        else{
            float moveHorizontal = Input.GetAxis("Horizontal");

            movementInput = new Vector2(moveHorizontal, 0);
            if (!isJumping && Input.GetKeyDown(KeyCode.Space))
                jumpInput = true;
            
            DiarySummon();
            
                
                OptionInGameMenu();

            
        }
        // Jumping input

        //diary

    }

    void FixedUpdate()
    {
         
        UpdateGrounding();
        UpdateVelocity();
        UpdateDirection();
        UpdateJump();
        UpdateGravityScale();

        prevVelocity = controllerRigidbody.velocity;
    }

    private void UpdateGrounding()
    {
        // Use character collider to check if touching ground layers
        if (controllerCollider.IsTouchingLayers(softGroundMask)){
            groundType = GroundType.Soft;
            isGroundHard = false;
        }
        else if (controllerCollider.IsTouchingLayers(hardGroundMask)){
            groundType = GroundType.Hard;
                isGroundHard = true;
            }
        else{
            groundType = GroundType.None;
            isGroundHard = false;
        }

        // Update animator
        animator.SetBool(animatorGroundedBool, groundType != GroundType.None);
        animator.SetBool(animatorGroundedBool, groundType != GroundType.None);
    }

    private void UpdateVelocity()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !isFalling && !isJumping)
            controllerRigidbody.velocity = new Vector2(0.0f, controllerRigidbody.velocity.y);

        Vector2 velocity = controllerRigidbody.velocity;
        // Apply acceleration directly as we'll want to clamp
        // prior to assigning back to the body.
        velocity += movementInput * acceleration * Time.fixedDeltaTime;

        // We've consumed the movement, reset it.
        movementInput = Vector2.zero;

        // Clamp horizontal speed.
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

        // Assign back to the body.
        controllerRigidbody.velocity = velocity;

        // Update animator running speed
        var horizontalSpeedNormalized = Mathf.Abs(velocity.x) / maxSpeed;
        animator.SetFloat(animatorRunningSpeed, horizontalSpeedNormalized);

        // Play audio
        //audioPlayer.PlaySteps(groundType, horizontalSpeedNormalized);
    }

    private void UpdateJump()
    {
        // Set falling flag
        if (isJumping && controllerRigidbody.velocity.y < 0)
            isFalling = true;
            

        // Jump
        if (jumpInput && groundType != GroundType.None)
        {
            // Jump using impulse force
            controllerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            // We've consumed the jump, reset it.
            jumpInput = false;

            // Set jumping flag
            isJumping = true;

            // Play audio
            //audioPlayer.PlayJump();
        }

        // Landed
        else if (isJumping && isFalling && groundType != GroundType.None)
        {
            // Since collision with ground stops rigidbody, reset velocity
            if (resetSpeedOnLand)
            {
                prevVelocity.y = controllerRigidbody.velocity.y;
                controllerRigidbody.velocity = prevVelocity;
            }

            // Reset jumping flags
            isJumping = false;
            isFalling = false;
            

            // Play audio
            //audioPlayer.PlayLanding(groundType);
        }
    }

    private void UpdateDirection()
    {
        // Use scale to flip character depending on direction
        if (controllerRigidbody.velocity.x > minFlipSpeed && isFlipped)
        {
            isFlipped = false;
            puppet.localScale = normalScale;
        }
        else if (controllerRigidbody.velocity.x < -minFlipSpeed && !isFlipped)
        {
            isFlipped = true;
            puppet.localScale = flippedScale;
        }
    }

    private void UpdateGravityScale()
    {
        // Use grounded gravity scale by default.
        var gravityScale = groundedGravityScale;

        if (groundType == GroundType.None)
        {
            // If not grounded then set the gravity scale according to upwards (jump) or downwards (falling) motion.
            gravityScale = controllerRigidbody.velocity.y > 0.0f && Input.GetKey(KeyCode.Space) ? jumpGravityScale : fallGravityScale;
        }

        controllerRigidbody.gravityScale = gravityScale;
    }

    IEnumerator DiaryClose(){
        anim.SetTrigger("DiaryClose");
        yield return new WaitForSeconds(0.8f);
        
        Diary.SetActive(false);

    }
    IEnumerator OptionClose(){
        animOption.SetTrigger("DiaryClose");
        yield return new WaitForSeconds(0.8f);
        
        optionInGame.SetActive(false);

    }

    public void OptionInGameMenu(){
      if (Input.GetKeyDown(KeyCode.Escape) && !optionInGame.activeInHierarchy)
        {
            optionInGame.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && optionInGame.activeInHierarchy)
        {
            StartCoroutine(OptionClose());

        }  
    }
    public void DiarySummon(){
        if (Input.GetKeyDown(KeyCode.Tab) && !Diary.activeInHierarchy)
            {
                Diary.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Tab) && Diary.activeInHierarchy){

               StartCoroutine(DiaryClose());
            }
    }
}
