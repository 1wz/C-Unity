using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrand : PlayerAbstract
{

    void FixedUpdate()
    {

        RB.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized*forse);
    }

    
}
