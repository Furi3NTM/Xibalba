using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _txtVie = default;
    [SerializeField] private TextMeshProUGUI _txtScore = default;

    private int _vie = 3;

    // Start is called before the first frame update
    void Start()
    {
        UpdateVie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gestion de vie
    private void UpdateVie()
    {
        _txtVie.text = "Vie : " + _vie.ToString();
    }
    public int getVie()
    {
        return _vie;
    }
    public void perteVie() {
        
        _vie--;
        UpdateVie();
    }

}
