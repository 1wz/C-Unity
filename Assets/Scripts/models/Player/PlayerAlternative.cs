using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlternative : PlayerAbstract
{
    void FixedUpdate()
    {

        //Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        RB.AddForce(new Vector3(Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y")) * forse);
    }
}
