using System.Collections;
using Cinemachine;
using UnityEngine;

public class PlayerMovementCC : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private CinemachineImpulseSource impulseSource;


    [Header("Movement")] 
    
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float dampLength;
    
    private float damp;
    [SerializeField] private AnimationCurve dampCurve;
    private Vector3 previousDirection;



    [Header("Jumping")] 
    
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float jumpCooldown = 1.0f;

    [Header("Headbobbing")]

    [SerializeField] private float impulseFrequency = 1.0f;

    //[Header("Audio")] [SerializeField] private AudioSource jumpAudio;

    private float lastJumpTime;

    private float currentSpeed;
    private float targetSpeed;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public static bool isGrounded;
    
    //bool canDie = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FootstepsSound());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        StartCoroutine(FootstepsSound());
    }

    IEnumerator FootstepsSound()
    {
        while (true)
        {
            // Check if the player is moving and grounded to play footsteps sound
            if (isGrounded && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
            {
                impulseSource.GenerateImpulse();
            }
            yield return new WaitForSeconds(impulseFrequency);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundDistance, groundMask);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Accelerate towards the target speed
        //currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            previousDirection = move;
            damp = dampLength;
        }

        if (move == Vector3.zero && damp > 0)
        {
            characterController.Move(previousDirection.normalized * (dampCurve.Evaluate(damp) * Time.deltaTime) +
                                     Vector3.up * characterController.velocity.y * Time.deltaTime);
            damp -= Time.deltaTime;
        }
        
        



        // Check if enough time has passed since the last jump
        if (Time.time - lastJumpTime >= jumpCooldown)
        {
            Jump();
        }

        void Jump()
        {
            if (Input.GetButton("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                //this.GetComponent<AudioSource>().Play();
                //jumpAudio.Play();

                // Update the last jump time
                lastJumpTime = Time.time;
            }
        }
    }
}
