using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] public Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int Health)
    {
        _slider.maxValue = Health;
        _slider.value = Health;
    }

    //quand prend des degats ou soigné
    public void SetHealth(int Health)
    {
        _slider.value = Health;
    }
}
