using UnityEngine;

public class SyringeBehaviour : MonoBehaviour
{
    bool canInject = false;
    NPCInfo npc;
    public Material blood;
    public Material infectedBlood;
    public MeshRenderer barrel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NPCInfo>() != null)
        {
            canInject = true;
            npc = other.gameObject.GetComponent<NPCInfo>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<NPCInfo>() != null)
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
