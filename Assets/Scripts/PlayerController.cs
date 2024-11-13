using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Variable to keep track of collected "PickUp" objects.
    private int count;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 0;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;

    // UI object to display winning text.
    public GameObject winTextObject;
    public GameObject GameOverTextObject;
    public AudioSource audioSource;

    public AudioClip klax;
    public AudioClip klaxo;


    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        

        // Initialize count to zero.
        count = 0;

        // Update the count display.
        SetCountText();

        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
        GameOverTextObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }



    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "Collectible" tag.
        if (other.gameObject.CompareTag("Collectible"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

            // Increment the count of "PickUp" objects collected.
            count = count + 1;

            // Update the count display.
            SetCountText();

        }

        if (other.gameObject.CompareTag("BoostCollectible"))
        {
            other.gameObject.SetActive(false);

            // Increment the count of "PickUp" objects collected.
            count = count + 2;

            // Update the count display.
            SetCountText();
            audioSource.PlayOneShot(klax);

        }


        if (other.gameObject.CompareTag("DecreaseCollectible"))
        {
            other.gameObject.SetActive(false);

            // Increment the count of "PickUp" objects collected.
            count = count - 1;

            // Update the count display.
            SetCountText();
            audioSource.PlayOneShot(klaxo);
        }

        //klax
    }


    void SetCountText()

    {

        // Update the count text with the current count.

        countText.text = "Count: " + count.ToString();



        // Check if the count has reached or exceeded the win condition.

        if (count >= 5)

        {

            // Display the win text and stop the game

            winTextObject.SetActive(true);

            // Add code here to stop the game, e.g., pause the game or transition to a game over screen
            Time.timeScale = 0;

        }

        

    }
}
