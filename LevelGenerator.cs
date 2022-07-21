using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject jewelPrefab;
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = 1.3f;
    public float maxY = 3f;
    private Vector3 _spawnPosition = new Vector3();
    void Start()
    {
        Spawn(jewelPrefab, new Vector3(0, 6, 0), 10, 3);
        Spawn(platformPrefab, new Vector3(0,0,0), 50, 1);
       /// for (int i = 0; i < numberOfPlatforms; i++)
      ///  {
       ///     SpawnPlatforms();
       /// }
    }
    private void SpawnPlatforms()
    {
        _spawnPosition.y += Random.Range(minY, maxY);
        _spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        Instantiate(platformPrefab, _spawnPosition, Quaternion.identity);
    }
    private void Spawn(GameObject prefab, Vector3 startPos, int numberOfObject, int frequence)
    {
        for (int i = 0; numberOfObject > 0; i++)
        {
            startPos.y += Random.Range(minY, maxY);
            if (i % frequence == 0)
            {
                startPos.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(prefab, startPos, Quaternion.identity);
                numberOfObject--;
            }
        }
    }
}
