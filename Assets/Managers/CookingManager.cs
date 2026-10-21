using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingManager : MonoBehaviour
{
    [SerializeField] private List<FoodData> foodDataList; // 모든 음식 데이터가 들어가는 리스트
    //FoodData 빌려오기
    private Dictionary<FoodData, int> foodAmountDictionary = new Dictionary<FoodData, int>(10); // 어떤 음식이 몇개 조리되었는지 DIctionary
    // 딕셔너리는 serializefield 써도 접근 불가.
    private void Awake()
    {
        foreach (FoodData foodData in foodDataList)
        {
            foodAmountDictionary.Add(foodData, 0);
        }
    }
    //FoodData 리스트 가져옴. foreach로 리스트 내 모든 음식들 훑으면서 게임 첫 실행될때 리스트 초기화.

    public void Cooking(FoodData foodData)
    {
        bool hasEnoughStamina = StaminaSystem.Instance.UseStamina(foodData.Stamina);
        //StaminaSystem Instance 가져와서 사용. Instance 내에 있는 UseStamina 가져옴
        if (!hasEnoughStamina) //false
        {
            return;
        }

        StartCoroutine(Cook(foodData));
    }

    public IEnumerator Cook(FoodData foodData)
    {
        // 조리 시간만큼 대기
        yield return new WaitForSeconds(foodData.cookingTime);

        foodAmountDictionary[foodData]++;
    }
}
