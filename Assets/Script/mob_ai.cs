using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mob_ai : MonoBehaviour
{
    
    public GameObject player;
    public GameObject tp_marker;
    public GameObject tp_clone;
    public lost_ui lost_Ui;
    public GameObject mob;

    private Vector3 lastPos;
    public Vector3 MovementDirection {get;private set;}

    float lifeCountdown;
    public NavMeshAgent agent;
    private void Start() {
        lifeCountdown=15f;
        agent.updateRotation=false;
        InvokeRepeating("teleportation",5.0f,5.0f);
    }
    void Update()
    {
        
        //movement
        Vector3 player_position= player.transform.position;
        agent.SetDestination(player_position);

        MovementDirection= lastPos-transform.position;
        MovementDirection.Normalize();
        lastPos=transform.position;
        //detect lifetime
        if(lifeCountdown>0)
        {
            lifeCountdown-= Time.deltaTime;
        }
        else
        {
            Destroy(mob);
        }
    }


    private void teleportation()
    {
        Debug.Log("hi");
        Vector3 marker_position= player.transform.position;
        tp_clone=Instantiate(tp_marker,marker_position,transform.rotation);
        StartCoroutine(Execute_tp());
    }

    IEnumerator Execute_tp()
    {        
        yield return new WaitForSeconds(0.5f);
        this.transform.position=tp_clone.transform.position;
        DestroyImmediate(tp_clone);
        Debug.Log("destroyed");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject==player)
        {
            Debug.Log("Gotcha");
            lost_Ui.death_called();
        }
    }
}
