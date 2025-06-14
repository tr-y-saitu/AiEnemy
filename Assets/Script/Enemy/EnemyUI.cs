using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

/// <summary>
/// 敵のUI
/// </summary>
public class EnemyUI : MonoBehaviour
{
    /// <summary>
    /// 表示したいUI情報
    /// </summary>
    public class EnemyUIData
    {
        /// <summary>
        /// 座標
        /// </summary>
        public Vector3 Position { get; set; }
        
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 経路探索の種類
        /// </summary>
        public string PathfindingType { get; set; }

        /// <summary>
        /// 現在の進行目標
        /// </summary>
        public string CurrentTargetName { get; set; }
    }

    [SerializeField]
    EnemyTest EnemyTest;    // エネミーのスクリプト

    [SerializeField]
    TextMeshProUGUI positionTextGUI;    // 座標情報UI

    [SerializeField]
    TextMeshProUGUI nameTextGUI;        // 名前情報UI

    [SerializeField]
    TextMeshProUGUI pathfindingTypeGUI; // 経路探索の種類UI

    [SerializeField]
    TextMeshProUGUI currentTargetNameGUI;   // 現在の進行目標UI

    EnemyUIData enemyUIData = new EnemyUIData();

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        // エネミー情報の取得
        enemyUIData = EnemyTest.GetEenemyData();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        // エネミー情報の取得
        enemyUIData = EnemyTest.GetEenemyData();


    }
}
