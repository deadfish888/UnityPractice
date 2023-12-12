using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;

    Rigidbody2D m_rb;

    bool isGround;

    GameController m_gc;

    public AudioSource aus;

    public AudioClip jumpSound;

    public AudioClip loseSound;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();   
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isSpaceBarPressed = Input.GetKeyDown(KeyCode.Space);
        if (isSpaceBarPressed && isGround)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            isGround = false;

            if (aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            if (aus && loseSound && !m_gc.IsOver())
            {
               // Destroy(m_rb);
                aus.PlayOneShot(loseSound);
            }
            m_gc.SetOver(true);
            Debug.Log("Over...");
        }
    }
}
