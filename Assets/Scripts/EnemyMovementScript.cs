using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{

    public float speed = 1f;
    private bool canMove = true;
    //public float bound_X = -11f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.health -= 1;
        }
    }

    void Move()
    {
        if (canMove)
        {

            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            //if (temp.x < bound_X)
            //    gameObject.SetActive(false);


        }
    }
}
