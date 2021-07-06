using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    bool canFire = true;
    float timeBetweenShots = 3f;
    float timeNextShot;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeNextShot < Time.time)
        {
            canFire = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canFire)
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            timeNextShot = Time.time + timeBetweenShots;
            canFire = false;
        }

    }
}
