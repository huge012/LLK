using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_animation : MonoBehaviour {

    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim)
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            anim.SetFloat("vertical", v);
            anim.SetFloat("horizontal", h);
        }
    }
}
