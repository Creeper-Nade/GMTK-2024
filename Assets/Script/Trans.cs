using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseSceneSwitcher : MonoBehaviour
{
    private static MouseSceneSwitcher instance;
    private int currentSceneIndex;

    void Awake()
    {
        // 确保只有一个 MouseSceneSwitcher 实例存在，并且在场景切换时不被销毁
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // 检测鼠标点击事件
        if (Input.GetMouseButtonDown(0))
        {
            // 切换到下一个场景
            LoadNextScene();
        }
    }

    void Initialize()
    {
        // 初始化当前场景索引
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void LoadNextScene()
    {
        // 计算下一个场景的索引
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        // 加载下一个场景
        SceneManager.LoadScene(nextSceneIndex);
    }
}
