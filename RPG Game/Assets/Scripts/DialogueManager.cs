using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text NameText;
    public GameObject dialogueBox;
    public GameObject nameBox;
    public string[] dialogueLines;
    public int currentLine;
    public static DialogueManager instance;
    private bool justStarted;
    public KeyCode keyCode;

    void Start()
    {
            instance = this;
    }

    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetKeyUp(keyCode))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogueLines.Length)
                    {
                        dialogueBox.SetActive(false);
                        PlayerController.instance.canMove = true;
                    }
                    else
                    {
                        CheckIfName();
                        dialogueText.text = dialogueLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

    public void ShowDialogue(string[] newLines)
    {
        dialogueLines = newLines;
        currentLine = 0;
        CheckIfName();
        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);
        justStarted = true;
        PlayerController.instance.canMove = false;
    }

    public void CheckIfName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            NameText.text = dialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
