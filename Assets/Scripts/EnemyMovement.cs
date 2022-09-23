using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public int dir;

    [Header("Grounding")]
    public bool grounded;
    public LayerMask groundMask;
    public float raySpread;
    public float rayLength = 0.1f;
    public float rayLengthWall = 0.2f;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;

        sr = GetComponent<SpriteRenderer>();

        grounded = true;
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2d.velocity;
        vel.x = dir * speed;

        CheckLocation();

        rb2d.velocity = vel;
    }

    void CheckLocation()
    {
        // FROM TUTORIAL:
        // Vector3 raycastStart = transform.position + Vector3.up * groundRayLength;

        //set starting positions
        Vector3 raycastStart = transform.position;
        Vector3 raycastStartLeft = transform.position + (raySpread * Vector3.left);
        Vector3 raycastStartRight = transform.position + (raySpread * Vector3.right);

        Vector3 raycastStartLeftSide = raycastStartLeft + Vector3.up;
        Vector3 raycastStartRtSide = raycastStartRight + Vector3.up;

        //send raycasts
        RaycastHit2D hit = Physics2D.Raycast(raycastStart, Vector3.down, rayLength, groundMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastStartLeft, Vector3.down, rayLength, groundMask);
        RaycastHit2D hitRight = Physics2D.Raycast(raycastStartRight, Vector3.down, rayLength, groundMask);

        RaycastHit2D hitLeftSide = Physics2D.Raycast(raycastStartLeftSide, Vector3.left, rayLengthWall, groundMask);
        RaycastHit2D hitRightSide = Physics2D.Raycast(raycastStartRtSide, Vector3.right, rayLengthWall, groundMask);

        //draw lines
        Debug.DrawLine(raycastStart, raycastStart + Vector3.down * rayLength, Color.red);
        Debug.DrawLine(raycastStartLeft, raycastStartLeft + Vector3.down * rayLength, Color.red);
        Debug.DrawLine(raycastStartRight, raycastStartRight + Vector3.down * rayLength, Color.red);

        Debug.DrawLine(raycastStartLeftSide, raycastStartLeftSide + Vector3.left * rayLengthWall, Color.blue);
        Debug.DrawLine(raycastStartRtSide, raycastStartRtSide + Vector3.right * rayLengthWall, Color.blue);

        //do the updates
        UpdateGrounding(hit, hitLeft, hitRight);
        UpdateDir(hitLeft, hitRight, hitLeftSide, hitRightSide);
    }

    //if we get SUPER done, we can have the enemies jump over obstacles,
    //and turn only when they hit a wall
    //but it's not necessary now
    void UpdateDir(RaycastHit2D hitLeft, RaycastHit2D hitRight, RaycastHit2D hitLeftWall, RaycastHit2D hitRightWall)
    {
        if (!grounded) dir = 0;
        if (dir == 0) dir = 1; //land facing right
        if (hitLeft.collider == null)
        {
            sr.flipX = false;
            dir = 1;
        }
        else if (hitRight.collider == null)
        {
            sr.flipX = true;
            dir = -1;
        }

        if (hitLeftWall.collider != null)
        {
            Debug.Log("I hit" + hitLeftWall.collider);
            sr.flipX = false;
            dir = 1;
        }
        if (hitRightWall.collider != null)
        {
            Debug.Log("I hit" + hitRightWall.collider);
            sr.flipX = true;
            dir = -1;
        }
    }

    void UpdateGrounding(RaycastHit2D hit, RaycastHit2D hitLeft, RaycastHit2D hitRight)
    {
        if (hit.collider != null || hitLeft.collider != null || hitRight.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

}
