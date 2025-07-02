using MBT;
using UnityEngine;

/// <summary>
/// QiitaAI用でで登録されている変数の状態を監視、更新する
/// </summary>
/// NOTE: Behaviour Tree から参照できるように、Blackboardに変数を登録しておく必要がある。
public class QiitaInputToBlackboard : MonoBehaviour
{
    [SerializeField]
    Blackboard blackboard;  // 状態変数の共有、監視用
    void Update()
    {
        // 左クリックの監視
        blackboard.GetVariable<BoolVariable>("isLeftClick").Value = Input.GetMouseButton(0);
    }
}
