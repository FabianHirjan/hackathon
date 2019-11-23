using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvscript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 15;
    public float jumpspeed;
    private bool usable = true;
    private int grounded = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            print(grounded);
            if (grounded == 1 && usable == true)
            {
                rb.AddForce(new Vector2(0, jumpspeed * Time.deltaTime), ForceMode2D.Impulse);
                usable = false;
                StartCoroutine(ExecuteAfterTime(1));
            }
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                usable = true;

            }
        }

    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Stops the player from being affected by gravity while on ladder
        if (other.tag == "scara")
            rb.gravityScale = 0;
        movable = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Stops the player from being affected by gravity while on ladder
        if (other.tag == "scara")
            rb.gravityScale = 1;
        movable = false;
    }
    
    */

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            print("Grounded");
            grounded = 1;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = 0;
            rb.constraints = RigidbodyConstraints2D.None;

        }
    }
}
