using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private FixedJoystick joystick;

    private Text GameOver;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GroundTag= "Ground";
    private string EnemyTag = "Enemy";
    private bool isGrounded;
    public bool isAlive = true;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        joystick = GameObject.FindWithTag("joystick").GetComponent<FixedJoystick>();

        GameObject.Find("JumpButton").GetComponent<Button>().onClick.AddListener(PlayerJump);

        GameOver = GameObject.Find("Game Over Text").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //anim.SetBool(WALK_ANIMATION, false);
        if (isAlive)
        {
            GameOver.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        //Debug.Log(anim.GetBool(WALK_ANIMATION));
        AnimatePlayer();

    }

    private void FixedUpdate()
    {
        
    }

    void PlayerMoveKeyboard()
    {
        movementX = joystick.Horizontal; // if left key is pressed, then returns -1, right key returns 1, 0 if no key, joystick can give some value in between also
        //Debug.Log(movementX);

        if((transform.position.x < 43.4f && movementX>0)|| (transform.position.x>-42.4f && movementX<0)) // making sure he isnt at the edges
        transform.position += new Vector3(movementX, 0f, 0f)  * moveForce * Time.deltaTime;
        /* Time.deltaTime gives us the time between each frame, it is used to smoothen the movement */
    }

    void AnimatePlayer()
    {
        if (movementX <0 )
        {// moving left side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else if (movementX > 0)
        {//moving right slide
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else
        { anim.SetBool(WALK_ANIMATION, false);
        }
    }
    
    void PlayerJump()
    {
       if (isGrounded)
        {           
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("Jump force applied");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            isGrounded = true;
            // Debug.Log("Player Landed");

        }

       if (collision.gameObject.CompareTag(EnemyTag))
        {
            Destroy(gameObject);
            Debug.Log("enemy touched");
            isAlive = false;
            GameOver.enabled = true; // Making  the Game over text display
        }
    }  

} //class
