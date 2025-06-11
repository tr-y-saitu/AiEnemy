using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// �o�H�T���̃^�[�Q�b�g
/// </summary>
public class PathfindingTarget : MonoBehaviour
{
    [SerializeField] 
    Transform[] patrolPoints;   // ����|�C���g
    
    NavMeshAgent agent;

    int currentIndex = 0;

    /// <summary>
    /// ������
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("����|�C���g���ݒ肳��Ă��܂���B");
            enabled = false;
            return;
        }

        agent.SetDestination(patrolPoints[currentIndex].position);
    }

    /// <summary>
    /// �X�V
    /// </summary>
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            // ���̃|�C���g��
            currentIndex = (currentIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentIndex].position);
        }
    }
}
