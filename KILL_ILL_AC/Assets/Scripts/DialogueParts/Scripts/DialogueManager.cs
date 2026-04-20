using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueNode currentNode;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Dialogue;
    public GameObject ButtonPrefab;
    public Transform ButtonLayout;

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

    public void ChooseOption(int choiceIndex)
    {
        currentNode = currentNode.choices[choiceIndex].nextNode;
        DisplayCurrentNode();
    }
}