using UnityEngine;
using MBT;

public class InputToBlackboard : MonoBehaviour
{
    public Blackboard blackboard;

    void Update()
    {
        blackboard.GetVariable<BoolVariable>("isMoving").Value = Input.GetKey(KeyCode.W);
    }
}
