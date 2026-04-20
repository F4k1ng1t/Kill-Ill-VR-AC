using UnityEngine;

public class DialogueTester : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueNode startNode;

    void Start()
    {
        dialogueManager.StartDialogue(startNode);
    }
}