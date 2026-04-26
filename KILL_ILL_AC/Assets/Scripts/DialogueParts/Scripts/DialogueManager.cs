using NUnit.Framework;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public bool dialogueRunning = false;

    GameObject DialogueObject;
    DialogueNode currentNode;
    TextMeshProUGUI Name;
    TextMeshProUGUI Dialogue;
    Transform ButtonLayout;
    AudioSource audioSource;

    public void InitializeNPCForDialogue(NPCInfo NPC, DialogueNode startNode)
    {
        DialogueObject = NPC.DialogueObject;
        DialogueObject.SetActive(true);
        Name = NPC.NameObject;
        Name.text = NPC.Name;
        Dialogue = NPC.DialogueText;
        ButtonLayout = NPC.ButtonLayout.transform;
        audioSource = NPC.audioSource;
        StartDialogue(startNode);
    }
    public void StartDialogue(DialogueNode startNode)
    {
        currentNode = startNode;
        StartCoroutine(DisplayCurrentNodeAnimated());
    }
    public IEnumerator DisplayCurrentNodeAnimated(float textSpeed = 0.05f, float buttonSpeed = 0.5f)
    {
        dialogueRunning = true;
        Dialogue.text = "";
        foreach (Transform child in ButtonLayout)
        {
            Destroy(child.gameObject);
        }
        foreach (char c in currentNode.dialogueText)
        {
            Dialogue.text += c.ToString();
            if (!char.IsWhiteSpace(c))
            {
                audioSource.time = 0f;
                audioSource.pitch = UnityEngine.Random.Range(0.5f, 1f);
                audioSource.Play();
            }
            yield return new WaitForSeconds(textSpeed);
            //audioSource.Stop();
        }
        if (currentNode.choices.Length == 0)
        {
            StartCoroutine(EndDialogue());
        }
        List<Button> buttonList = new List<Button>();
        for (int i = 0; i < currentNode.choices.Length; i++)
        {

            GameObject newButton = Instantiate(ButtonPrefab, ButtonLayout);

            newButton.GetComponentInChildren<TextMeshProUGUI>().text = currentNode.choices[i].choiceText;

            Button button = newButton.GetComponent<Button>();

            int choiceIndex = i;
            
            button.onClick.AddListener(() => ChooseOption(choiceIndex));
            
            CanvasGroup cg = newButton.GetComponent<CanvasGroup>();
            if (cg == null) cg = newButton.AddComponent<CanvasGroup>();

            cg.alpha = 0f;                 
            cg.interactable = false;
            cg.blocksRaycasts = false;

            buttonList.Add(button);

        }
        foreach(Button b in buttonList)
        {
            yield return new WaitForSeconds(buttonSpeed);

            CanvasGroup cg = b.GetComponent<CanvasGroup>();
            cg.alpha = 1f;                 // show
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }


    }
    public void DisplayCurrentNode()
    {
        Dialogue.text = currentNode.dialogueText;
        
        foreach (Transform child in ButtonLayout)
        {
            Destroy(child.gameObject);
        }
        if (currentNode.choices.Length == 0)
        {
            StartCoroutine(EndDialogue());
        }
        // Create new buttons for current choices
        for (int i = 0; i < currentNode.choices.Length; i++)
        {
            
            GameObject newButton = Instantiate(ButtonPrefab, ButtonLayout);

            newButton.GetComponentInChildren<TextMeshProUGUI>().text = currentNode.choices[i].choiceText;

            Button button = newButton.GetComponent<Button>();

            int choiceIndex = i;
            button.onClick.AddListener(() => ChooseOption(choiceIndex));
        }
    }
    public IEnumerator EndDialogue()
    {
        yield return new WaitForSeconds(3);
        if(DialogueObject != null)
        {
            DialogueObject.SetActive(false);
            DialogueObject = null;
            Name = null;
            Dialogue = null;
            ButtonLayout = null;
        }
        dialogueRunning = false;

    }

    public void ChooseOption(int choiceIndex)
    {
        currentNode = currentNode.choices[choiceIndex].nextNode;
        StartCoroutine(DisplayCurrentNodeAnimated());
    }
}