using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    public static StaminaSystem Instance;
    //static: 클래스로부터 객체 생성 없이 호출할 수 있게함.
    //static 넣어서 StaminaSystem 넣어놓은 Instance 가져갈수 있게 함.

    public int staminaMax = 100;
    int staminaMin = 0;
    public int stamina = 100;

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //깨어날때 다른 인스턴스가 이미 있다면 본인을 파괴시킴

    void Start()
    {
        StartCoroutine(RecoverStamina()); //아래쪽의 RecoverStamina 가져와서 사용
    }

    IEnumerator RecoverStamina() //RecoverStamina 만듦
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (stamina < staminaMax)
            {
                stamina += 1;
                Debug.Log("현재 스태미너: " + stamina);
            }
        }
    }

    public bool UseStamina(int amount) //스태미너 사용 확인
    {
        if (stamina < amount)
        {
            return false;
        }

        stamina -= amount;
        Debug.Log("현재 스테미나: " + stamina);
        return true;
    }
}