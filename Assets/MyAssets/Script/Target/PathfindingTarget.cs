using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// 経路探索のターゲット
/// </summary>
public class PathfindingTarget : MonoBehaviour
{
    [SerializeField] 
    Transform[] patrolPoints;   // 巡回ポイント
    
    NavMeshAgent agent;

    int currentIndex = 0;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("巡回ポイントが設定されていません。");
            enabled = false;
            return;
        }

        agent.SetDestination(patrolPoints[currentIndex].position);
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            // 次のポイントへ
            currentIndex = (currentIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentIndex].position);
        }

        Vector3[] positions = new Vector3[agent.path.corners.Length];
        for (int i = 0; i < agent.path.corners.Length; i++)
        {
            positions[i] = agent.path.corners[i] + Vector3.up * 0.2f;
        }

        // Enemyの識別用IDとしてgameObject名を渡す（任意の文字列でOK）
        DebugManager.Instance.DrawPath(gameObject.name, positions);
    }
}
