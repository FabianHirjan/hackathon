using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvscript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 15;
    public float jumpspeed;
    private int grounded = 0;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

           Vector3 eulerRotation = transform.rotation.eulerAngles;
     transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(eulerRotation.x, -180, eulerRotation.z);
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(eulerRotation.x, 0, eulerRotation.z);
            anim.SetTrigger("trg");
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            print(grounded);
            if (grounded == 1)
            {
                rb.AddForce(new Vector2(0, jumpspeed * Time.deltaTime), ForceMode2D.Impulse);
                StartCoroutine(ExecuteAfterTime(1));
            }
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);

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

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = 0;
        }
    }

}
