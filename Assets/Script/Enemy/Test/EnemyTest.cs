using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// �G�l�~�[�̌o�H�T���e�X�g
/// </summary>
public class EnemyTest : MonoBehaviour
{
    static readonly float PathHeightOffset = 0.2f;

    [SerializeField] Transform target;      // �ǂ�������^�[�Q�b�g
    [SerializeField] NavMeshAgent agent;    // �i�r���b�V���G�[�W�F���g

    void Update()
    {
        if (target != null && agent != null)
        {
            // �ړ�����^�[�Q�b�g�ɐݒ�
            agent.SetDestination(target.position);

            // �i�r���b�V���̃p�X�R�[�i�[���擾����DebugManager�ŕ`��
            Vector3[] positions = new Vector3[agent.path.corners.Length];
            for (int i = 0; i < agent.path.corners.Length; i++)
            {
                positions[i] = agent.path.corners[i] + Vector3.up * PathHeightOffset;
            }

            // Enemy�̎��ʗpID�Ƃ���gameObject����n���i�C�ӂ̕������OK�j
            DebugManager.Instance.DrawPath(gameObject.name, positions);
        }
    }

    /// <summary>
    /// �G�l�~�[�̕\�����Ăق��������擾
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
