using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private AudioSource PickedCoin;
    // Start is called before the first frame update
    void Start()
    {
        PickedCoin = GetComponent<AudioSource>();
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
            Score.scoreValue += 10;
            PickedCoin.Play();
            Invoke("TurnOffGameObject", 0.3f);
        }
    }
}
