using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;

    [SerializeField] private float speed = 5f;

    private Rigidbody2D playerRB;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //Debug.Log($"Horizontal: {horizontalInput}, Vertical: {verticalInput}");
    }

    private void MovePlayer()
    {
        /*Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        Vector3 moveAmount = moveDirection.normalized * speed * Time.deltaTime;
        transform.position += moveAmount;*/

        Vector2 playerVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;

        playerRB.velocity = playerVelocity;
    }

    private void PlayerDied()
    {
        transform.position = startPosition;
    }

    private void PlayerEscaped()
    {
        Debug.Log("Block has Escaped!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Player has hit a Spike Ball!");
            PlayerDied();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            PlayerEscaped();
        }
    }
}
