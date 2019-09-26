using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Philosopher : MonoBehaviour
{
    //public Controller controller;
    public int id;
    public string name;
    private int N;
    private string[] states;

    private Animator animator;
    public float speed;

    Vector2 move;
    private Rigidbody2D rb;

    public InputPlayer Input;
    public GameObject aButton;
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //N = controller.number;
       // states = controller.states;
        Debug.Log("Philospher " + name + " is thinking");   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*Think();
        TakeForks();
        Eat();
        LeaveForks();*/
        Move();
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        aButton.SetActive(true);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        aButton.SetActive(false);
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

   
    
}
