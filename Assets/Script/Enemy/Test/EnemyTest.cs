using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// エネミーの経路探索テスト
/// </summary>
public class EnemyTest : MonoBehaviour
{
    static readonly float PathHeightOffset = 0.2f;

    [SerializeField] Transform target;      // 追いかけるターゲット
    [SerializeField] NavMeshAgent agent;    // ナビメッシュエージェント

    void Update()
    {
        if (target != null && agent != null)
        {
            // 移動先をターゲットに設定
            agent.SetDestination(target.position);

            // ナビメッシュのパスコーナーを取得してDebugManagerで描画
            Vector3[] positions = new Vector3[agent.path.corners.Length];
            for (int i = 0; i < agent.path.corners.Length; i++)
            {
                positions[i] = agent.path.corners[i] + Vector3.up * PathHeightOffset;
            }

            // Enemyの識別用IDとしてgameObject名を渡す（任意の文字列でOK）
            DebugManager.Instance.DrawPath(gameObject.name, positions);
        }
    }

    /// <summary>
    /// エネミーの表示してほしい情報を取得
    /// </summary>
    /// <returns></returns>
    public EnemyUI.EnemyUIData GetEenemyData()
    {
        EnemyUI.EnemyUIData data = new EnemyUI.EnemyUIData();

        data.Position = transform.position;
        data.Name = gameObject.name;
        data.PathfindingType = "NavMesh";
        data.CurrentTargetName = target.name;

        return data;
    }
}
