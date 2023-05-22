using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinPartie : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtScore = default;
    [SerializeField] private TMP_Text _txtTemps = default;

    private GameManager _gameManager;


    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
   

        _txtScore.text = _gameManager.GetPointage().ToString();
        _txtTemps.text = _gameManager.GetTemps();

        Debug.Log(_gameManager.GetPointage().ToString());
        Debug.Log(_gameManager.GetTemps().ToString());
    }
}