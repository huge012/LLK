using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject red;
    public GameObject blue;

    public void Spawn(float _x, float _z, string _color) {

        if (_color == "Red") {

            GameObject obj = Instantiate(red, new Vector3(_x, 0.5f, _z), Quaternion.identity);
        }
        else if (_color == "Blue") {

            GameObject obj = Instantiate(blue, new Vector3(_x, 0.5f, _z), Quaternion.identity);
        }
    }
}
