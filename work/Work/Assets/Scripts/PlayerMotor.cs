using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField] private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rigid;



    private void Start() {

        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {

        PerformMovement();
        PerformRotation();
    }


    public void Move(Vector3 _velocity) {

        velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation) {

        rotation = _rotation;
    }
    public void RotateCamera(Vector3 _cameraRotation) {

        cameraRotation = _cameraRotation;
    }

    private void PerformMovement() {

        if (velocity != Vector3.zero)
            rigid.MovePosition(rigid.position + velocity * Time.fixedDeltaTime);
    }
    private void PerformRotation() {

        rigid.MoveRotation(rigid.rotation * Quaternion.Euler(rotation));

        if (cam != null)
            cam.transform.Rotate(-cameraRotation);
    }
}
