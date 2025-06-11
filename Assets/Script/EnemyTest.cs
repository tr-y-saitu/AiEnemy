using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(LineRenderer))]
public class EnemyTest : MonoBehaviour
{
    static readonly float PathHeightOffset = 0.2f;

    [SerializeField] Transform target;      // �ǂ�������^�[�Q�b�g
    [SerializeField] NavMeshAgent agent;    // �i�r���b�V���G�[�W�F���g

    LineRenderer lineRenderer;              // �o�H�T����`�悷��p�̐�

    void Start()
    {
        // LineRenderer ��ǉ�
        lineRenderer = GetComponent<LineRenderer>();

        // ���̑����ݒ�
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // ���̃}�e���A���ݒ�i�����Ȕ��Ō��₷���j
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
            // �ړ�����^�[�Q�b�g�ɐݒ�
            agent.SetDestination(target.position);

            // �p�X��LineRenderer�ŕ\��
            UpdatePathLine();
        }
    }

    /// <summary>
    /// �i�r���b�V���G�[�W�F���g�̃p�X��LineRenderer�ŉ���
    /// </summary>
    /// MEMO: Debug.DrawLine�ŕ`�悵�Ă��Ȃ����R�̓Q�[�����ɕ`��ł����������̕ύX���ł��Ȃ�����
    void UpdatePathLine()
    {
        // �G�[�W�F���g�i���`�T�����Ă���I�u�W�F�N�g�j�̌o�H�i�p�X�j���擾
        NavMeshPath path = agent.path;

        // �i�r���b�V���̌o�H�R�[�i�[���ɉ����Ĕz����쐬
        Vector3[] positions = new Vector3[path.corners.Length];

        for (int i = 0; i < path.corners.Length; i++)
        {
            // �e�R�[�i�[�ʒu��������ɂ���
            positions[i] = path.corners[i] + Vector3.up * PathHeightOffset;
        }

        // �ʒu�擾���Đ���`��
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}
