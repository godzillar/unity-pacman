using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;

    Vector2 dest = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
    }

    /// <summary>
    /// Method called at fixed time interval.
    /// </summary>
    void FixedUpdate() {
        Vector2 pos = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(pos);

        if((Vector2)transform.position == dest) {
            if(Input.GetKey(KeyCode.UpArrow) && Valid(Vector2.up)) {
                dest = (Vector2)transform.position + Vector2.up;
            }
            if(Input.GetKey(KeyCode.DownArrow) && Valid(Vector2.down)) {
                dest = (Vector2)transform.position + Vector2.down;
            }
            if(Input.GetKey(KeyCode.LeftArrow) && Valid(Vector2.left)) {
                dest = (Vector2)transform.position + Vector2.left;
            }
            if(Input.GetKey(KeyCode.RightArrow) && Valid(Vector2.right)) {
                dest = (Vector2)transform.position + Vector2.right;
            }
        }

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    /// <summary>
    /// Checks if gameobject hits wall at next position.
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    private bool Valid(Vector2 dir) {
        Vector2 pos = transform.position;
        // cast imaginary line from 'next to pacman' to 'pacman'
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
