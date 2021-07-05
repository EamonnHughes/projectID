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
   // Gives a value between -1 and 1
   horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
   vertical = Input.GetAxisRaw("Vertical"); // -1 is down
}

void FixedUpdate()
{ 
   body.velocity = new Vector3(horizontal * runSpeed, 0, vertical * runSpeed);
}
}
