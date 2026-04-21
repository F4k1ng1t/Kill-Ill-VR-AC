using TMPro;
using UnityEngine;

public class NPCInfo : MonoBehaviour
{
    
    public bool infected = false;
    public string Name = "";
    public GameObject DialogueObject;
    public GameObject ButtonLayout;
    public TextMeshProUGUI NameObject;
    public TextMeshProUGUI DialogueText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
