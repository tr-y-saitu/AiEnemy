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
            agent.SetDestination(target.position);
        }
    }
}
