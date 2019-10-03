using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducerController : MonoBehaviour
{
    public GameObject[] buffer;
    public List<GameObject> players = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Block();   
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

    void Block()
    {
        if (players.Count == 2)
        {
            if (players[0].GetComponent<Producer>().isInChair && players[1].GetComponent<Producer>().isInChair &&
                 players[0].GetComponent<Producer>().chair.name == "Buffer" && players[1].GetComponent<Producer>().chair.name == "Buffer" &&
                players[0].GetComponent<Producer>().hasPizza && !players[1].GetComponent<Producer>().hasPizza)
            {
                players[0].GetComponent<Producer>().isStop = true;
            }
            else
            {
                players[0].GetComponent<Producer>().isStop = false;
            }
        }
        if (players.Count >= 4)
        {
            if (players[0].GetComponent<Producer>().isInChair && players[2].GetComponent<Producer>().isInChair && 
                players[0].GetComponent<Producer>().chair.name == "Buffer" && players[2].GetComponent<Producer>().chair.name == "Buffer" &&
               players[0].GetComponent<Producer>().hasPizza && players[2].GetComponent<Producer>().hasPizza)
            {
                players[0].GetComponent<Producer>().isStop = true;
            }
            else
            {
                players[0].GetComponent<Producer>().isStop = false;
            }

            if (players[1].GetComponent<Producer>().isInChair && players[3].GetComponent<Producer>().isInChair &&
                players[1].GetComponent<Producer>().chair.name == "Buffer" && players[3].GetComponent<Producer>().chair.name == "Buffer")
            {
                players[1].GetComponent<Producer>().isStop = true;
            }
            else
            {
                players[1].GetComponent<Producer>().isStop = false;
            }
        }
        
    }
}
