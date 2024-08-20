using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    // 指定要切换的场景名称
    public string sceneName = "OfficeAfternoon";

    void Start()
    {
        // 获取按钮组件并添加点击事件监听器
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        // 切换到指定的场景
        SceneManager.LoadScene(sceneName);
    }
}
