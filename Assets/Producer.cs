using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer : MonoBehaviour
{

    private Animator animator;
    public float speed;
    Vector2 move;
    private Rigidbody2D rb;
    public InputPlayer Input;
    public GameObject aButton;

    private bool isInChair;
    private bool hasPizza;
    public GameObject chair;
    public GameObject pizzaObj;
    public GameObject pizzaCarring;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Check();
    }

    void Move()
    {
        float horizontal = Input.Horizontal;
        float vertical = Input.Thrust;
        move.x = horizontal;
        move.y = -vertical;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("speed", move.sqrMagnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        isInChair = true;
        chair = collision.gameObject;
        aButton.SetActive(true);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInChair = false;
        aButton.SetActive(false);
    }
    void Check()
    {
        if (isInChair)
        {
            if (chair.name == "ChairConsumer" && gameObject.name == "Consumer")
            {
                if (Input.ButtonIsDown())
                {
                    
                    Destroy(pizzaCarring);
                    pizzaCarring = null;
                }
            }

            if (chair.name == "ChairProducer" && gameObject.name == "Producer")
            {
                if (Input.ButtonIsDown())
                {
                    GameObject pizza = Instantiate(pizzaObj, transform);
                    pizzaCarring = pizza;
                }
                
            }

            if (chair.name == "Buffer")
            {
                if (Input.ButtonIsDown() && gameObject.name == "Producer" && !chair.GetComponent<Chair>().hasElement)
                {
                    pizzaCarring.transform.SetParent(chair.transform);
                    pizzaCarring.transform.position = chair.transform.position;
                    chair.GetComponent<Chair>().hasElement = true;
                    chair.GetComponent<Chair>().SetElement(pizzaCarring);
                    pizzaCarring = null;
                }
                if (Input.ButtonIsDown() && gameObject.name == "Consumer" && chair.GetComponent<Chair>().hasElement )
                {
                    pizzaCarring = chair.GetComponent<Chair>().element;
                    pizzaCarring.transform.SetParent(transform);
                    pizzaCarring.transform.position = transform.position;
                    chair.GetComponent<Chair>().hasElement = false;
                }
            }
        }
        
    }


    
}
