using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawner();


    }
    IEnumerator spawner(){
        Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
    }
}
