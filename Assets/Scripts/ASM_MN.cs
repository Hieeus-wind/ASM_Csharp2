using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Threading;

public class ASM_MN : Singleton<ASM_MN>
{
    public List<Region> listRegion = new List<Region>();
    public List<Players> listPlayer = new List<Players>();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        createRegion();
        YC1(1, "Hieu", 250, 3);
        YC1(2, "Loi", 50, 0);
        YC1(3, "Tu", 2000, 4);
        YC1(4, "Quyen", 483, 4);
        YC1(1, "Huy", 98, 1);
        YC1(2, "Duy", 50, 4);
        YC1(3, "Phung", 175, 0);
        YC1(4, "Nam", 465, 2);
    }

    public void createRegion()
    {
        listRegion.Add(new Region(0, "VN"));
        listRegion.Add(new Region(1, "VN1"));
        listRegion.Add(new Region(2, "VN2"));
        listRegion.Add(new Region(3, "JS"));
        listRegion.Add(new Region(4, "VS"));
    }

    public string calculate_rank(int score)
    {
        // sinh viên viết tiếp code ở đây
        if (score < 100) return "Hạng Đồng";
        else if (score < 500) return "Hạng Bạc";
        else if (score < 1000) return "Hạng Vàng";
        else return "Hạng Kim cương";
    }

    public void XuLiDuLieu(int id, string name, int score, int regionId)
    {
        Debug.Log("===== TỔNG HỢP DỮ LIỆU =====");
        YC1(id, name, score, regionId);
        YC2();
        YC3();
        YC4();
        YC5();
        YC6();
        // YC7();
    }

    public void YC1(int id, string name, int score, int regionID)
    {
        Region playerRegion = listRegion.FirstOrDefault(r => r.ID == regionID);

        if (playerRegion != null)
        {
            listPlayer.Add(new Players(id, name, score, playerRegion));
            Debug.Log($"YC1 | ID: {id} | Name: {name} | Score: {score} | Region: {playerRegion.Name}");
        }
        else
        {
            Debug.LogError("Không tìm thấy region phù hợp.");
        }

    }
    public void YC2()
    {
        // Xuất danh sách người chơi đã lưu
        Debug.Log("YC2 | Danh sách các người chơi:");
        foreach (var player in listPlayer)
        {
            string rank = calculate_rank(player.Score);
            Debug.Log($"ID: {player.ID} | Name: {player.Name} | Score: {player.Score} | Name region: {player.Region.Name} | Rank: {rank}");
        }
    }
    public void YC3()
    {
        // Xuất thông tin các player có score bé hơn score hiện tại của người chơi
        int score = ScoreKeeper.Instance.GetScore();
        var playersWithLowerScore = listPlayer.Where(p => p.Score < score);

        if (playersWithLowerScore.Any())
        {
            Debug.Log("--- Danh sách Player điểm thấp hơn điểm hiện tại ---");
            foreach (var player in playersWithLowerScore)
            {
                Debug.Log($"YC3 | ID: {player.ID} | Name Player: {player.Name} | Score: {player.Score}");
            }
        }
        else
        {
            Debug.Log("YC3 | Bạn là player có điểm thấp nhất.");
        }
    }
    public void YC4()
    {
        // Tìm Player theo id
        int currentID = ScoreKeeper.Instance.GetID();
        var player = listPlayer.FirstOrDefault(p => p.ID == currentID);
        if (player != null)
        {
            Debug.Log("--- THÔNG TIN PLAYER HIỆN TẠI ---");
            Debug.Log($"YC4 | ID: {player.ID} | Name: {player.Name} | Score: {player.Score} | Region: {player.Region.Name}");
        }
        else
        {
            Debug.Log($"YC4 | Không tìm thấy player nào khớp với ID: {currentID} trong danh sách.");
        }
    }
    public void YC5()
    {
        // In listPlayer theo score giảm dần
        var listScoreDecrease = listPlayer.OrderByDescending(p => p.Score);

        Debug.Log("--- List Player theo score giảm dần ---");
        foreach (var player in listScoreDecrease)
        {
            Debug.Log($"YC5 | ID: {player.ID} | Name: {player.Name} | Score: {player.Score} | Region: {player.Region.Name}");
        }
    }
    public void YC6()
    {
        // Lấy 5 player có score thấp nhất
        var list5PlayerScoreSmallest = listPlayer.OrderBy(p => p.Score).Take(5);

        Debug.Log("--- 5 Player có điểm thấp nhất ---");
        foreach (var player in list5PlayerScoreSmallest)
        {
            Debug.Log($"YC6 | ID: {player.ID} | Name: {player.Name} | Score: {player.Score} | Region: {player.Region.Name}");
        }
    }
    public void YC7()
    {
        // sinh viên viết tiếp code ở đây
    }
    void CalculateAndSaveAverageScoreByRegion()
    {
        // sinh viên viết tiếp code ở đây
    }

}

[System.Serializable]
public class Region
{
    public int ID;
    public string Name;
    public Region(int ID, string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
}

[System.Serializable]
public class Players
{
    // sinh viên viết tiếp code ở đây
    public int ID;
    public string Name;
    public int Score;
    public Region Region;

    public Players(int id, string name, int score, Region region)
    {
        ID = id;
        Name = name;
        Score = score;
        Region = region;
    }
}