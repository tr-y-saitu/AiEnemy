using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Example/Jump")]
public class Jump : Leaf
{
    public float jumpPower = 1.0f;

    public override NodeResult Execute()
    {
        Debug.Log("�W�����v�I");
        transform.position += Vector3.up * jumpPower;
        return NodeResult.success;
    }
}
