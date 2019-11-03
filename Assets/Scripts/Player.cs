using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator myAnimator;

    public float jumpHeight;
    public float speed;

    public bool isGrounded;
    bool facingRight = true;
    public GameObject bulletRight, bulletLeft;
    Vector2 bulletPos;
    private AudioSource Bullet;
    public float  fireRate = 0.5f;
    float nextFire = 0.0f;

    public void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        //Call moving function
        Movement();

        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);
        //Flip the character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
            facingRight = false;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
            facingRight = true;
        }
        transform.localScale = characterScale;

        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire ();
        }

    }

    //Basic movement function
    void Movement()
    {
        //X-Axis movement
        float inputX = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(inputX * speed, rb2d.velocity.y);

        //Y-Axis/Jumping movement
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb2d.AddForce(new Vector3(0.0f, jumpHeight, 0.0f), ForceMode2D.Impulse);
            isGrounded = false;
        }
        
    }

    //checks if player is in grounded state to allow jumping
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void HandleMovement(float horizontal)
    {
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }
    void fire ()
    {
        bulletPos = transform.position;
        if (facingRight)
        {
            bulletPos += new Vector2 (+1f, -0.23f);
            Instantiate(bulletRight, bulletPos, Quaternion.identity);
            Bullet.Play();
        }
        else
        {
            bulletPos += new Vector2(-1f, -0.23f);
            Instantiate(bulletLeft, bulletPos, Quaternion.identity);
        }
    }
}
