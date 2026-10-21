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
    //깨어날때 다른 인스턴스가 이미 있다면 생성되지 않음

    void Start()
    {
        StartCoroutine(RecoverStamina());
    }

    IEnumerator RecoverStamina()
    {
        while (stamina < staminaMax)
        {
            yield return new WaitForSeconds(1f);
            stamina += 1;
            Debug.Log("현재 스태미너: " + stamina);
        }
    }

    public bool UseStamina(int amount)
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