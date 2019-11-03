using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{

    public float speed = 1f;
    private bool canMove = true;
    private AudioSource Death;
    //public float bound_X = -11f;


    // Start is called before the first frame update
    void Start()
    {
        Death = GetComponent<AudioSource>();
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

        if (collision.gameObject.tag == "Rock")
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Score.scoreValue += 50;
            Death.Play();
            Invoke("TurnOffGameObject", 0.3f);
        }
    }

    void Move()
    {
        if (canMove)
        {

            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

        }
    }
}
