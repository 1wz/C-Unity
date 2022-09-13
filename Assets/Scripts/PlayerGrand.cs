using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrand : PlayerAbstract
{

    void FixedUpdate()
    {

        //Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        RB.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized*Forse);
    }
}
