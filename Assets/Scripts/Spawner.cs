using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitprefab;
    public Transform[] spawnpoints;
    private float maxdelay=2f;
  
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delaytime = Random.Range(0, maxdelay);
            yield return new WaitForSeconds(delaytime);
            int index = Random.Range(0, spawnpoints.Length);
            Transform spawnpoint = spawnpoints[index];
            Instantiate(fruitprefab, spawnpoint.position, spawnpoint.rotation);
        }
    }
}
