using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public bool hasElement;
    public GameObject element;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetElement(GameObject e)
    {
        element = e;
    }
}
