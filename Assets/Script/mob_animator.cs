using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob_animator : MonoBehaviour
{
    //set animator

    public mob_ai mobai;
    public Animator animator;
    public float facing_x;
    public float facing_y;

    public float speed=.1f;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("lastY",1);
    }

    // Update is called once per frame
    void Update()
    {
        //animator
        float xDirection = mobai.MovementDirection.x;
        float yDirection = mobai.MovementDirection.z;
        facing_x=mobai.MovementDirection.x;
        facing_y=mobai.MovementDirection.z;
        Vector3 moveDirection= new Vector3(xDirection,0.0f,yDirection);
        animator.SetFloat("Horizontal",xDirection);
        animator.SetFloat("Vertical",yDirection);
        animator.SetFloat("speed",moveDirection.magnitude);

            animator.SetFloat("lastX", mobai.MovementDirection.x);
            animator.SetFloat("lastY", mobai.MovementDirection.z);
    }
}
