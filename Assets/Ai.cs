using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{

    public TileState tileState;

    // Start is called before the first frame update
    void Start()
    {
        //GameController.gameController.nextMoveEvent.AddListener(AiMove);
    }

    // Update is called once per frame
    void Update()
    {
        GameController.gameController.nextMoveEvent.AddListener(AiMove);
    }

    public void AiMove(bool isPlayerCross)
    {
        if (!isPlayerCross)
        {
            GameController.gameController.MakeMove(tileState, Random.Range(0, 9));
        }
    }
}
