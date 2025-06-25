using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Example/MoveLeftRight")]
public class MoveLeftRight : Leaf
{
    public float speed = 0.1f;
    public float changeDirTime = 1f; // •ûŒüØ‚è‘Ö‚¦ŠÔŠui•bj

    private float timer = 0f;
    private int direction = 1; // 1 = ‰E, -1 = ¶

    public override NodeResult Execute()
    {
        timer += Time.deltaTime;

        if (timer > changeDirTime)
        {
            direction *= -1;
            timer = 0f;
        }

        Vector3 move = Vector3.right * direction * speed * Time.deltaTime;
        transform.position += move;

        return NodeResult.success;
    }
}
