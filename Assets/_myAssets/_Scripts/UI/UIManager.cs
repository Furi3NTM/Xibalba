using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _txtScore = default;
    [SerializeField] private GameObject _pausePanel = default;

    private int _score =0;

    private bool _pauseOn = false;


    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _pauseOn = false;
        Time.timeScale = 1;

        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        MettreEnPause();
    }

    //gestion de pause ============
    private void MettreEnPause()
    {
        // Permet la gestion du panneau de pause (marche/arrêt)
        if ((Input.GetKeyDown(KeyCode.Escape) && !_pauseOn))
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
            _pauseOn = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && _pauseOn))
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
            _pauseOn = false;
        }
    }
    // Méthode qui relance la partie après une pause
    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _pauseOn = false;
    }

    public void ChargerDepart()
    {
        SceneManager.LoadScene(0);
    }
    //Gestion de score =====================
    public void AjouterScore(int points)
    {
        _score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        _txtScore.text = _score.ToString();
    }
    public int getScore()
    {
        return _score;
    }
}
