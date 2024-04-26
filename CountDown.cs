using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currentTime;
    bool gameIsOver = false;

    void Start()
    {
        // Deactivate the panel at the beginning
        panel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0 && !gameIsOver)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        if (!gameIsOver)
            GameOver();
    }

    void GameOver()
    {
        panel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    // Method to be called when game over externally (e.g., from a UI button)
    public void ForceGameOver()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            GameOver();
        }
    }
}
