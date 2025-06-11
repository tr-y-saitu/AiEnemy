using UnityEngine;
using UnityEngine.AI;

public class EnemyTest : MonoBehaviour
{
    [SerializeField]
    Transform target;  // 追いかける目的地

    [SerializeField]
    NavMeshAgent agent; // 自身のAIコンポーネント

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        if (target != null)
        {
            // ナビメッシュを使用した経路探索移動
            agent.SetDestination(target.position);

            // 経路探索の経路をデバッグ表示
            DrawTagetPath();
        }
    }

    void DrawTagetPath()
    {
        // 
        if (agent.path.corners.Length < 2)
        {
            return;
        }

        // 
        for (int i = 0; i < agent.path.corners.Length -1; i++)
        {
            Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1], UnityEngine.Color.cyan);
        }
    }
}
