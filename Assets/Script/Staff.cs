using UnityEngine;

public class InteractWithSprite3D : MonoBehaviour
{
    // 父级的3D对象
    public GameObject parentObject;
    // 子级UI对象
    public GameObject childUI;
    // 透明度 (0=完全透明, 1=不透明)
    public float transparency = 0.5f;

    private bool isInRange = false;
    private int interactionCount = 0;

    void Start()
    {
        // 重置计数器值
        PlayerPrefs.SetInt("InteractionCount", 0);
        PlayerPrefs.Save();
        interactionCount = 0;
        Debug.Log("Interaction Count Reset to: " + interactionCount);
    }

    void Update()
    {
        // 当玩家在范围内并按下E键时，执行交互逻辑
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!childUI.activeSelf)
            {
                // 如果UI没有显示，则先显示UI
                ShowUI();
            }
            else
            {
                // 如果UI已经显示，则关闭UI，隐藏父级对象，并计数
                ToggleUI();
                HideParentObject();
                IncrementInteractionCount();
            }
        }
    }

    // 显示UI
    void ShowUI()
    {
        childUI.SetActive(true);
    }

    // 切换UI的激活状态
    void ToggleUI()
    {
        bool isActive = childUI.activeSelf;
        childUI.SetActive(!isActive);
    }

    // 让父级对象消失
    void HideParentObject()
    {
        parentObject.SetActive(false);
    }

    // 增加计数器并保存值
    void IncrementInteractionCount()
    {
        interactionCount++;
        PlayerPrefs.SetInt("InteractionCount", interactionCount);
        PlayerPrefs.Save();
        Debug.Log("New Interaction Count: " + interactionCount);
    }

    // 当玩家进入碰撞范围时
    void OnTriggerEnter(Collider other)
    {
        // 检查是否是带有 "Player" 标签的玩家对象
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    // 当玩家离开碰撞范围时
    void OnTriggerExit(Collider other)
    {
        // 检查是否是带有 "Player" 标签的玩家对象
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
