using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody body;

    public float threshold = -50f;

    float horizontal;

    float vertical;

    public float dashSpeed;

    public float rotateSpeed = 2.0f;

    public float runSpeed = 20.0f;

    public float velocity = 0.0f;

    public float dodgeSpeed;

    public AudioSource walkSound;

    Vector3 leftr = new Vector3(0, -80, 0);

    Vector3 rightr = new Vector3(0, 80, 0);

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (transform.position.y < threshold)
        {
            SceneManager.LoadScene("Menue");
        }


        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift) && StaminaBar.instance.currentStamina >= 1)
            {
                StaminaBar.instance.UseStamina(1);
                velocity = velocity + 2.0f;
            }
            else
            {
                velocity = velocity + 1.0f;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift) && StaminaBar.instance.currentStamina >= 1)
            {
                StaminaBar.instance.UseStamina(1);
                velocity = velocity - 2.0f;
            }
            else
            {
                velocity = velocity - 1.0f;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(leftr * Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rightr * Time.deltaTime * rotateSpeed);
        }


        velocity = velocity - velocity * 0.1f;
        transform.Translate((Vector3.forward * velocity) * Time.deltaTime);


        /*
        Vector3 rotation =
            new Vector3(transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y + 180,
                transform.rotation.eulerAngles.z);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((Vector3.forward * 4) * Time.deltaTime);
            playSoundEffect();
        }

        //dash
        if (
            Input.GetKey(KeyCode.W) &&
            Input.GetKey(KeyCode.LeftShift) &&
            StaminaBar.instance.currentStamina >= 1
        )
        {
            body
                .AddForce(transform.forward * dashSpeed * Time.deltaTime,
                ForceMode.Impulse);
            StaminaBar.instance.UseStamina(1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector3.back * 4) * Time.deltaTime);
            playSoundEffect();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(leftr * Time.deltaTime * rotateSpeed);
            playSoundEffect();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rightr * Time.deltaTime * rotateSpeed);
            playSoundEffect();
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
        if (
            Input.GetKey(KeyCode.A) &&
            Input.GetKey(KeyCode.LeftShift) &&
            StaminaBar.instance.currentStamina >= 1
        )
        {
            body
                .AddForce(Vector3.left * dashSpeed * Time.deltaTime,
                ForceMode.Impulse);
            StaminaBar.instance.UseStamina(1);
        }
        if (
            Input.GetKey(KeyCode.D) &&
            Input.GetKey(KeyCode.LeftShift) &&
            StaminaBar.instance.currentStamina >= 1
        )
        {
            body
                .AddForce(Vector3.right * dashSpeed * Time.deltaTime,
                ForceMode.Impulse);
            StaminaBar.instance.UseStamina(1);
        }
        if (
            Input.GetKey(KeyCode.S) &&
            Input.GetKey(KeyCode.LeftShift) &&
            StaminaBar.instance.currentStamina >= 1
        )
        {
            body
                .AddForce(Vector3.back * dashSpeed * Time.deltaTime,
                ForceMode.Impulse);
            StaminaBar.instance.UseStamina(1);
        }
*/
    }

    public void playSoundEffect()
    {
        walkSound.Play();
    }
}
