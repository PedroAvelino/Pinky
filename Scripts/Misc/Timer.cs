using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public static Timer instance = null;

    TMP_Text text;

    //[HideInInspector]
    public float time;


    public string currentTime;

    public float speed = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        } 

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        time += Time.deltaTime * speed;

        string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        string miliSeconds = (time * 1000 % 1000).ToString("000");

        currentTime = minutes + ":"+ seconds + ":" + miliSeconds;

        text.text = currentTime;
    }

    public void StopTimer()
    {
        speed = 0;

        GameManager.instance.SetHighScore(currentTime, time);
    }
}
