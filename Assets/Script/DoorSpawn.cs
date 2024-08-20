using UnityEngine;
using System.Collections.Generic;

public class DoorSpawner : MonoBehaviour
{
    public GameObject doorPrefab; // 需要在Inspector中赋值
    private List<Transform> spawnPoints = new List<Transform>();

    void Start()
    {
        // 找到所有标记为"DoorSpawnPoint"的GameObject
        GameObject[] spawnPointsObjects = GameObject.FindGameObjectsWithTag("Door Place");
        foreach (GameObject spawnPointObject in spawnPointsObjects)
        {
            spawnPoints.Add(spawnPointObject.transform);
        }

        // 确保有至少一个位置
        if (spawnPoints.Count > 0)
        {
            // 随机选择一个位置
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(doorPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
    }
}
