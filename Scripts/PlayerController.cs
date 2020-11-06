using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 20f;
    private float movement = 0f;
    private float jumpSpeed = 3f;
        
    public Transform groundCheckPoint;
    public float groundCheckRadius = 4.28f; 
    public LayerMask groundLayer;
    private bool isTouchingGround;

    public LevelManager gameLevelManager;

    public Vector3 respawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameLevelManager = FindObjectOfType<LevelManager>(); 
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement = UnityEngine.Input.GetAxis("Horizontal");

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        if(movement > 0f || movement < 0f)
        {  
            rigidBody.velocity = new Vector2(movement*speed, rigidBody.velocity.y);
        }

        if(Input.GetButtonDown ("Jump") && isTouchingGround) 
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed); 
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collide");
        
        if(other.gameObject.CompareTag("FallDetector"))
        {
             gameLevelManager.Respawn();  
		}
    }

}

