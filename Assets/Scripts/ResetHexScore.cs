using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetHexScore : MonoBehaviour
{
    public Text ScoreText;
    public int skor;

    public void ResetTheHexScore()
    {
        PlayerPrefs.SetInt("HexScore", 0);
    }
}
