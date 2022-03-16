using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

    public float speed;
    public float lookSensivity;

    private PlayerMotor motor;

    public bool countCheck;



    private void Start() {

        motor = GetComponent<PlayerMotor>();

        GameManager.GetInstance().player.Add(gameObject);
        
    }


    private void Update() {

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        motor.Move(_velocity);
        
        if (Input.GetMouseButton(0)) {

            float _xRot = Input.GetAxisRaw("Mouse Y");
            float _yRot = Input.GetAxisRaw("Mouse X");

            Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensivity;
            Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensivity;

            motor.Rotate(_rotation);
            motor.RotateCamera(_cameraRotation);
        }

        if (!countCheck) {

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        else {

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

    }
}
