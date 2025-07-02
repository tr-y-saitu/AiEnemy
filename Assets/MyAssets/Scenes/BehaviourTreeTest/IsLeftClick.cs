using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Example/IsLeftClick")]
public class IsLeftClick : Condition
{
    public BoolReference isLeftClick = new BoolReference(VarRefMode.DisableConstant);

    public override bool Check()
    {
        return isLeftClick.Value;
    }
}
