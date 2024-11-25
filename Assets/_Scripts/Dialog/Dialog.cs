using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    private bool talkBefore = false;
    private int currentIndex = 0;

    public string npcName;
    public string playerName;

    public GameObject dialogBox;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI contentText;
    public bool isDialoging = false;


    public List<DialogLine> firstDialog = new List<DialogLine>();
    public List<DialogLine> repeatDialog = new List<DialogLine>();

    private List<DialogLine> currentDialog;

    private void Update()
    {
        if (dialogBox == null) return;

        if (Input.GetMouseButtonDown(0) && isDialoging)
        {
            if (!dialogBox.activeInHierarchy)
            {
                StartDialog();
            }
            else
            {
                DisplayNextLine();
            }
        }
    }

    private void StartDialog()
    {
        dialogBox.SetActive(true);
        currentIndex = 0;

        currentDialog = talkBefore ? repeatDialog : firstDialog;

        DisplayNextLine();
    }

    private void DisplayNextLine()
    {
        if (currentIndex < currentDialog.Count)
        {
            var dialogLine = currentDialog[currentIndex];
            if (dialogLine.speaker == npcName)
                speakerNameText.text = dialogLine.speaker;
            else if(dialogLine.speaker == playerName)
                contentText.text = dialogLine.speaker;
            //speakerNameText.text = dialogLine.speaker == "NPC" ? npcName : playerName;
            contentText.text = dialogLine.content;
            currentIndex++;
        }
        else
        {
            EndDialog();
            if (!talkBefore)
            {
                talkBefore = true;
            }
        }
    }

    private void EndDialog()
    {
        dialogBox.gameObject.SetActive(false);
        currentIndex = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDialoging = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDialoging = false;
            EndDialog();
        }
    }
}
[System.Serializable]
public class DialogLine
{
    public string speaker;
    [TextArea(3, 10)] public string content;
}
