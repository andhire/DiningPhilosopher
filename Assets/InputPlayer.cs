using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    private string horizontalAxis;
    private string verticalAxis;
    private string aButton;
    private string triggerAxis;
    private int controllerNumber;

    public float Horizontal { get; set; }
    public float Thrust { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(controllerNumber > 0)
        {
            Horizontal = Input.GetAxis(horizontalAxis);
            Thrust = Input.GetAxis(verticalAxis);
        }
    }
    internal bool ButtonIsDown()
    {
        return Input.GetButtonDown(aButton);
    }
    internal void SetControllerNumber(int number)
    {
        controllerNumber = number;
        horizontalAxis = "J" + controllerNumber + "Horizontal";
        verticalAxis = "J" + controllerNumber + "Vertical";
        aButton = "J" + controllerNumber + "A";
        triggerAxis = "J" + controllerNumber + "Trigger";
    }
}
