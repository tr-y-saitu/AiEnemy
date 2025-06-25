using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Example/MoveForward")]
public class MonoForward : Leaf  // �N���X���ƃt�@�C��������v���Ă��邩���m�F���Ă�������
{
    public float speed = 2f;

    public override NodeResult Execute()
    {
        Vector3 forward = Vector3.forward * speed * Time.deltaTime;
        transform.position += forward;
        return NodeResult.success;
    }
}
