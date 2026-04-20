using UnityEngine;

public class DialogueLook : MonoBehaviour
{
    GameObject AttachPoint;
    void Start()
    {
        AttachPoint = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        AttachPoint.transform.LookAt(Camera.main.transform.position);
    }
}
