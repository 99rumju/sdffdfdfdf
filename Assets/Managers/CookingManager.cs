using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingManager : MonoBehaviour
{


    public void Cooking(FoodData foodData) //스태미너 확인 및 사용
    {
        bool hasEnoughStamina = StaminaSystem.Instance.UseStamina(foodData.Stamina);
        //StaminaSystem Instance 가져와서 사용. Instance 내에 있는 UseStamina 가져옴
        if (!hasEnoughStamina) //false
        {
            return;
        }

        StartCoroutine(Cook(foodData)); //Cook 사용함.
    }

    public IEnumerator Cook(FoodData foodData) // 대기 후 음식 추가, Cook 만듦. 클래스랑 구조는 비슷한듯
    {
        Debug.Log(foodData.foodName+" 조리중..."); //(요리이름) 조리중...
        // 조리 시간만큼 대기
        yield return new WaitForSeconds(foodData.cookingTime);

        addFood()
        Debug.Log(foodData.foodName+" 요리 완료. 현재 "+foodData.foodName+" 갯수: " + foodAmountDictionary[foodData]); //(요리이름) 요리완료. 현재 (요리이름) 갯수: (요리 갯수)
    }
}
