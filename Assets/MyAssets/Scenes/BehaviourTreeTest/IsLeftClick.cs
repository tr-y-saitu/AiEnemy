using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Example/IsWPressed")]
public class IsLeftClick : Condition
{
    public BoolReference isMoving = new BoolReference(VarRefMode.DisableConstant);

    public override bool Check()
    {
        return isMoving.Value;
    }
}
