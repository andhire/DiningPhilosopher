using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToControll : MonoBehaviour
{
    private List<int> assignedControllers = new List<int>();
    public GameObject Phil;
    bool isPressed = false;
    int numberOfPhilosophers = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (true)
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
}
