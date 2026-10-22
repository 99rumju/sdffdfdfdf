using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
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
    //FoodDatalist에 등록된 모든 음식 확인, Dictionary내 해당 음식들 0으로 설정

    public void addFood(FoodData Food)
    {
        foodAmountDictionary[Food]++;
    }


}
