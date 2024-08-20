using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lost_ui : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public GameObject world_space_stuff;
    public Animator animator;
    void Start()
    {
        //canvasGroup.alpha=0;
    }

    public void death_called()
    {
        animator.SetTrigger("appear");
        world_space_stuff.SetActive(false);
    }
}
