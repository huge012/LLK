using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    [SerializeField] private Behaviour[] disableOnDeath;

    private bool[] wasEnabled;



    public void Setup() {

        wasEnabled = new bool[disableOnDeath.Length];

        for (int i = 0; i < wasEnabled.Length; i++)
            wasEnabled[i] = disableOnDeath[i].enabled;
        SetDefaults();
    }

    public void SetDefaults() {

        Collider _col = GetComponent<Collider>();

        for (int i = 0; i < disableOnDeath.Length; i++)
            disableOnDeath[i].enabled = wasEnabled[i];
        if (_col != null)
            _col.enabled = true;
    }
}
