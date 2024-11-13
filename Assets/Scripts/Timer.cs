using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]  TextMeshProUGUI timerText;
    [SerializeField]  float remainingTime;
    GameObject GameOverTextObject;
    public GameObject gameoverTextObject;


    // Update is called once per frame
    void Update()
    {
        // Update the timer

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            // Trigger game over

            

            

                // Display the win text and stop the game

            gameoverTextObject.SetActive(true);
            Time.timeScale = 0;

                // Add code here to stop the game, e.g., pause the game or transition to a game over screen

            
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes,
 seconds);
    }
}