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
            // �i�r���b�V�����g�p�����o�H�T���ړ�
            agent.SetDestination(target.position);

            // �o�H�T���̌o�H���f�o�b�O�\��
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
