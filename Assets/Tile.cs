using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileState state;
    public GameObject cross;
    public GameObject circle;

    public void SetState(TileState state)
    {
        this.state = state;

        switch (state)
        {
            case TileState.Empty:
                cross.SetActive(false);
                circle.SetActive(false);
                break;
            case TileState.Cross:
                cross.SetActive(true);
                circle.SetActive(false);
                break;
            case TileState.Circle:
                cross.SetActive(false);
                circle.SetActive(true);
                break;
            default:
                throw new NotImplementedException();
        }
    }
}

public enum TileState
{
    Empty = 0,
    Cross = 1,
    Circle = 2
}
