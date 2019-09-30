using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducerController : MonoBehaviour
{
    public GameObject[] buffer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int BufferSize()
    {
        int bSize = 0;
        foreach(GameObject e in buffer)
        {
            if (e.GetComponent<Chair>().hasElement)
            {
                bSize++;
            }    
        }
        return bSize;
    }
}
