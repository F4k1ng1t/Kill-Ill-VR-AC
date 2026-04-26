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
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
