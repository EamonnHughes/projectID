using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.up * 20) * Time.deltaTime);

    }
}
