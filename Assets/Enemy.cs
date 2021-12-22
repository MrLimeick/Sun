using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject ParticleSystem;
    void Start()
    {
        StartCoroutine(RandomMove());
    }

    public void Destroy()
    {
        Debug.Log("Good!");
        CameraController.Stars++;
        Instantiate(ParticleSystem, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    IEnumerator RandomMove()
    {
        transform.Rotate(0, 0, Random.Range(0,360));
        GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(0,Random.Range(0,20),0), ForceMode2D.Force);
        yield return new WaitForSeconds(5);
        StartCoroutine(RandomMove());
    }
    void Update()
    {
        
    }
}
