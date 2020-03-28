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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            controller.MakeMove(id, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            controller.MakeMove(id, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            controller.MakeMove(id, 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            controller.MakeMove(id, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            controller.MakeMove(id, 4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            controller.MakeMove(id, 5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            controller.MakeMove(id, 6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            controller.MakeMove(id, 7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            controller.MakeMove(id, 8);
        }
    }
}
