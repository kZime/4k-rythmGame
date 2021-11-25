using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;    
    public BeatScrooler theBS;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying) {
            if (Input.anyKeyDown) {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
                // Debug.Log("hey!");
            }
        }
    }

    public void NoteHit() {
        Debug.Log("Perfect!!");

    }
    public void NoteMiss() {
        Debug.Log("Miss!!");
    }

}
