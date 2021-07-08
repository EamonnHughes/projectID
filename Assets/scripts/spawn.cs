using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemy;

    public Coroutine spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
