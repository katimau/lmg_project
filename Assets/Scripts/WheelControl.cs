using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    public float rotateSpeed;
    private PlayerController pc;

    void Start()
    {
        pc = GetComponentInParent<PlayerController>();
        if (pc == null)
        {
            Debug.LogError("Parent doesn't have a PlayerController!");
        }
    }

    void Update()
    {
        if (pc.gameOver == false)
        {
            transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
        }
    }
}
