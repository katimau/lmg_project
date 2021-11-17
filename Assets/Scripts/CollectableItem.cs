using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollectableItem : MonoBehaviour
{
    
    public AudioClip aani;
     AudioSource collectSound;
    private Scoring scoreComponent;

    public int points;

    void Start()
    {
        collectSound = GetComponent<AudioSource>();
        scoreComponent = GameObject.Find("Score Text").GetComponent<Scoring>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kerätty");
        if (collectSound != null)
        {
            Debug.Log("Soitetaan");
            collectSound.PlayOneShot(aani, 0.9F);
        }
        scoreComponent.Score += points;
        Destroy(gameObject, 1F);
    }
}
