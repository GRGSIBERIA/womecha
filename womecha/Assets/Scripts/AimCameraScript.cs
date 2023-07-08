using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCameraScript : MonoBehaviour
{
    Transform cam;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>().transform;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = cam.position;
        pos.x += rb.velocity.x * Time.deltaTime;
        pos.y += rb.velocity.y * Time.deltaTime;
        cam.position = pos;
    }
}
