using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Example/MoveForward")]
public class MonoForward : Leaf  // クラス名とファイル名が一致しているかも確認してください
{
    public float speed = 2f;

    public override NodeResult Execute()
    {
        Vector3 forward = Vector3.forward * speed * Time.deltaTime;
        transform.position += forward;
        return NodeResult.success;
    }
}
