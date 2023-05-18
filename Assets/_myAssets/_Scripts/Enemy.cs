using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
   [SerializeField] public float moveSpeed = 5f;
    private Rigidbody2D rbEnemy;
    private Vector2 movementEnemy;



    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
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
}
