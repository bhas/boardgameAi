using Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Player : MonoBehaviour
    {
        public PlayerEnum player;
        bool isTurn;

        // Awake is called before start
        void Awake()
        {
            GameController.gameController.changeTurnEvent.AddListener(OnChangeTurnEvent);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (isTurn)
            {
                DetectMouseClick();
            }
        }

        private void OnChangeTurnEvent(PlayerEnum player)
        {
            isTurn = this.player == player;
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
                        GameController.gameController.MakeMove(player, tile.id);
                    }
                }
            }
        }
    }
}