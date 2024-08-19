using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mob_spawn_handler : MonoBehaviour
{
    public float spawn_cool_down;
    float nearestDistance=10000;
    float distance;
    public GameObject[] children;
    public GameObject closest_point_to_player;
    public GameObject player;
    public GameObject instantiate_animation;
    void Start()
    {
        children= new GameObject[this.transform.childCount];
        for (int i=0;i<children.Length;i++)
        {
            children[i]=this.transform.GetChild(i).gameObject;
        }
        spawn_cool_down=5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn_cool_down>0)
        {
            spawn_cool_down-= Time.deltaTime;
        }
        else
        {
            spawn_cool_down=0;
        }
    }
    
    public void spawn_requested()
    {
        Debug.Log("requested");
        if(spawn_cool_down<=0)
        {
            for(int i=0; i<children.Length;i++)
            {
                distance=Vector3.Distance(player.transform.position,children[i].transform.position);
                if(distance<nearestDistance)
                {
                    closest_point_to_player=children[i];
                    nearestDistance=distance;
                }
            }
            Debug.Log(closest_point_to_player);
            StartCoroutine(summonMist());
            spawn_cool_down=22;
        }
    }
    //先生成一团黑雾当过场防止贴脸
    IEnumerator summonMist()
    {
        GameObject clone= Instantiate(instantiate_animation,closest_point_to_player.transform.position,transform.rotation);
        yield return new WaitForSeconds(2f);
        DestroyImmediate(clone);
        //instantiate mob
    }
}
