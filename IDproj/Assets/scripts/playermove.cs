using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    Rigidbody body;

float horizontal;
float vertical;

public float runSpeed = 20.0f;

void Start ()
{
   body = GetComponent<Rigidbody>();
}

void Update()
{
   Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
if (Input.GetKey(KeyCode.W)){
            transform.Translate((Vector3.forward * 4) * Time.deltaTime);}
if (Input.GetKey(KeyCode.A)){
            transform.Translate((Vector3.left * 4) * Time.deltaTime);}
if (Input.GetKey(KeyCode.D)){
            transform.Translate((Vector3.right * 4) * Time.deltaTime);}
}
}
