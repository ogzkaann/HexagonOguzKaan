using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text ScoreText;
    public int skor;

    void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        skor = PlayerPrefs.GetInt("HexScore");
        ScoreText.text = "Score: " + skor;
    }
}
