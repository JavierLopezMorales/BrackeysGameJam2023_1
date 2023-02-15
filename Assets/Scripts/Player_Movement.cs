using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _anim;
    private Rigidbody2D _rb;
    

    [Header("Player Variables")]
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private float _fallForce = 5f;
    [SerializeField] private float _bufferTime = 0.1f;
    [SerializeField] private float _coyoteTime = 0.1f;

    private bool falling = true;
    private bool buffering = false;
    private float bufferJumpCountdown;
    private float coyoteTimeCounter;
    private bool facingRight = true;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        bufferJumpCountdown = _bufferTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fall();
            falling = true;
        }

        //! COYOTE TIME (CAN JUMP JUST AFTER LEAVING A PLATFORM)
        if (Grounded())
        {
            coyoteTimeCounter = _coyoteTime;
            falling = false;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(_rb.velocity.y < 0)
        {
            falling = true;
        }

        MaxFallSpeed();
        BufferJump();

        Falling();
        Checks();
    }

    private void FixedUpdate()
    {
        //! HORIZONTAL MOVEMENT OF THE PLAYER
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _movementSpeed
                                    , _rb.velocity.y
                                    );

        //! FLIP THE SPRITE TO THE DIRECTION YOU MOVE
        if(
            (_rb.velocity.x > 0 && facingRight == false) || 
            (_rb.velocity.x < 0 && facingRight == true)
            )
        {
            FlipSprite();
        }
    }

    private void Jump()
    {
        if (coyoteTimeCounter > 0)
        {
            _rb.velocity = new Vector2(0, _jumpForce);
            falling = false;
            buffering = false;
        }
        else
        {
            buffering = true;
        }
    }

    private void Fall()
    {
        if (!falling && _rb.velocity.y > 0)
        {
            _rb.velocity = _rb.velocity/2;
        }

        coyoteTimeCounter = 0f;
    }

    //! INCREASE GRAVITY IF YOU ARE FALLING
    private void Falling()
    {
        if (falling)
        {
            _rb.gravityScale = 4;
        }
        else
        {
            _rb.gravityScale = 2;
        }
    }

    //! CHECK IF THE PLAYER IS IN THE GROUND
    private bool Grounded()
    {
        if (Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer)
            || Physics2D.OverlapCircle(_groundCheck.position + new Vector3(0.12f, 0, 0), 0.1f, _groundLayer)
            || Physics2D.OverlapCircle(_groundCheck.position + new Vector3(-0.12f, 0, 0), 0.1f, _groundLayer))
        {
            return true;
        }
        else { return false; }
    }

    //! IF YOU ARE FALLING TOO FAST YOU SLOW DOWN
    private void MaxFallSpeed()
    {

        if (_rb.velocity.y < -_fallForce)
        {
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _fallForce);
        }
    }

    private void BufferJump()
    {
        //! START THE BUFFERING
        if (buffering)
        {
            bufferJumpCountdown -= Time.deltaTime;
        }
        else
        {
            buffering = false;
            bufferJumpCountdown = _bufferTime;
        }

        //! IF THE BUFFERING REACH 0 RESET THE TIMER
        if (bufferJumpCountdown <= 0)
        {
            bufferJumpCountdown = _bufferTime;
            buffering = false;
        }

        if (Grounded() && bufferJumpCountdown < _bufferTime)
        {
            Jump();
        }
    }

    private void FlipSprite()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        facingRight = !facingRight;
    }

    //! CHECKS STATE TO PLAY AN ANIMATION
    private void Checks()
    {
        if (!Grounded() && falling == false)
        {
            //Play Jumping animation
            ChangeAnimationState("penguin_jumping");
        }
        if (!Grounded() && falling == true)
        {
            //Play Falling animation
            ChangeAnimationState("penguin_falling");
        }
        if (Grounded())
        {
            if (falling == false && _rb.velocity.x == 0)
            {
                //Play Iddle animation
                ChangeAnimationState("penguin_idle");
            }
            if (falling == false && _rb.velocity.x != 0)
            {
                //Play Walking animation
                ChangeAnimationState("penguin_walking");
            }
        }
    }

    void ChangeAnimationState(string newState)
    {
        //! Stop the same animation to play again
        if (currentState == newState) return;

        //! Play the new animation
        _anim.Play(newState);
        currentState = newState;
    }
}
