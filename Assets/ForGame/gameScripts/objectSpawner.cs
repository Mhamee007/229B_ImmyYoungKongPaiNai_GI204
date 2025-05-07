using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab in the Inspector
    public int numberOfObjects = 10; // Number of objects to spawn

    public float minX = -15f;
    public float maxX = 15f;
    public float minY = 0f;
    public float maxY = 10f;

    private float lifetime = 5f;
    [SerializeField] float spawnDelay = 0f;
   

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {  
        yield return new WaitForSeconds(spawnDelay);

        for (int i = 0; i < numberOfObjects; i++)
        {
           
            Vector2 spawnPosition = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );

            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay); // allowing next shoot
        }
        
    }


}
