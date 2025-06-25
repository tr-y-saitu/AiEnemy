using MBT;
using static UnityEngine.GraphicsBuffer;
using UnityEngine;

public Transform target;

public override NodeResult Execute()
{
    if (target != null)
    {
        Vector3 forward = Vector3.forward * speed * Time.deltaTime;
        target.position += forward;
        return NodeResult.success;
    }
    return NodeResult.failure;
}
