using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] wayPoints;
    public float speed = 0.3f;
    private int cur = 0;

    private void FixedUpdate() {
        if (transform.position != wayPoints[cur].position) {
            Vector2 pos = Vector2.MoveTowards(transform.position, wayPoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else {
            // if waypoints array end is reached start from beginning.
            cur = (cur + 1) % wayPoints.Length;
        }

        Vector2 dir = wayPoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    /// <summary>
    /// Method checks if we collide with pacman, if so destroy him!!
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "pacman") {
            Destroy(other.gameObject);

            // game over or x lives left
            
        }
    }
}
