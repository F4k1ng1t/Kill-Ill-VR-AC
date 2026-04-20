using UnityEngine;

public class NPCDialogueStarter : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueNode startNode;

    public void StartConversation()
    {
        if (dialogueManager != null && startNode != null)
        {
            dialogueManager.StartDialogue(startNode);
        }
    }
}