using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            controller.MakeMove(id, 5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            controller.MakeMove(id, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            controller.MakeMove(id, 1);
        }
    }
}
