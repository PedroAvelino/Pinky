using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject homer;
    public Vector3 spawnPosition;

    public GameObject resultsPanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }

        

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }


   void SetPlayerPosition()
    {
        homer = FindObjectOfType<Homer>().gameObject;
        homer.transform.position = spawnPosition;
    }

    // Talvez de problema
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(resultsPanel == null)
            resultsPanel = GameObject.Find("WinScreen");
        
        
        resultsPanel.SetActive(false);


        if (homer == null)
        {
            homer = FindObjectOfType<Homer>().gameObject;
        }

    }

    public void Death()
    {
        homer.transform.position = spawnPosition;
    }

    public void Goal()
    {
        homer.GetComponent<Homer>().enabled = false;
        ShowResults();
    }

    public void SetHighScore(string score, float time)
    {
        if (time < PlayerPrefs.GetFloat("TimeSpent", 10000))
        {

            PlayerPrefs.SetFloat("TimeSpent", time);
            PlayerPrefs.SetString("HighScore", score);
        }
    }

    void ShowResults()
    {
        resultsPanel.SetActive(true);
    }

    
}
