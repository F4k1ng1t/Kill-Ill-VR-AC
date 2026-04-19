using UnityEngine;

public class RotateItemsWithPlayer : MonoBehaviour
{
    public Camera _camera;
    GameObject AttachPoint;
    void Start()
    {
        AttachPoint = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        AttachPoint.transform.rotation = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0);
    }
}
