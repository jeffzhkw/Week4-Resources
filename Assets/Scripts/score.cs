using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class score : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        scoreText.text = "Score: " + PlayerController.score.ToString();
    }

}
