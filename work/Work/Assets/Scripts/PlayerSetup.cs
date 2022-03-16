using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField] private Behaviour[] componentsToDisable;
    [SerializeField] private string remoteLayerName = "RemotePlayer";


    private void Start() {

        if (!isLocalPlayer) {

            DisableComponents();
            AssignRemoteLayer();
        }
        GetComponent<Player>().Setup();
    }

    public override void OnStartClient() {

        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();

        Player _player = GetComponent<Player>();
        GameManager.RegisterPlayer(_netID, _player);
    }

    private void AssignRemoteLayer() {

        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    private void DisableComponents() {

        for (int i = 0; i < componentsToDisable.Length; i++)
            componentsToDisable[i].enabled = false;
    }

    private void OnDisable() {

        GameManager.UnRegisterPlayer(transform.name);
    }
}