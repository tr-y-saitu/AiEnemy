using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

/// <summary>
/// �G��UI
/// </summary>
public class EnemyUI : MonoBehaviour
{
    /// <summary>
    /// �\��������UI���
    /// </summary>
    public class EnemyUIData
    {
        /// <summary>
        /// ���W
        /// </summary>
        public Vector3 Position { get; set; }
        
        /// <summary>
        /// ���O
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �o�H�T���̎��
        /// </summary>
        public string PathfindingType { get; set; }

        /// <summary>
        /// ���݂̐i�s�ڕW
        /// </summary>
        public string CurrentTargetName { get; set; }
    }

    [SerializeField]
    EnemyTest EnemyTest;    // �G�l�~�[�̃X�N���v�g

    [SerializeField]
    TextMeshProUGUI positionTextGUI;    // ���W���UI

    [SerializeField]
    TextMeshProUGUI nameTextGUI;        // ���O���UI

    [SerializeField]
    TextMeshProUGUI pathfindingTypeGUI; // �o�H�T���̎��UI

    [SerializeField]
    TextMeshProUGUI currentTargetNameGUI;   // ���݂̐i�s�ڕWUI

    EnemyUIData enemyUIData = new EnemyUIData();

    /// <summary>
    /// ������
    /// </summary>
    void Start()
    {
        // �G�l�~�[���̎擾
        enemyUIData = EnemyTest.GetEenemyData();
    }

    /// <summary>
    /// �X�V
    /// </summary>
    void Update()
    {
        // �G�l�~�[���̎擾
        enemyUIData = EnemyTest.GetEenemyData();


    }
}
