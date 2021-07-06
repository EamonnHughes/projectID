using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
   float jumpPower = 3;
    Rigidbody body;
        bool grounded = true;

float horizontal;
float vertical;
public float dashSpeed;

public float runSpeed = 20.0f;
public float dodgeSpeed;

void Start ()
{
   body = GetComponent<Rigidbody>();
}

void Update()
{
   Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
if (Input.GetKey(KeyCode.W)){
            transform.Translate((Vector3.forward * 4) * Time.deltaTime);}
            //dash
if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)){
body.AddForce(transform.forward*dashSpeed * Time.deltaTime, ForceMode.Impulse);
}
if (Input.GetKey(KeyCode.S)){
            transform.Translate((Vector3.back * 4) * Time.deltaTime);}
if (Input.GetKey(KeyCode.A)){
            transform.Translate((Vector3.left * 4) * Time.deltaTime);}
if (Input.GetKey(KeyCode.D)){
            transform.Translate((Vector3.right * 4) * Time.deltaTime);}
            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            body.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
}
void OnTriggerEnter(Collider theCollision)
    {
        if (theCollision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
    void OnTriggerExit(Collider theCollision)
    {
        if (theCollision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }
}
