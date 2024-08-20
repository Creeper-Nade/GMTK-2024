using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;
//ee
public class DoorTrigger : MonoBehaviour
{
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            LoadRandomScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void LoadRandomScene()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int randomIndex = Random.Range(0, sceneCount);
        SceneManager.LoadScene(randomIndex);
=======
using System.Collections.Generic;

public class SpecificPrefabSpawner : MonoBehaviour
{
    [System.Serializable]
    public class PrefabSpawnInfo
    {
        public GameObject prefab; // 需要生成的预制体
        public string sceneName;  // 预制体允许生成的场景名
    }

    public List<PrefabSpawnInfo> spawnInfos; // 预制体信息列表
    private List<Transform> spawnPoints = new List<Transform>();

    void Start()
    {
        // 确保有预制体信息
        if (spawnInfos.Count == 0)
        {
            Debug.LogError("No prefab spawn info assigned!");
            return;
        }

        // 找到所有标记为"SpawnPoint"的GameObject
        GameObject[] spawnPointsObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (GameObject spawnPointObject in spawnPointsObjects)
        {
            spawnPoints.Add(spawnPointObject.transform);
        }

        // 确保有至少一个位置
        if (spawnPoints.Count > 0)
        {
            // 获取当前场景的名字
            string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

            // 遍历预制体信息列表
            foreach (var info in spawnInfos)
            {
                // 如果当前场景允许生成这个预制体
                if (info.sceneName == currentSceneName)
                {
                    // 随机选择一个生成点
                    Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                    // 实例化预制体
                    Instantiate(info.prefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
                }
            }
        }
>>>>>>> Stashed changes
    }
}
