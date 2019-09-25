using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Philosopher : MonoBehaviour
{
    public Controller controller;
    public int id;
    public string name;
    private int N;
    private string[] states;

    private Animator animator;
    public float speed;
    GenericControls controls;
    Vector2 move;
    private Rigidbody2D rb;
    private void Awake()
    {
        controls = new GenericControls();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        N = controller.number;
        states = controller.states;
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

    void Think()
    {
        //Salirse de la mesa
        Debug.Log("Philosopher " + name + " is Thinking");
      
    }

    void Eat()
    {
        //Go to the table
        Debug.Log("Philosopher " + name + " is Eating");
        LeaveForks();
        //yield return new WaitForSeconds(3);
    }

    void TakeForks()
    {
        controller.mutex = 0;
        states[id] = "Hungry";
        Check(id);
        controller.mutex = 1;
        controller.semaphore[id] = 0;
        Eat();
        
    }
    void LeaveForks()
    {
        controller.mutex = 0;
        states[id] = "thinking";
        Check(Left(id));
        Check(Right(id));
        controller.mutex = 1;
        
    }

    int Left(int i)
    {
        return (i + N - 1) % N;
    }

    int Right(int i)
    {
        return (i + 1) % N;
    }

    void Check(int i)
    {
        if (states[i] == "Hungry" && states[Left(i)] != "Eating" && states[Right(i)] != "Eating")
        {
            states[i] = "Eating";
            controller.semaphore[id] = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.name == "Philosopher")
        {
            Eat();
        }
    }
    void Move()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("speed", move.sqrMagnitude);
    }

    
}
