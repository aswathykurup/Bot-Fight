using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Obstacle;
    public float seconds = 5f;
    [Range(0f, 1f)]
    public float number = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 0f, 80f);

            float randomNumber = Random.Range(0f, 1f);

            GameObject objectToSpawn = (randomNumber < number) ? Obstacle : Enemy;
            Instantiate(objectToSpawn,spawnPosition, Quaternion.identity);
        }
       
    }

}
