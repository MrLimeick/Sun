using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CameraController.MousePos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet") CameraController.Hp--;
        if (collision.gameObject.tag == "Enemy") collision.gameObject.GetComponent<Enemy>().Destroy();
        if (collision.gameObject.tag == "Heart") CameraController.Hp++;
        Destroy(collision.gameObject);

    }
    //private void OnTriggerEnter(Collision2D collision)
    //{
    //    Debug.Log("Yes!");
    //}
}
