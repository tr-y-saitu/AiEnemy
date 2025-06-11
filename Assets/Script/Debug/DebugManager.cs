using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デバッグ管理クラス
/// </summary>
public class DebugManager : SingletonMonoBehaviour<DebugManager>
{
    Material lineMaterial;                      // 線のマテリアル
    static readonly float lineWidth = 0.5f;     // 線の太さ
    static readonly float heightOffset = 0.5f;  // 線のずらし量

    Dictionary<string, LineRenderer> lineRenderers = new();

    // IDごとの色管理
    Dictionary<string, Color> idColors = new();

    // 使用する色のリスト（お好みで追加可能）
    Color[] availableColors = new Color[]
    {
        Color.cyan,
        Color.red,
        Color.green,
        Color.yellow,
        Color.magenta,
        Color.blue,
        new Color(1f, 0.5f, 0f), // オレンジ色など
    };

    int nextColorIndex = 0;

    void Start()
    {
        // マテリアルの初期化
        lineMaterial = new Material(Shader.Find("Sprites/Default"));
    }

    /// <summary>
    /// 経路の描画
    /// </summary>
    /// <param name="id">描画したいオブジェクトのID</param>
    /// <param name="pathCorners">経路情報</param>
    public void DrawPath(string id, Vector3[] pathCorners)
    {
        if (string.IsNullOrEmpty(id) || pathCorners == null || pathCorners.Length < 2)
            return;

        // 色を割り当てる（まだないIDには新しく色を割り当てる）
        if (!idColors.TryGetValue(id, out var color))
        {
            color = availableColors[nextColorIndex];
            idColors[id] = color;
            nextColorIndex = (nextColorIndex + 1) % availableColors.Length;
        }

        // 線を作成または取得
        if (!lineRenderers.TryGetValue(id, out var lr))
        {
            lr = CreateLineRenderer(id + "_PathLine", color);
            lineRenderers[id] = lr;
        }

        Vector3[] positions = new Vector3[pathCorners.Length];
        for (int i = 0; i < pathCorners.Length; i++)
        {
            positions[i] = pathCorners[i] + Vector3.up * heightOffset;
        }

        lr.positionCount = positions.Length;
        lr.SetPositions(positions);
    }

    /// <summary>
    /// 線の作成
    /// </summary>
    /// <param name="name"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    private LineRenderer CreateLineRenderer(string name, Color color)
    {
        var obj = new GameObject(name);
        obj.transform.SetParent(transform);

        var lr = obj.AddComponent<LineRenderer>();
        lr.material = lineMaterial ?? new Material(Shader.Find("Sprites/Default"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.useWorldSpace = true;

        return lr;
    }
}
