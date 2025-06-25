using UnityEngine;

/// <summary>
/// �V���O���g���N���X
/// </summary>
/// <typeparam name="T">���ۂɃV���O���g���ɂ���N���X</typeparam>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
{
    // �ϐ� //

    static T instance;      // �C���X�^���X

    // �v���p�e�B //

    /// <summary>
    /// �C���X�^���X�̎擾
    /// </summary>
    public static T Instance
    {
        get
        {
            // �C���X�^���X���쐬����Ă��Ȃ��ꍇ
            if (instance == null)
            {
                // ���ɃC���X�^���X���쐬����Ă��邩�𒲂ׂĂ���ꍇ�͑��
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    // �C���X�^���X���Ȃ��ꍇ�͍쐬����
                    CreateInstance();
                }
            }

            return instance;
        }
    }

    /// <summary>
    /// �V�[���J�ڎ��Ȃǂ̏���
    /// </summary>
    void Awake()
    {
        // �V�[���J�ڎ��Ȃǂɏ������ōēx�쐬�����̂�h��
        RemoveDuplicates();
    }

    // �֐� //

    /// <summary>
    /// �C���X�^���X���쐬����
    /// </summary>
    static void CreateInstance()
    {
        instance = (T)FindObjectOfType(typeof(T));

        if (instance == null)
        {
            // �C���X�^���X�̍쐬
            GameObject gameObject = new GameObject();

            // ���O�̎擾
            gameObject.name = typeof(T).Name;

            // �V���O���g���Ƃ��č쐬�������N���X�̃X�N���v�g��ǉ�
            instance = gameObject.AddComponent<T>();

            // �V�[�����؂�ւ�����ۂɃI�u�W�F�N�g���폜����Ȃ��悤�ɂ���
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// �d�������C���X�^���X�̍폜
    /// </summary>
    void RemoveDuplicates()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ���ɃC���X�^���X������ꍇ�͍쐬�����C���X�^���X���폜����
            Destroy(gameObject);
        }
    }
}