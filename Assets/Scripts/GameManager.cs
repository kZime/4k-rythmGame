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


    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missHits;

    public GameObject resultsScreen;
    public Text percentHitText, rankText, finalScoreText;
    public Text normalsText, goodsText, perfectsText, missesText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        curMul = 1;
        totalNotes = FindObjectsOfType<NotesObject>().Length;
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
        } else {
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy) {
                resultsScreen.SetActive(true);

                normalsText.text = "" + normalHits;
                goodsText.text = "" + goodHits;
                perfectsText.text = "" + perfectHits;
                missesText.text = "" + missHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;
                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if (percentHit > 40) rankVal = "D";
                if (percentHit > 55) rankVal = "C";
                if (percentHit > 70) rankVal = "B";
                if (percentHit > 85) rankVal = "A";
                if (percentHit > 95) rankVal = "S";

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
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
        normalHits++;
    }

    public void GoodHit() {
        currentScore += scorePerGoodNote * curMul;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit() {
        currentScore += scorePerPerfectNote * curMul;
        NoteHit();
        perfectHits++;
    }


    public void NoteMiss() {
        Debug.Log("Miss!!");
        missHits++;
    }

}
