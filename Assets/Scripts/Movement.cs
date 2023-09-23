using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mov_state = 1;
    public bool spin_state = true;
    public float speed = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer look;
    public float minY=-4, maxY=4, minX=-8, maxX=8;
    public Manager manager;
    //public GameObject playerRed;
    //public GameObject playerGreen;
    // Start is called before the first frame update
    void Start()
    {
        rb= this.gameObject.GetComponent<Rigidbody2D>();
        look = this.gameObject.GetComponent<SpriteRenderer>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v != 0)
            h = 0;
        print(h + "," + v);
        Vector2 position = transform.position;
        position.x += mov_state * h * Time.deltaTime*speed;
        position.y += mov_state * v * Time.deltaTime * speed;
        float clampedY = Mathf.Clamp(position.y, minY, maxY);
        if (!Mathf.Approximately(clampedY, position.y))
        {
            position.y = clampedY;
        }
        float clampedX = Mathf.Clamp(position.x, minX, maxX);

        if (!Mathf.Approximately(clampedX, position.x))
        {
            position.x = clampedX;
        }
        transform.position = position;
        if (mov_state == 1&& spin_state)
        {
            look.color = new Color(0f, 1f, 0.2048221f,1f);
        }
        else if (mov_state == -1 && spin_state)
        {
            look.color = new Color(0f, 1f, 0.2048221f, 0.5f);
        }
        else if (mov_state == 1 && !spin_state)
        {
            look.color = new Color(1f, 0f, 0f, 1f);
        }
        else if (mov_state == -1 && !spin_state)
        {
            look.color = new Color(1f, 0f, 0f, 0.5019608f);
        }
        if(mov_state==-1)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (mov_state == 1)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
        int n = list.Length;
        if (n > 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                mov_state = -1 * mov_state;
            }
        }
        if(n<2)
        {
            mov_state = 1;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NotGate")
        {
            if (collision.gameObject.GetComponent<NotGate>().active==1)
            {
                this.gameObject.GetComponent<Movement>().spin_state = !this.gameObject.GetComponent<Movement>().spin_state;
            }
        }
        if (collision.gameObject.tag == "ControlGate")
        {
            if (spin_state)
            {
                collision.gameObject.GetComponent<ControlGate>().work = 1;
            }
        }
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
            manager.GameOver();
        }
        if (collision.gameObject.tag == "Checker")
        {
            if(spin_state)
            {
                manager.gamePoints += 1;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
