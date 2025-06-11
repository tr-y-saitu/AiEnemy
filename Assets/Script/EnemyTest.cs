using UnityEngine;
using UnityEngine.AI;

public class EnemyTest : MonoBehaviour
{
    [SerializeField]
    Transform target;  // �ǂ�������ړI�n

    [SerializeField]
    NavMeshAgent agent; // ���g��AI�R���|�[�l���g

    /// <summary>
    /// �X�V
    /// </summary>
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
