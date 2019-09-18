using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class PhilosopherUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Animator animator;
    private float y;
    public float speed;
    public float movementSpace;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(0, speed * Time.deltaTime, 0); //Up movement
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0); //Down movement
        

    }

   
}


class Philosopher
{
    void Run()
    {
        Think();
        TakeForks();
        Eat();
        LeaveForks();
    }

    IEnumerator Think()
    {
        //Salirse de la mesa
        Debug.Log("Thinking");
        yield return new WaitForSeconds(3);
    }

    IEnumerator Eat()
    {
        //Go to the table
        Debug.Log("Eating");
        yield return new WaitForSeconds(3);
    }

    void TakeForks()
    {

    }
    void LeaveForks()
    {

    }
    


}
