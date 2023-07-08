using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigid;
    Transform ts;

    [SerializeField]
    float movePower = 4f;

    [SerializeField]
    float velocityLimit = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ts = transform;
    }

    void MoveProcedure()
    {
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

        ts.rotation = Quaternion.identity;  // 回転をキャンセル
        rigid.angularVelocity = 0f;         // 回転の勢いをキャンセル
        rigid.totalTorque = 0f;             // 回転の力をキャンセル

        /*
        // 想定よりも大きい速度が出たらキャンセル
        if (rigid.velocity.sqrMagnitude > velocityLimit * velocityLimit) 
        {
            rigid.velocity = rigid.velocity.normalized * velocityLimit;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        MoveProcedure();
    }
}
