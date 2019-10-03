using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerToControll : MonoBehaviour
{
    private List<int> assignedControllers = new List<int>();
    public GameObject Phil;
    public GameObject Producer;
    bool isPressed = false;
    int numberOfPhilosophers = 0;

    private ProducerController producerController;
    // Start is called before the first frame update
    void Start()
    {
        producerController = FindObjectOfType<ProducerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name != "ProductConsumer")
        {
            for (int i = 1; i <= 5; i++)
            {
                
                if (assignedControllers.Contains(i))
                {
                    continue;
                }

                if (Input.GetButton("J" + i + "A"))
                {
                   
                    isPressed = true;
                    AssignController(i);
                    break;
                }
            }
        }
        else
        {
            for (int i = 1; i <= 4; i++)
            {

                if (assignedControllers.Contains(i))
                {
                    continue;
                }

                if (Input.GetButton("J" + i + "A"))
                {

                    isPressed = true;

                    AssignProducerController(i);

                    break;
                }
            }
        }

    }



    public void AssignController(int controller)
    {
        assignedControllers.Add(controller);
        //Create player
        GameObject player = Instantiate(Phil);

        //Set color to each player
        switch (numberOfPhilosophers)
        {
            case 0:
                player.GetComponent<SpriteRenderer>().color = Color.blue;
                break;

            case 1:
                player.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;

            case 2:
                player.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 3:
                player.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 4:
                break;

        }
        
        player.GetComponent<Philosopher>().id = numberOfPhilosophers++;
        //Set controller to his player
        player.GetComponent<Philosopher>().Input.SetControllerNumber(controller);

        
    }

    public void AssignProducerController(int controller)
    {
       
        assignedControllers.Add(controller);
        //Create player
        GameObject player = Instantiate(Producer);

        //Set color to each player
        switch (numberOfPhilosophers)
        {
            case 0:
                player.GetComponent<SpriteRenderer>().color = Color.blue;
                player.name = "Producer";
                player.GetComponent<Producer>().speed = 0.8f;
                break;

            case 1:
                player.GetComponent<SpriteRenderer>().color = Color.yellow;
                player.name = "Consumer";
                break;
            case 2:
                player.GetComponent<SpriteRenderer>().color = Color.red;
                player.name = "Producer";
                player.GetComponent<Producer>().speed = 0.8f;
                break;

            case 3:
                player.GetComponent<SpriteRenderer>().color = Color.black;
                player.name = "Consumer";
                break;

        }

        //Set controller to his player
        player.GetComponent<Producer>().Input.SetControllerNumber(controller);
        numberOfPhilosophers++;
        producerController.players.Add(player);


    }
}
