using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump_force;

    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float dx = Input.GetAxis("Horizontal");

        rigid.velocity = new Vector2(dx * speed, rigid.velocity.y);

        float dy = Input.GetAxisRaw("Vertical");
        if (dy > 0 && Mathf.Abs(rigid.velocity.y) < 0.01f)
        {
            Debug.Log("JUMP");
            rigid.AddForce(new Vector2(0f, jump_force));
        }
    }
}
