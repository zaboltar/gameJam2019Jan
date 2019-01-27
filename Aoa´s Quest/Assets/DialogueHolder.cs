using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMan;

    public string[] dialogueLines;


    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }


    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other);
            if (Input.GetKeyUp(KeyCode.Z))
            {
                Debug.Log(dMan);
                //dMan.ShowBox(dialogue);
                if (!dMan.dialogueActive)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }


            }
        }
    }
}