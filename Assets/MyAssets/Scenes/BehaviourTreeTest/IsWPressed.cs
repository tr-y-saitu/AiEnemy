using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Example/IsWPressed")]
public class IsWPressed : Condition
{
    public BoolReference isMoving = new BoolReference(VarRefMode.DisableConstant);

    public override bool Check()
    {
        return isMoving.Value;
    }
}
