using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        Vector2 rot = new Vector2(CameraController.MousePos.x - transform.position.x, CameraController.MousePos.y - transform.position.y);
        transform.up = rot;
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2);
        Instantiate(bullet, transform.position, transform.rotation);
        StartCoroutine(Shoot());
    }
}
