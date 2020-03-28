using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAi : MonoBehaviour
{

    public int id;
    public GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller.MakeMove(id, Random.Range(0, 9));
    }
}
