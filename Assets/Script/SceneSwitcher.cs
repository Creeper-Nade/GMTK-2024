using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // 这个方法将在按钮点击时调用，用于切换场景
    public void SwitchScene(string sceneName)
    {
        // 加载指定名称的场景
        SceneManager.LoadScene(sceneName);
    }
}
