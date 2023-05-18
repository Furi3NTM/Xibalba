using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public int maxHealth = 100; // Ajout de la variable de vie
                     public int damageAmount = 50;

    public Transform player;

    private Rigidbody2D rbEnemy;
    private Vector2 movementEnemy;

    // Variable de vie actuelle
    private int currentHealth;

    void Start()
    {
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
    }

    void Update()
    {
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

    // Méthode pour infliger des dégâts à l'ennemi
    public void TakeDamage()
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Méthode appelée lorsque l'ennemi meurt
    void Die()
    {
        // Ajoutez ici le code pour détruire l'ennemi, jouer une animation, etc.
        Destroy(gameObject);
    }
    // Gère les collisions entre les ennemis et les lasers/joueur
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Si la collision survient avec le joueur
            if (other.tag == "Player")
            {
                //Récupérer la classe Player afin d'accéder aux méthodes publiques
                Player player = other.transform.GetComponent<Player>();
                player.Degats();  // Appeler la méthode dégats du joueur

                Destroy(this.gameObject); // Détruire l'objet ennemi
                Debug.Log("l'ennemi a touché le joueur");

        }
        // Si la collision se produit avec un laser
        else if (other.tag == "attaqueCAC")
            {
                // Détruit l'ennemi et le laser
                Destroy(this.gameObject);
                // Appelle la méthode dans la classe UIManger pour augmenter le pointage
                //_uiManager.AjouterScore(_points);
                Debug.Log("attaqueCAC a touché l'ennemi");

        }

    }

}