using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public AudioSource collectSound;
    private Scoring scoreComponent;

    public int points;

    void Start()
    {
        scoreComponent = GameObject.Find("Score Text").GetComponent<Scoring>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (collectSound != null)
        {
            collectSound.Play();
        }
        scoreComponent.Score += points;
        Destroy(gameObject);
    }
}
