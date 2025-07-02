using UnityEngine;
using MBT;

public class InputToBlackboard : MonoBehaviour
{
    public Blackboard blackboard;

    void Update()
    {
        // Blackboardに登録されているBoolオブジェクトから(isMoving)で名前検索してそれを更新し続ける
        blackboard.GetVariable<BoolVariable>("isMoving").Value = Input.GetKey(KeyCode.W);
    }
}
