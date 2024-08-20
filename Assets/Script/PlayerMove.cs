using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator spriteAnimator; // 引用子级Sprite的Animator
    private Rigidbody rb; // 父级3D模型的刚体

    [SerializeField] private float moveSpeed = 5.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // 获取输入
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        // 根据摄像机角度转换输入方向
        Vector3 movement = ConvertInputToWorldDirection(moveH, moveV) * moveSpeed;
        rb.velocity = movement;

        // 设置动画参数
        spriteAnimator.SetFloat("Speed", rb.velocity.magnitude);

        if (rb.velocity != Vector3.zero)
        {
            spriteAnimator.SetFloat("MoveX", movement.x);
            spriteAnimator.SetFloat("MoveY", movement.z);
        }
        else
        {
            spriteAnimator.SetFloat("MoveX", 0);
            spriteAnimator.SetFloat("MoveY", 0);
        }
    }

    // 将输入转换为与摄像机视角对应的世界方向
    private Vector3 ConvertInputToWorldDirection(float moveH, float moveV)
{
    // 摄像机旋转的四元数
    Quaternion cameraRotation = Quaternion.Euler(0, -147, 0); 
    Vector3 inputDirection = new Vector3(moveH, 0, moveV);
    return cameraRotation * inputDirection;
}

}
