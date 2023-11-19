using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// 도전과제 조건은 Gampe play쪽에서 확인
// 특정 이벤트 달성시 manager 호출 ->  Unlocked 확인후 값 변경
public class AchievementsManager : MonoBehaviour
{

    public List<AchievementObject> achievements;
    public GameObject achievementUIPrefab;
    public Transform collectionContainer;

    // Start is called before the first frame update
    void Start()
    {
        InitializeAchievements();
    }

    void InitializeAchievements()
    {
        // 초기상태 결정
        // Logic 저장된 데이터 로드해서 List 채우기

        foreach (var achievement in achievements)
        {
            // UI 인스턴스를 생성하고 해당 도전과제 데이터로 설정
            var achievementUIInstance = Instantiate(achievementUIPrefab, collectionContainer);
            // Achievement 데이터로 UI 요소를 설정
            achievementUIInstance.transform.Find("AchievementName").GetComponent<TextMeshProUGUI>().text = achievement.achievementName;
            // achievementUIInstance.transform.Find("AchievementIcon").GetComponent<Text>().text = achievement.achievementDescription;
        }
    }
 
    public void CheckAchievements()
    {
        foreach (var achievement in achievements)
        {
            if (!achievement.isUnlocked)
            {
                // LOGIC Condition check
            }
        }
    }

    // 도전과제의 잠금을 해제
    public void UnlockAchievement(AchievementObject achievement)
    {
        achievement.UnlockAchievement();
        // UI 업데이트 로직이나, 저장 로직을 추가
        // UpdateAchievementUI(achievement);
        // 사용자에게 알림
    }

    // 도전과제 UI를 업데이트하는 메소드
    private void UpdateAchievementUI(AchievementObject achievement)
    {
        // UI 컴포넌트에 도전과제 정보를 업데이트합니다.
        // achievementUIElement.UpdateUI(achievement);
    }
}
