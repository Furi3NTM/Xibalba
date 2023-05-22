using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public int maxHealth = 100; // Ajout de la variable de vie
                     public int damageAmount = 50;


    public int _countEnnemis;

    private bool isDestroyed = false;

    public Transform player;
    private Transform playerTransform;
    private Animator _anim;
    private UIManager _uiManager;
    private GameManager _gameManager;

    private Rigidbody2D rbEnemy;
    private Vector2 movementEnemy;

    // Variable de vie actuelle
    private int currentHealth;

    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _gameManager = FindObjectOfType<GameManager>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;


        rbEnemy = GetComponent<Rigidbody2D>();

        // Initialisation de la vie actuelle en fonction de l'ennemi
        if (gameObject.CompareTag("Thief"))
        {
            currentHealth = 50;
        }
        else if (gameObject.CompareTag("Knight"))
        {
            currentHealth = 100;
        }
        _countEnnemis = 0;
    }

    void Update()
    {

        if (isDestroyed || playerTransform == null)
            return;

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movementEnemy = direction;
        
        
    }


    private void FixedUpdate()
    {
        moveEnemy(movementEnemy);
    }

    void moveEnemy(Vector2 direction)
    {
        rbEnemy.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }



    // G�re les collisions entre les ennemis et les lasers/joueur
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Si la collision survient avec le joueur
            if (other.tag == "Player")
            {
               
                Player player = other.transform.GetComponent<Player>();
                if (this.tag == "Knight")
                {
                    player.TakeDamage(25);  // Appeler la m�thode d�gats du knight vers le joueur
                }
                else
                {
                    player.TakeDamage(20);  // Appeler la m�thode d�gats du priest et thief vers le joueur
                 }

            Destroy(this.gameObject);

            _gameManager.AugmenterPointage();
            /*_countEnnemis++;
            _uiManager.AjouterScore(_countEnnemis);*/

            Debug.Log("l'ennemi a touch� le joueur");

            }
        //collision avec l'attaque CAC    
        else if (other.tag == "attaqueCAC") 
            {
            // detruire l'ennemi
            Destroy(this.gameObject);
            _gameManager.AugmenterPointage();

           /* // Appelle la m�thode dans la classe UIManger pour augmenter le pointage
            _uiManager.AjouterScore(_countEnnemis);
             Debug.Log("attaqueCAC a touch� l'ennemi");*/

            }

        }

}