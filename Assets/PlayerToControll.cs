using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToControll : MonoBehaviour
{
    private List<int> assignedControllers = new List<int>();
    public GameObject Phil;
    bool isPressed = false;
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
        GameObject player = Instantiate(Phil);
        Debug.Log(controller);
        player.GetComponent<Philosopher>().Input.SetControllerNumber(controller);

    }
}
