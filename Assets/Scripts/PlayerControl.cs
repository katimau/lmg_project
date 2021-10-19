using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Palikan liikutus muuttuja
    public float liikutus = 20.0f;
    public float kaantyminen;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //call the variable
        horizontalInput = Input.GetAxis("Horizontal");
        //Move block forward
        transform.Translate(Vector3.forward * Time.deltaTime * liikutus);
        //turnSpeed
        transform.Translate(Vector3.right * Time.deltaTime * kaantyminen * horizontalInput);
    }
}
