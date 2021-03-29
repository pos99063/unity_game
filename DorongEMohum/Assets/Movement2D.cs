using UnityEngine;


public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private Vector3 moveDirection;
    private Rigidbody2D rigid2d;

    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector3 direction)
    {
        moveDirection = direction;
    }

    private void Update()
    {
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;

        rigid2d.velocity = moveDirection * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = 0.1f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        moveSpeed = 5.0f;
    }
}