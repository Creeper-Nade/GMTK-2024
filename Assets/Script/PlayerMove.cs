using UnityEngine;
public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // 获取水平方向的输入 (A, D)
        float moveZ = Input.GetAxis("Vertical");   // 获取垂直方向的输入 (W, S)

        Vector3 move = new Vector3(moveX, 0, moveZ);

        // 根据摄像机方向调整移动向量
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // 确保移动方向只在平面上，忽略y轴
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 desiredMoveDirection = (cameraForward * move.z + cameraRight * move.x).normalized;

        transform.Translate(desiredMoveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
