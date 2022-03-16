using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour {

	private void OnTriggerEnter(Collider col) {

        if (col.tag == "Test" && gameObject.tag == "Center")
            UIManager.GetInstance().EndGame("Red");
        else if (col.tag == "Test" && gameObject.tag == "Player") {

            Destroy(gameObject);
        }
    }
}
