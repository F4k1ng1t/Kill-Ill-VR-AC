using System.Collections;
using UnityEditor;
using UnityEngine;

public class FlintlockBehaviour : MonoBehaviour
{
    public GameObject shotPoint;
    public GameObject bullet;
    public float bulletSpeed = 10f;
    Rigidbody rb;
    bool canShoot = true;
    void Start()
    {
        rb = bullet.GetComponent<Rigidbody>();
    }

    void Update()
    {
    }
    public void Shoot()
    {
        if (canShoot)
        {
            GameObject newBullet = Instantiate(bullet, shotPoint.transform.position, shotPoint.transform.rotation);
            newBullet.GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletSpeed;
            StartCoroutine(DespawnBullet(newBullet));
            StartCoroutine(ReloadTimer());
            canShoot = false;
        }
    }
    public IEnumerator DespawnBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2);
        Destroy(bullet);
    }
    public IEnumerator ReloadTimer()
    {
        yield return new WaitForSeconds(3);
        canShoot = true;
    }
}
