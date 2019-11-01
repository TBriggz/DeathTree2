using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueChest : MonoBehaviour
{

    private AudioSource chestOpen;
    // Start is called before the first frame update
    void Start()
    {
        chestOpen = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Player")
        {

            Score.scoreValue += 1000;
            chestOpen.Play();
            Invoke("TurnOffGameObject", 0.3f);
        }
    }
}