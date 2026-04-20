using Unity.VisualScripting;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public bool infected = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
