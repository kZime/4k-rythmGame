using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;    
    public BeatScrooler theBS;
    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 200;
    public int scorePerPerfectNote = 300;

    public int curMul;
    public int mulTrcer;
    public int[] mulThrHlds;

    public Text scoreText;
    public Text multiText;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        curMul = 1;
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

        if (curMul - 1 < mulThrHlds.Length) {
            mulTrcer++;

            if (mulThrHlds[curMul - 1] <= mulTrcer) {
                mulTrcer = 0;
                curMul++;
            }
        }


        // currentScore += scorePerNote * curMul;
        scoreText.text = "Score: " + currentScore;
        multiText.text = "Multiplier: x" + curMul;
    }

    public void NormalHit() {
        currentScore += scorePerNote * curMul;
        NoteHit();
    }

    public void GoodHit() {
        currentScore += scorePerGoodNote * curMul;
        NoteHit();
    }

    public void PerfectHit() {
        currentScore += scorePerPerfectNote * curMul;
        NoteHit();
    }


    public void NoteMiss() {
        Debug.Log("Miss!!");
    }

}
