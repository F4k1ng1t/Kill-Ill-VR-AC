using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueNode startNode;
    NPCInfo NPC;

    private bool playerInRange = false;
    private XRInputActions inputActions;

    void Awake()
    {
        inputActions = new XRInputActions();
    }
    private void Start()
    {
        if (this.GetComponent<NPCInfo>() != null)
            NPC = this.GetComponent<NPCInfo>();
        else
            Debug.Log("ts not on here gng *wilted rose emoji*");
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        // A button pressed while near NPC
        if (playerInRange && inputActions.Gameplay.Interact.triggered && !dialogueManager.dialogueRunning)
        {
            dialogueManager.InitializeNPCForDialogue(NPC, startNode);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}