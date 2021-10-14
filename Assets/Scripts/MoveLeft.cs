using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15; //aloitellaan tällä, voi säätää myöhemmin lisää
                                //hidas aloitus, jotta estebugi selviää taas
    private PlayerController playerControllerScript;

    private float leftBound = -15; //raja esteiden tuhoamiselle kun menevät pelaajan "ohi"

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
