using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 move;
    private RaycastHit2D hit;
    public Vector2 mousePos;
    public Camera cam;
    public Rigidbody2D rb;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        move = new Vector3(x, y, 0);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //this stores the coordinates of the cursors position in mousePos
        if (mousePos.x < rb.position.x) //rb is the Player Object's Rigidbody component
        {
            transform.localScale = new Vector3(-16, 16, 1);
        }
        else
        {
            transform.localScale = new Vector3(16, 16, 1);
        }

        //Make sure we can move in this direction by casting a box there first, if the box returns null we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, move.y), Mathf.Abs(move.y * Time.deltaTime), LayerMask.GetMask("Player", "Wall"));
        if (hit.collider == null)
        {
            //Make this thing move
            transform.Translate(0, 15 * move.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(move.x, 0), Mathf.Abs(move.x * Time.deltaTime), LayerMask.GetMask("Player", "Wall"));
        if (hit.collider == null)
        {
            //Make this thing move
            transform.Translate(15 * move.x * Time.deltaTime, 0, 0);
        }
        //transform.Translate(0, 15 * move.y * Time.deltaTime, 0);
        //transform.Translate(15 * move.x * Time.deltaTime, 0, 0);

    }
}
