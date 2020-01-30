using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text healthDisplay;
    public float speed;
    private float input;
    public int health;
    Rigidbody2D rb;
    Animator anim;
    public GameObject losePanel;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthDisplay.text = health.ToString();
    }

    private void Update()
    {
        if (input != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Storing player's input
        input = Input.GetAxisRaw ("Horizontal");

        //Moving player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damangeAmount)
    {
        source.Play();
        health -= damangeAmount;
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
