using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialgetrigeer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string dialogueText = "go in the door";
    public GameObject dialoguePanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Show dialogue panel and set text
            ShowDialogue(dialogueText);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide dialogue panel when player exits collider
            HideDialogue();
        }
    }

    void ShowDialogue(string text)
    {
        // Activate the dialogue panel and set the text
        dialoguePanel.SetActive(true);
        dialoguePanel.GetComponentInChildren<UnityEngine.UI.Text>().text = text;
    }

    void HideDialogue()
    {
        // Deactivate the dialogue panel
        dialoguePanel.SetActive(false);
    }
}
