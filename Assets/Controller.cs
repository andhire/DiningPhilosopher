using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public const int N = 5;
    public  int number = N;
    public string[] states = new string[N];
    public int[] semaphore = new int[N];
    public int mutex = 1;

    public GameObject[] forks;
    public GameObject[] dishes;
    public GameObject[] chairs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
