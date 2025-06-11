using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �f�o�b�O�Ǘ��N���X
/// </summary>
public class DebugManager : SingletonMonoBehaviour<DebugManager>
{
    Material lineMaterial;
    [SerializeField]
    float lineWidth = default;     // ���̑���
    [SerializeField]
    float heightOffset = default;  // ���̂��炵��

    Dictionary<string, LineRenderer> lineRenderers = new();

    void Start()
    {
        // �}�e���A���̏�����
        lineMaterial = new Material(Shader.Find("Sprites/Default"));
    }

    public void DrawPath(string id, Vector3[] pathCorners)
    {
        if (string.IsNullOrEmpty(id) || pathCorners == null || pathCorners.Length < 2)
            return;

        if (!lineRenderers.TryGetValue(id, out var lr))
        {
            lr = CreateLineRenderer(id + "_PathLine");
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

    private LineRenderer CreateLineRenderer(string name)
    {
        var obj = new GameObject(name);
        obj.transform.SetParent(transform);

        var lr = obj.AddComponent<LineRenderer>();
        lr.material = lineMaterial ?? new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.cyan;
        lr.endColor = Color.cyan;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.useWorldSpace = true;

        return lr;
    }
}
