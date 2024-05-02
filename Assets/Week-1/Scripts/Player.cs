using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotation = 5.0f;
    [SerializeField] float jumpForce = 10f;
    int Score;
    float Accuracy;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI AccuracyText; 

    public PlayerControls playerControls;
    [SerializeField] GameObject bulletPrefab;

    private float mouseDeltaX = 0f;
    private float mouseDeltaY = 0f;
    private float cameraRotX = 0f;
    private int rotDir = 0;
    private bool grounded;

    private InputAction move;
    private InputAction look;
    private InputAction jump;
    private InputAction fire;

    Rigidbody rb;

    [SerializeField] AudioSource SoundSource;
    [SerializeField] AudioClip BulletShotClip;
    [SerializeField] AudioClip TargetHitClip;

    private void Awake()
    {
        playerControls = new PlayerControls();

        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        move = playerControls.Player.Move;
        jump = playerControls.Player.Jump;
        look = playerControls.Player.Look;
        fire = playerControls.Player.Fire;

        Score = PlayerPrefs.GetInt("SCORE", 0);
        Accuracy = PlayerPrefs.GetFloat("ACCURACY", 0);

        ScoreText.text = $"Score: {Score}";
        AccuracyText.text = $"Accuracy: {Accuracy * 100: 0.0}%";
    }

    private void OnEnable()
    {       
        move.Enable();
        look.Enable();

        fire.Enable();
        fire.performed += Fire;

        jump.Enable();
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        look.Disable();
        fire.Disable();
    }


    private void Update()
    {
        HandleHorizontalRotation();
        HandleVerticalRotation();
    }

    private void FixedUpdate()
    {
        grounded = IsGrounded();

        HandleMovement();
    }

    public void UpdateScore(int score)
    {
        Score += score;
        //update score text on screen
        ScoreText.text = $"Score: {Score}";
        //saving to player prefs so the score will stay between multiple levels
        PlayerPrefs.SetInt("SCORE", Score);
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("HIT SHOTS", PlayerPrefs.GetInt("HIT SHOTS", 0) + 1);
        CalculateAccuracy();

        SoundSource.PlayOneShot(TargetHitClip);
    }

    void CalculateAccuracy()
    {
        Accuracy = (float)PlayerPrefs.GetInt("HIT SHOTS", 0) / (float)PlayerPrefs.GetInt("SHOTS FIRED", 0);
        AccuracyText.text = $"Accuracy: {Accuracy * 100 : 0.0}%";
        PlayerPrefs.SetFloat("ACCURACY", Accuracy);
        PlayerPrefs.Save();
    }

    void HandleMovement()
    {
        if (grounded == false) return;

        Vector2 axis = move.ReadValue<Vector2>();

        Vector3 input = (axis.x * transform.right) + (transform.forward * axis.y);

        input *= speed;

        rb.velocity = new Vector3(input.x, rb.velocity.y, input.z);
    }

    bool IsGrounded()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 3;

        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * hit.distance, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            return false;
        }
    }

    void HandleHorizontalRotation()
    {

        mouseDeltaX = look.ReadValue<Vector2>().x;

        if (mouseDeltaX != 0)
        {
            rotDir = mouseDeltaX > 0 ? 1 : -1;

            transform.eulerAngles += new Vector3(0, rotation * Time.deltaTime * rotDir, 0);
        }
    }

    void HandleVerticalRotation()
    {
        mouseDeltaY = look.ReadValue<Vector2>().y;

        if (mouseDeltaY != 0)
        {
            rotDir = mouseDeltaY > 0 ? -1 : 1;

            cameraRotX += rotation * Time.deltaTime * rotDir;
            cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);

            var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);

            Camera.main.transform.localRotation = targetRotation;

        }
    }

    void Jump(InputAction.CallbackContext context)
    {
        if (grounded == false) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Fire(InputAction.CallbackContext context) 
    {
        //Instantiate(bulletPrefab, transform.position, Camera.main.transform.rotation);
        Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
            Camera.main.transform.rotation);

        //play sound effect
        SoundSource.PlayOneShot(BulletShotClip);

        PlayerPrefs.SetInt("SHOTS FIRED", PlayerPrefs.GetInt("SHOTS FIRED", 0) + 1);
        CalculateAccuracy();
    }
}
