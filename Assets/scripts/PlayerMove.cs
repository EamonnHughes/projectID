using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float jumpPower = 3;
    Rigidbody body;
    bool grounded = true;

    float horizontal;
    float vertical;
    public float dashSpeed;

    public float runSpeed = 20.0f;
    public float dodgeSpeed;
    public AudioSource walkSound;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((Vector3.forward * 4) * Time.deltaTime);
            playSoundEffect();

        }
        //dash
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && StaminaBar.instance.currentStamina >= 1)
        {
            body.AddForce(transform.forward * dashSpeed * Time.deltaTime, ForceMode.Impulse);
            StaminaBar.instance.UseStamina(1);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector3.back * 4) * Time.deltaTime);
            playSoundEffect();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector3.left * 4) * Time.deltaTime);
            playSoundEffect();
        }
        if (Input.GetKey(KeyCode.D))

        {
            transform.Translate((Vector3.right * 4) * Time.deltaTime);
            playSoundEffect();
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true && StaminaBar.instance.currentStamina >= 5)
        {
            body.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            StaminaBar.instance.UseStamina(5);
        }

        //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && StaminaBar.instance.currentStamina >= 1)
        //{
        //   body.AddForce(Vector3.left * dashSpeed * Time.deltaTime, ForceMode.Impulse);
        //    StaminaBar.instance.UseStamina(1);
        // }
        //  if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && StaminaBar.instance.currentStamina >= 1)
        // {
        //    body.AddForce(Vector3.right * dashSpeed * Time.deltaTime, ForceMode.Impulse);
        //   StaminaBar.instance.UseStamina(1);
        //}
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) && StaminaBar.instance.currentStamina >= 1)
        {
            body.AddForce(Vector3.back * dashSpeed * Time.deltaTime, ForceMode.Impulse);
            StaminaBar.instance.UseStamina(1);
        }
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
    public void playSoundEffect()
    {
        walkSound.Play();
    }
}
