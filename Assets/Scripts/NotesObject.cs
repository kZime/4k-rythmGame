using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesObject : MonoBehaviour
{

    public bool canBepress;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) {
            if (canBepress) {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
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
        }
    }
}
