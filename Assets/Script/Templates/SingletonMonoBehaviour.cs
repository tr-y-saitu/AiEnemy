using UnityEngine;

/// <summary>
/// シングルトンクラス
/// </summary>
/// <typeparam name="T">実際にシングルトンにするクラス</typeparam>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
{
    // 変数 //

    static T instance;      // インスタンス

    // プロパティ //

    /// <summary>
    /// インスタンスの取得
    /// </summary>
    public static T Instance
    {
        get
        {
            // インスタンスが作成されていない場合
            if (instance == null)
            {
                // 既にインスタンスが作成されているかを調べてある場合は代入
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    // インスタンスがない場合は作成する
                    CreateInstance();
                }
            }

            return instance;
        }
    }

    /// <summary>
    /// シーン遷移時などの処理
    /// </summary>
    void Awake()
    {
        // シーン遷移時などに初期化で再度作成されるのを防ぐ
        RemoveDuplicates();
    }

    // 関数 //

    /// <summary>
    /// インスタンスを作成する
    /// </summary>
    static void CreateInstance()
    {
        instance = (T)FindObjectOfType(typeof(T));

        if (instance == null)
        {
            // インスタンスの作成
            GameObject gameObject = new GameObject();

            // 名前の取得
            gameObject.name = typeof(T).Name;

            // シングルトンとして作成したいクラスのスクリプトを追加
            instance = gameObject.AddComponent<T>();

            // シーンが切り替わった際にオブジェクトが削除されないようにする
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// 重複したインスタンスの削除
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
            // 既にインスタンスがある場合は作成したインスタンスを削除する
            Destroy(gameObject);
        }
    }
}