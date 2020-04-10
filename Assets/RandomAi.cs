using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAi : MonoBehaviour
{

    public TileState tileState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameController.instance.MakeMove(tileState, Random.Range(0, 9));
    }
}
