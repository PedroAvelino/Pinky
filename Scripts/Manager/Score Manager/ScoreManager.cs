using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text currentTime;
    public TMP_Text bestTime;


    public void Update()
    {
        currentTime.text = "Time: " + Timer.instance.currentTime;
        bestTime.text = "Best Time: " + PlayerPrefs.GetString("HighScore", "");
    }
}
