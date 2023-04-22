using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float playerSpeed;
    public Animator anim;
    public static PlayerController instance;
    public string areaTransName;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    public bool canMove;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(canMove)
        {
            rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * playerSpeed;
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
        anim.SetFloat("MoveX", rigidBody.velocity.x);
        anim.SetFloat("MoveY", rigidBody.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if(canMove)
            {
                anim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(0.5f, 0.7f, 0f);
        topRightLimit = topRight - new Vector3(0.5f, 0.7f, 0f);
    }
}
