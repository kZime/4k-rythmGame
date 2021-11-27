using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesObject : MonoBehaviour
{

    public bool canBepress;
    public KeyCode keyToPress;

    public GameObject hitEffect, goodEfect, perfectEffect, missEffect;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) {
            if (canBepress) {
                gameObject.SetActive(false);
                // GameManager.instance.NoteHit();

                // Debug.Log(transform.position.y);
                if (Mathf.Abs( transform.position.y ) > 0.30) {
                    Debug.Log("Normal");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                } else if (Mathf.Abs( transform.position.y ) > 0.15) {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEfect, transform.position, goodEfect.transform.rotation);
                } else {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }  
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Activator")
            canBepress = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Activator" && gameObject.activeSelf) {
            canBepress = false;
            GameManager.instance.NoteMiss();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
