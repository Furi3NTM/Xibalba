using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinPartie : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _txtScore = default;
    private int _score;


    // Start is called before the first frame update
    void Start()
    {

        _txtScore.text = _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
