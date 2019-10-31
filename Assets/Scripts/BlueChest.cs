using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueChest : MonoBehaviour
{

    private AudioSource explosionSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Player")
        {

            //Destroy(.gameObject);
            gameObject.SetActive(false);
            Score.scoreValue += 1000;
            explosionSound.Play();
        }
    }
}