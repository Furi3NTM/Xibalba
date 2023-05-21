using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _txtScore = default;

    private int _score =0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gestion de score
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
