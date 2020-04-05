using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TileState tileState;
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
            controller.MakeMove(tileState, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            controller.MakeMove(tileState, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            controller.MakeMove(tileState, 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            controller.MakeMove(tileState, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            controller.MakeMove(tileState, 4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            controller.MakeMove(tileState, 5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            controller.MakeMove(tileState, 6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            controller.MakeMove(tileState, 7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            controller.MakeMove(tileState, 8);
        }
    }
}
