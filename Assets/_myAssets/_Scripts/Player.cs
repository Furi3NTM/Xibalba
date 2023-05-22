using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{

    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _delaiMelee = 2f;
    private float _canFire = -1;

    [SerializeField] private int _viesJoueur = 3;
    [SerializeField] private int _maxVie = 100;
    private int _vie;

    [SerializeField] private GameObject _attaqueCaC = default;
    private Animator _anim;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    [SerializeField] private AudioClip _cAcSound = default;

    [SerializeField] private HpBar _hpBar;


    
    
    private void Awake()
    {

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _anim = GetComponent<Animator>();


    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, -2f, 0f);

        _vie = _maxVie;
        _hpBar.SetMaxHealth(_maxVie);
        if (_anim.GetBool("Attaque_cac") == true)
        {
            AudioSource.PlayClipAtPoint(_cAcSound, Camera.main.transform.position, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        AttackCAC();
    }

    private void AttackCAC()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            _anim.SetBool("Attaque_cac", true);


        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            _anim.SetBool("Attaque_cac", false);

        }
    }

    private void Melee()
    {
        _attaqueCaC.SetActive(true);

        Debug.Log("Melee animation triggered!");
    }

    private void stopMelee()
    {
        _attaqueCaC.SetActive(false);
        Debug.Log("Melee animation stopped!");
    }
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(direction * Time.deltaTime * _speed);






        if (horizontalInput < 0) //tourner a gauche
        {
            transform.localScale = new Vector3(3f, transform.localScale.y, transform.localScale.z);

        }
        else if (horizontalInput > 0)//tourner a droite
        {

            transform.localScale = new Vector3(-3f, transform.localScale.y, transform.localScale.z);

        }

    }


    // M�thodes publiques ==================================================================

    // M�thode appell� quand le joueur subit du d�gat
    public void Degats()
    {
        _viesJoueur--;

        if (_viesJoueur == 2)
        {
            Debug.Log("vie=2");
        }
        else if (_viesJoueur == 1)
        {
            Debug.Log("vie=1");
        }


      


        // Si le joueur n'a plus de vie on arr�te le spwan et d�truit le joueur
        if (_viesJoueur < 1)
        {
            Destroy(this.gameObject);
            Debug.Log("vie=0");


        }
    }

    //baisse la vie du player
    public void TakeDamage(int damage)
    {
        _vie -= damage;
        _hpBar.SetHealth(_vie);
        if (_vie <= 0)
        {
            Destroy(this.gameObject);

        }

    }

}
