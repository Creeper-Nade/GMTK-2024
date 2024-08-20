using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mob_ai : MonoBehaviour
{
    //sfx
    public AudioSource sound;
    [SerializeField] private AudioSource whiteNoise;
    [SerializeField] private AudioSource Noise;
    public AudioClip shriek;
    public AudioClip white_noise;
    public AudioClip more_noise;
    public audio_manager AudioManager;
    
    public GameObject player;
    public GameObject tp_marker;
    public GameObject tp_clone;
    public lost_ui lost_Ui;
    public GameObject mob;

    private Vector3 lastPos;
    public Vector3 MovementDirection {get;private set;}

    float lifeCountdown;
    public NavMeshAgent agent;

    public void Init(GameObject play,lost_ui lost)
    {
        Debug.Log(play);
        this.player=play;
        this.lost_Ui=lost;
    }
    public void soundInit(audio_manager audio)
    {
        this.AudioManager=audio;
    }
    private void Start() {
        //player= GameObject.FindWithTag("Player");
        lifeCountdown=15f;
        agent.updateRotation=false;
        InvokeRepeating("teleportation",5.0f,5.0f);
        whiteNoise.clip=white_noise;
        whiteNoise.Play();
        Noise.clip=more_noise;
        Noise.Play();
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
            DestroyImmediate(tp_clone);
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
        //AudioManager.play_sfx(AudioManager.shriek);
        sound.PlayOneShot(shriek);
    }

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject==player)
        {
            Debug.Log("Gotcha");
            sound.PlayOneShot(AudioManager.eee);
            lost_Ui.death_called();

        }
    }
}
