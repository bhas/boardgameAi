using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TileState tileState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameController.gameController.nextMoveEvent.AddListener(PlayerMove);
        if (Input.GetMouseButtonDown(0))
        {
            DetectMouseClick();
        }
    }

    public void PlayerMove(bool isPlayerCross)
    {
        if (isPlayerCross)
        {
            DetectMouseClick();
        }
    }

    public void DetectMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Tile"))
                {
                    Tile tile = hit.collider.GetComponent<Tile>();
                    GameController.gameController.MakeMove(tileState, tile.id);
                }
            }
        }
    }
}
