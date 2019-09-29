using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Philosopher : MonoBehaviour
{
    //public Controller controller;
    public int id;
    public string name;
    private int N = 5;
    private string states;

    private Animator animator;
    public float speed;

    Vector2 move;
    private Rigidbody2D rb;

    public InputPlayer Input;
    public GameObject aButton;
    public bool isEating;

    public GameObject chair;
    public Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Controller>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log("Philospher " + name + " is thinking");   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isEating)
        {
            Move();
        }else if (controller.states[GetNumberOfChair(chair)] == "Hungry")
        {
            TakeForks(chair);
           
        }

        if (Input.ButtonIsDown() && aButton.activeSelf)
        {
            isEating = true;
            aButton.SetActive(false);
            TakeForks(chair);
            
        }


    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isEating)
        {
            aButton.SetActive(true);
            chair = collision.gameObject;
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isEating)
        {
            aButton.SetActive(false);
        }
        
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

    IEnumerator  Eat(int i)
    {
        isEating = true;
        yield return new WaitForSeconds(2);
        controller.dishes[i].GetComponent<Animator>().SetBool("red", false);
        controller.dishes[i].GetComponent<Animator>().SetBool("green", false);
        controller.dishes[i].GetComponent<Animator>().SetBool("white",true);
        LeaveForks(i);
    }
   
    void TakeForks(GameObject chair)
    {

        int i = GetNumberOfChair(chair);
        controller.dishes[i].GetComponent<Animator>().SetBool("white", false);
        controller.dishes[i].GetComponent<Animator>().SetBool("red", true);
        controller.states[i] = "Hungry";
        Check(i);
        
        
        
    }
    void LeaveForks(int i)
    {
        StopAllCoroutines();
        isEating = false;
        controller.states[i] = "Thinking";
        controller.forks[i].SetActive(true);
        controller.forks[(i + 1) % N].SetActive(true);

    }


    void Check(int i)
    {
       if(controller.states[i] == "Hungry" && controller.states[Left(i)]!= "Eating" && controller.states[Right(i)] != "Eating")
        {
            controller.states[i] = "Eating";
            controller.forks[i].SetActive(false);
            controller.forks[(i + 1) % N].SetActive(false);
     
            controller.dishes[i].GetComponent<Animator>().SetBool("green",true);
            StartCoroutine(Eat(i));
        }
    }

    int Left(int i)
    {
        return (i+N-1)%N;
    }
    int Right(int i)
    {
        return (i +1) % N;
    }

    int GetNumberOfChair(GameObject chair)
    {
        for (int i = 0; i < 5; i++)
        {
            if (controller.chairs[i].name == chair.name)
            {
                Debug.Log(controller.chairs[i].name);
                return i;
            }
        }
        return -1;
    }

    

}
