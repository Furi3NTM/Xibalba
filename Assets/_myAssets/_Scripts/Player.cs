using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{

    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _delaiMelee = 2f;

    [SerializeField] private GameObject _attaqueCaC = default;

    [SerializeField] private int _viesJoueur = 3;


    private float _canFire = -1;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, -2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            _anim.SetBool("Attaque_cac", true);

            Melee();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _anim.SetBool("Attaque_cac", false);
            _attaqueCaC.SetActive(false);

        }
    }

    private void Melee()
    {
        _canFire = Time.time + _delaiMelee;

        _attaqueCaC.SetActive(true);
        Debug.Log("Melee animation triggered!");
    }


    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(direction * Time.deltaTime * _speed);
    }




}
