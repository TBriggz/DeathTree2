using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private AudioSource chestOpen;
    private Animation anim;
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
            anim.Play("chest");
            Score.scoreValue += 250;
            chestOpen.Play();
            Invoke("TurnOffGameObject", 0.3f);
        }
    }
}