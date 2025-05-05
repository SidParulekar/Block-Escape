using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;

    [SerializeField] private float speed = 5f;

    private Rigidbody2D playerRB;

    private Vector3 startPosition;

    [SerializeField] private LevelManager levelManager;

    private int currentLevelIndex;
    private int finalLevelIndex;

    [SerializeField] LivesController livesController;

    private bool escaped = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        playerRB = GetComponent<Rigidbody2D>();

        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        finalLevelIndex = SceneManager.sceneCountInBuildSettings - 1;
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
        SoundManager.Instance.Play(Sounds.PlayerKilled);
        transform.position = startPosition;
        //levelManager.RestartLevel();
        livesController.ReduceLives(1);    
    }

    public int GetPlayerLives()
    {
        return livesController.GetLives();
    }

    private void PlayerEscaped()
    {
        SoundManager.Instance.Play(Sounds.LevelComplete);

        if (currentLevelIndex < finalLevelIndex)
        {
            levelManager.OnLevelComplete(currentLevelIndex);
        }
        
        else
        {
            escaped = true;
            Debug.Log("Block has Escaped!");
        }
    }

    public bool HasPlayerEscaped()
    {
        return escaped;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player has hit " + collision.gameObject.name);
            PlayerDied();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            PlayerEscaped();
        }
    }
}
