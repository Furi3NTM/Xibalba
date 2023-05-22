using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{

    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _delaiMelee = 2f;
  
    [SerializeField] private int _viesJoueur = 3;
    [SerializeField] private int _maxVie = 100;
    [SerializeField] private HpBar _hpBar;
    private int _vie;

    [SerializeField] private GameObject _attaqueCaC = default;
    [SerializeField] private AudioClip _cAcSound = default;

    private Animator _anim;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    private GestionScene _gestionScene;
   

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
    }

    private void stopMelee()
    {
        _attaqueCaC.SetActive(false);
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

 
    //baisse la vie du player
    public void TakeDamage(int damage)
    {
        _vie -= damage;
        _hpBar.SetHealth(_vie);
        if (_vie <= 0)
        {
            Destroy(this.gameObject);
            int noScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(noScene + 1);
        }

    }

}
