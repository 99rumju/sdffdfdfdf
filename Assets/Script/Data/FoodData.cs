using UnityEngine;
  public enum foodCategory
    {
        Rice,
        Soup,
        MainDish
    }
    [CreateAssetMenu(fileName = "Newfood", menuName ="Restaurant/food")]
    public class FoodData : ScriptableObject {
        public string foodName; //음식 이름
        public Sprite foodIcon; //음식 아이콘
        public foodCategory category; //음식 분류

        public int price = 0; //가격
        public float cookingTime = 0f; //요리시간   
        public int Stamina = 0; //소모체력
    }

