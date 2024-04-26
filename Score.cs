using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    [SerializeField] private Text scoreText;
     public static int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
