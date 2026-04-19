using System.Collections;
using UnityEditor;
using UnityEngine;

public class FlintlockBehaviour : MonoBehaviour
{
    public GameObject shotPoint;
    public GameObject bullet;
    Rigidbody rb;
    void Start()
    {
        rb = bullet.GetComponent<Rigidbody>();
    }

    void Update()
    {
    }
    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, shotPoint.transform.position, shotPoint.transform.rotation);
        newBullet.GetComponent<Rigidbody>().linearVelocity = transform.forward * 10;
    }
    //public IEnumerator DespawnBullet()
    //{

    //}
}
