using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigid;
    Transform ts;
    Camera cam;

    [SerializeField]
    float movePower = 4f;

    [SerializeField]
    Status status;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ts = transform;
        cam = Camera.main;
    }

    void MoveProcedure()
    {
        var vp = cam.WorldToViewportPoint(transform.position);
        bool active = (1f > vp.x && vp.x > 0f) && (1f > vp.y && vp.y > 0f) && (vp.z > 0f);

        var xp = new Vector2(vp.x, vp.y);
        xp *= new Vector2(2f, 2f);
        xp -= Vector2.one;

        Debug.Log(xp);
        
        rigid.drag = Mathf.Exp(xp.sqrMagnitude);
        

        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector2.up * movePower);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector2.left * movePower);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector2.down * movePower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector2.right * movePower);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rigid.AddForce(Vector2.up * -Physics2D.gravity * movePower * 0.2f);
        }

        //ts.rotation = Quaternion.identity;  // 回転をキャンセル
        ts.rotation = Quaternion.Euler(0, 0, 90);
        rigid.angularVelocity = 0f;         // 回転の勢いをキャンセル
        rigid.totalTorque = 0f;             // 回転の力をキャンセル
    }

    void ShootProcedure()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveProcedure();
        ShootProcedure();
    }
}
