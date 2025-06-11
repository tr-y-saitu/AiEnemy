using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(LineRenderer))]
public class EnemyTest : MonoBehaviour
{
    static readonly float PathHeightOffset = 0.2f;

    [SerializeField] Transform target;      // 追いかけるターゲット
    [SerializeField] NavMeshAgent agent;    // ナビメッシュエージェント

    LineRenderer lineRenderer;              // 経路探索を描画する用の線

    void Start()
    {
        // LineRenderer を追加
        lineRenderer = GetComponent<LineRenderer>();

        // 線の太さ設定
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // 線のマテリアル設定（透明な白で見やすく）
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.cyan;
        lineRenderer.endColor = Color.cyan;
        lineRenderer.positionCount = 0;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        if (target != null && agent != null)
        {
            // 移動先をターゲットに設定
            agent.SetDestination(target.position);

            // パスをLineRendererで表示
            UpdatePathLine();
        }
    }

    /// <summary>
    /// ナビメッシュエージェントのパスをLineRendererで可視化
    /// </summary>
    /// MEMO: Debug.DrawLineで描画していない理由はゲーム中に描画できず太さ等の変更ができないため
    void UpdatePathLine()
    {
        // エージェント（線形探索しているオブジェクト）の経路（パス）を取得
        NavMeshPath path = agent.path;

        // ナビメッシュの経路コーナー数に応じて配列を作成
        Vector3[] positions = new Vector3[path.corners.Length];

        for (int i = 0; i < path.corners.Length; i++)
        {
            // 各コーナー位置を少し上にする
            positions[i] = path.corners[i] + Vector3.up * PathHeightOffset;
        }

        // 位置取得して線を描画
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}
