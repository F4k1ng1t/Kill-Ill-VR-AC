using System;
using System.Collections;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject ButtonPrefab;

    GameObject DialogueObject;
    DialogueNode currentNode;
    TextMeshProUGUI Name;
    TextMeshProUGUI Dialogue;
    Transform ButtonLayout;

    public void InitializeNPCForDialogue(NPCInfo NPC, DialogueNode startNode)
    {
        DialogueObject = NPC.DialogueObject;
        DialogueObject.SetActive(true);
        Name = NPC.NameObject;
        Name.text = NPC.Name;
        Dialogue = NPC.DialogueText;
        ButtonLayout = NPC.ButtonLayout.transform;
        StartDialogue(startNode);
    }
    public void StartDialogue(DialogueNode startNode)
    {
        currentNode = startNode;
        DisplayCurrentNode();
    }

    public void DisplayCurrentNode()
    {
        Dialogue.text = currentNode.dialogueText;
        //Destroy old buttons
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
        DialogueObject.SetActive(false);
        DialogueObject = null;
        Name = null;
        Dialogue = null;
        ButtonLayout = null;

    }

    public void ChooseOption(int choiceIndex)
    {
        currentNode = currentNode.choices[choiceIndex].nextNode;
        DisplayCurrentNode();
    }
}