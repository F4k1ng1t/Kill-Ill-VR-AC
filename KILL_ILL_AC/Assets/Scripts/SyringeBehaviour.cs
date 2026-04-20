using UnityEngine;

public class SyringeBehaviour : MonoBehaviour
{
    bool canInject = false;
    NPCBehaviour npc;
    public Material blood;
    public Material infectedBlood;
    public MeshRenderer barrel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NPCBehaviour>() != null)
        {
            canInject = true;
            npc = other.gameObject.GetComponent<NPCBehaviour>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<NPCBehaviour>() != null)
        {
            canInject = false;
            npc = null;
        }
    }
    public void Inject()
    {
        if (canInject)
        {
            if(npc.infected)
            {
                Debug.Log("Infected");
                barrel.material = infectedBlood;
            }
            else
            {
                Debug.Log("Not Infected");
                barrel.material = blood;
            }
        }
        else
        {
            Debug.Log("Shooting Blanks");
        }
    }
}
