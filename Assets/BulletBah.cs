using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBah : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.TransformDirection(new Vector2(0,0.25f));
        if (transform.position.y > CameraController.ScreenSize.y / 2 + 5 || transform.position.y < -(CameraController.ScreenSize.y / 2) - 5) Destroy(this.gameObject);
    }
}
