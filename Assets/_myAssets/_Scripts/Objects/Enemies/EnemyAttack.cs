using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour

{

   [SerializeField] public GameObject attackPrefab;  // Pr�fabriqu� de l'attaque
   [SerializeField] public float attackSpeed = 1f;   // Vitesse de l'attaque
   public Transform ennemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeplacementCrystal()
    {
        transform.Translate(Vector3.up * Time.deltaTime * attackSpeed);
        if (transform.position.y > 8f)
        {
            // Si le laser sort de l'�cran il se d�truit
            if (this.transform.parent == null)
            {
                Destroy(this.gameObject);
            }
            // Si le laser fait partie d'un conteneur il d�truit le conteneur
            else
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
}
