using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _txtScore = default;
    [SerializeField] private TextMeshProUGUI _txtTimer = default;
    [SerializeField] private GameObject _pausePanel = default;
    [SerializeField] public AudioSource audioSource;

    [SerializeField] public Image muteButtonImage;
    [SerializeField] public Sprite muteSprite;
    [SerializeField] public Sprite unmuteSprite;
    private bool isMuted;

    private int _score =0;
    private float _tempsEcoule = 0f;

    private bool _pauseOn = false;


    // Start is called before the first frame update
    void Start()
    {
        _score = getScore();
        _pauseOn = false;
        Time.timeScale = 1;
        UpdateScore();

        isMuted = audioSource.mute;


    }

    // Update is called once per frame
    void Update()
    {
        MettreEnPause();
        UpdateTime();

    }

    //gestion de pause ============
    private void MettreEnPause()
    {
        // Permet la gestion du panneau de pause (marche/arr�t)
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

    // M�thode qui relance la partie apr�s une pause
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

    public void ChangerPointage(int p_pointage)
    {
        _txtScore.text = p_pointage.ToString();
    }

    //Gestion temps =====================

    private void UpdateTime()
    {

        _tempsEcoule += Time.deltaTime;

        // Calcul du nombre de minutes et de secondes
        int minutes = Mathf.FloorToInt(_tempsEcoule / 60f);
        int seconds = Mathf.FloorToInt(_tempsEcoule % 60f);
        int milliseconds = Mathf.FloorToInt((_tempsEcoule * 1000) % 1000f);

        // Formatage de la chaîne de temps
        string timeString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        _txtTimer.text = timeString;

    }


    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        // Modifier l'image du bouton en fonction de l'état de sourdine
        muteButtonImage.sprite = isMuted ? muteSprite : unmuteSprite;
    }

}
