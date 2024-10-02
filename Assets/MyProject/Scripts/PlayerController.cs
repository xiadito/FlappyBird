using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rb;

    [SerializeField] private float speed;

    [SerializeField] private float flyForce;

    bool canFly;
    bool isDead;

    [SerializeField] bool godModeOn;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDead) return;

        DetectClick();
        RotatePlayer();
        RotatePlayer();

    }

    private void FixedUpdate()
    {
        if (isDead) return;

        //player movement
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (canFly)
        {
            Fly();
        }

    }

    void DetectClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canFly = true;
        }
    }

    void Fly()
    {
        canFly = false;

        Vector2 _velocity = rb.velocity;
        _velocity.y = 0f;
        rb.velocity = _velocity;

        animator.SetTrigger("Fly");

        rb.AddForce(Vector2.up * flyForce);

    }

    void RotatePlayer()
    {
        //random.range()
        
        if (rb.velocity.y > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 10f);
        }
        else
        {
            float z = Mathf.Lerp(0, -90, -rb.velocity.y / 3f); 
            transform.eulerAngles = new Vector3(0, 0, z);
        }
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (godModeOn) return;

        if (_other.collider.CompareTag("Pipe") || _other.collider.CompareTag("Ground"))
        {
            isDead = true;
            animator.SetBool("isDead", isDead);
            GameManager.instance.GameOver();
        }
    }
}
