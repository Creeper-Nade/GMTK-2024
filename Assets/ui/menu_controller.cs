using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_controller : MonoBehaviour
{
    public GameObject settings;
    void Start()
    {
        settings.SetActive(false);
    }

    public void setting_triggered()
    {
        settings.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(settings.activeSelf==true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                settings.SetActive(false);
            }
        }
    }
}
