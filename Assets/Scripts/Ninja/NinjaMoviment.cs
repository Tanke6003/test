using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMoviment : MonoBehaviour
{
    [SerializeField]private float speedMov ;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 movement;
    public Vector2 movementDirection => movement;
    public bool isMoving => movement.magnitude > 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    //threshold = error margin
    float threshold = 0.1f;
    //describe a movement direction
    // mathf.abs = absolute value
    // mathf.sign = -1 or 1
    movement.x = Mathf.Abs(input.x) > threshold ? Mathf.Sign(input.x) : 0f;
    movement.y = Mathf.Abs(input.y) > threshold ? Mathf.Sign(input.y) : 0f;


    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speedMov * Time.fixedDeltaTime);
    }



}
