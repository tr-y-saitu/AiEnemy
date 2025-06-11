using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �f�o�b�O�Ǘ��N���X
/// </summary>
public class DebugManager : SingletonMonoBehaviour<DebugManager>
{
    Material lineMaterial;                      // ���̃}�e���A��
    static readonly float lineWidth = 0.5f;     // ���̑���
    static readonly float heightOffset = 0.5f;  // ���̂��炵��

    Dictionary<string, LineRenderer> lineRenderers = new();

    // ID���Ƃ̐F�Ǘ�
    Dictionary<string, Color> idColors = new();

    // �g�p����F�̃��X�g�i���D�݂Œǉ��\�j
    Color[] availableColors = new Color[]
    {
        Color.cyan,
        Color.red,
        Color.green,
        Color.yellow,
        Color.magenta,
        Color.blue,
        new Color(1f, 0.5f, 0f), // �I�����W�F�Ȃ�
    };

    int nextColorIndex = 0;

    void Start()
    {
        // �}�e���A���̏�����
        lineMaterial = new Material(Shader.Find("Sprites/Default"));
    }

    /// <summary>
    /// �o�H�̕`��
    /// </summary>
    /// <param name="id">�`�悵�����I�u�W�F�N�g��ID</param>
    /// <param name="pathCorners">�o�H���</param>
    public void DrawPath(string id, Vector3[] pathCorners)
    {
        if (string.IsNullOrEmpty(id) || pathCorners == null || pathCorners.Length < 2)
            return;

        // �F�����蓖�Ă�i�܂��Ȃ�ID�ɂ͐V�����F�����蓖�Ă�j
        if (!idColors.TryGetValue(id, out var color))
        {
            color = availableColors[nextColorIndex];
            idColors[id] = color;
            nextColorIndex = (nextColorIndex + 1) % availableColors.Length;
        }

        // �����쐬�܂��͎擾
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
    /// ���̍쐬
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
