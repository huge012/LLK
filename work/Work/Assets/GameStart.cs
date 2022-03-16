using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    public GameObject lobbyManager;

    private void Start() {

        Instantiate(lobbyManager);
    }
}
