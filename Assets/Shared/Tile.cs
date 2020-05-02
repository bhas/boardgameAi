using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public class Tile : MonoBehaviour
    {
        public int id;
        public PlayerEnum? state;
        public GameObject player1;
        public GameObject player2;

        public void SetState(PlayerEnum? state)
        {
            this.state = state;

            player1.SetActive(state == PlayerEnum.Player1);
            player2.SetActive(state == PlayerEnum.Player2);
        }
    }
}