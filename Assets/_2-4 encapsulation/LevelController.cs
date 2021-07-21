using UnityEngine;

/// <summary>
/// プレイヤーのパラメーターを管理するコンポーネント
/// </summary>
public class LevelController : MonoBehaviour
{
    /// <summary>レベルアップテーブルを読み込むため</summary>
    [SerializeField] LevelManager m_levelManager = default;
    /// <summary>プレイヤーのレベル</summary>
    //int m_level = 1;
    /// <summary>プレイヤーのパラメーター</summary>
    private PlayerStats m_playerStats = default;

    public PlayerStats Stats
    {
        get
        {
            return m_playerStats;
        }
        
    }
    public int Level
    {
        get
        {
            return m_playerStats.Level;
        }
        set
        {
            if(value>0)
            {
                 m_playerStats = m_levelManager.GetData (value);
            }
            else
            {
                Debug.LogError("不正なレベルです");
            }
            
        }
    }

    //↑と↓は同じ意味
    //public int GetLevel()
    //{
    //    return m_level;
    //}


    //public void SetLevel (int value)
    //{
    //    if(value>0)
    //    {
    //        m_level = 1;
   //     }
    //    else
    //    {
   //         Debug.LogError("不正なレベルです");
   //     }
   // }


   
    public PlayerStats GetStatus()
    {
        return m_playerStats;
    }
    void Start()
    {
        Level = 1;
        //ReloadData();
    }

    /// <summary>
    /// レベルに対してプレイヤーのパラメーターを読み込み直す
    /// </summary>
   // public void ReloadData()
   // {
   //     PlayerStats stats = m_levelManager.GetData(m_level);

   //     if (stats.Level != 0)
   //     {
   //        m_playerStats = m_levelManager.GetData(m_level);
   //     }
   // }

    /// <summary>
    /// レベルアップする
    /// </summary>
    /// <param name="level">レベルアップさせたいレベル数</param>
    public void LevelUp(int level = 1)
    {
        PlayerStats stats = m_levelManager.GetData(Level + level);

        if (stats.Level != 0)
        {
            Level += level;
            m_playerStats = m_levelManager.GetData(this.Level);
        }
    }
}
