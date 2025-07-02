using UnityEngine;
using MBT;

/// <summary>
/// Updateで登録されている変数の状態を監視、更新する
/// </summary>
/// NOTE: Behaviour Tree から参照できるように、Blackboardに変数を登録しておく必要がある。
public class InputToBlackboard : MonoBehaviour
{
    [SerializeField]
    Blackboard blackboard;  // 状態変数の共有、監視用

    void Update()
    {
        // Blackboardに登録されているBoolオブジェクトから(isMoving)で名前検索してそれを更新し続ける
        blackboard.GetVariable<BoolVariable>("isMoving").Value = Input.GetKey(KeyCode.W);

        // 左クリックの監視
        blackboard.GetVariable<BoolVariable>("isLeftClick").Value = Input.GetMouseButton(0);
    }
}
