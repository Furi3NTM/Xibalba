using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //ATTRIBUTS
    private int _pointage = 0;
    private float _temps = 0f;


    //AWAKE
    private void Awake()
    {
        int nbGameManager = FindObjectsOfType<GameManager>().Length;

        if (nbGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
      Time.timeScale = 1;
    }


    //UPDATE
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            Destroy(gameObject);
        }
    }


    //MÉTHODES
    public void AugmenterPointage()
    {
        _pointage++;
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangerPointage(_pointage);
    }

    public int GetPointage()
    {
        return _pointage;
    }

    public string GetTemps()
    {

        _temps = Time.time;

        // Calcul du nombre de minutes et de secondes
        int minutes = Mathf.FloorToInt(_temps / 60f);
        int seconds = Mathf.FloorToInt(_temps % 60f);
        int milliseconds = Mathf.FloorToInt((_temps * 1000) % 1000f);

        string timeString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
     
        return timeString;
    }




}
