using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; 
    public int numberOfTargets = 5; 

    void Start()
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            SpawnTarget();
        }
    }

    void SpawnTarget()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = Random.Range(-10.0f, 10.0f);

        Vector3 spawnPosition = new Vector3(x, 0, y); 
        Instantiate(targetPrefab, spawnPosition, Quaternion.identity); 
    }
}
