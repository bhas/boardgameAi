using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Tile tile;

    // Start is called before the first frame update
    void Start()
    {
        tile.SetState(TileState.Circle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
