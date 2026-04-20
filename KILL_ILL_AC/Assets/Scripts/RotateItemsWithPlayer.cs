using UnityEngine;

public class MoveItemsWithPlayer : MonoBehaviour
{
    GameObject AttachPoint;
    public float VerticalOffset = -0.5f;
    void Start()
    {
        AttachPoint = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        AttachPoint.transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        AttachPoint.transform.position = Camera.main.transform.position + new Vector3(0, VerticalOffset, 0);
    }
}
