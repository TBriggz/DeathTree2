using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (velX, velY);
        Destroy(gameObject, 1.5f);
    }

    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {

    //        if (collision.gameObject.tag == "Enemy")
    //        {
    //            Score.scoreValue += 50;
    //            Invoke("TurnOffGameObject", 0.3f);
    //        }
    //    }
}
