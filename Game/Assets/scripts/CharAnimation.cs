// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class CharAnimation : MonoBehaviour {

    private Animator anim;

    void Start () {

        anim = GetComponent<Animator> ();
    }

    void Update () {
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
            anim.SetBool ("run", true);
        } else {
            anim.SetBool ("run", false);
        }

        if (Input.GetKey (KeyCode.Space)) {
            anim.SetTrigger ("isJumping");
        }
    }

}