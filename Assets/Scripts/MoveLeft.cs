using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public Vector3 speed;

    private PlayerController playerControllerScript;

    public bool destroyWhenOutOfBounds;

    // Alue, minkä ulkopuolella oleva objecti tuhotaan, jos destroyWhenOutOfBounds
    public Vector3 boundsMin;
    public Vector3 boundsMax;
    private Bounds bounds;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        bounds.SetMinMax(boundsMin, boundsMax);
    }

    void FixedUpdate()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(speed * Time.fixedDeltaTime);
        }

        if (bounds.Contains(transform.position) && destroyWhenOutOfBounds)
        {
            Destroy(gameObject);
        }
    }
}
