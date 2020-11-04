using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleSquashStretch : MonoBehaviour
{
    public float C;
    public Vector2 width_scale_bounds;
    public Vector2 height_scale_bounds;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float height = 1 + (rigid.velocity.y / C);
        float width = 1 - (rigid.velocity.y / C);
        transform.localScale = new Vector3(
            Mathf.Clamp(width, width_scale_bounds.x, width_scale_bounds.y),
            Mathf.Clamp(height, height_scale_bounds.x, height_scale_bounds.y),
            1f);
        SpriteRenderer sr = new SpriteRenderer();
    }
}
