using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField]
    public float movePower = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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
    }

    // Update is called once per frame
    void Update()
    {
        MoveProcedure();
    }
}
