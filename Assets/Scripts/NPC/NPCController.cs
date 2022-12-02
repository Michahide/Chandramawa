using UnityEngine;
using Yarn.Unity;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class NPCController : MonoBehaviour
{
    readonly Vector3 normalScale = new Vector3(0.1f, 0.1f, 0.1f);
    readonly Vector3 flippedScale = new Vector3(-0.1f, 0.1f, 0.1f);
    readonly Quaternion flippedRotation = new Quaternion(0, 0, 1, 0);

    [Header("Character")]
    [SerializeField] public Animator animator = null;
    [SerializeField] Transform puppet = null;
    // [SerializeField] GameObject Diary;
    // [SerializeField] GameObject optionInGame;
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

    public int animatorTalkBool;
    private int animatorRunningSpeed;

    private DialogueRunner dialogueRunner = null;

    void Start()
    {
        controllerRigidbody = GetComponent<Rigidbody2D>();

        controllerCollider = GetComponent<Collider2D>();
        softGroundMask = LayerMask.GetMask("Ground Soft");
        hardGroundMask = LayerMask.GetMask("Ground Hard");

        animatorTalkBool = Animator.StringToHash("talk");
        animatorRunningSpeed = Animator.StringToHash("speed");

        dialogueRunner = FindObjectOfType<DialogueRunner>();

    }
}
