using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Example/MoveForward")]
public class MoveForward : Leaf
{
    public float speed = 2f;

    public override NodeResult Execute()
    {
        Vector3 forward = Vector3.forward * speed * Time.deltaTime;
        transform.position += forward;
        Debug.Log("MoveForward: ëOÇ…êiÇÒÇ≈Ç¢Ç‹Ç∑ÅBspeed=" + speed + ", deltaTime=" + Time.deltaTime);
        return NodeResult.success;
    }

}
