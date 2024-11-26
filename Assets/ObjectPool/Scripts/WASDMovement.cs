using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour {

	public float speed = 20f;

    void Update () 
    {    
        movimiento();
    }
    void movimiento()
    {
        
        float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 pos = new Vector3(Horizontal, 0f, Vertical);
        transform.Translate (pos);
    }
}
