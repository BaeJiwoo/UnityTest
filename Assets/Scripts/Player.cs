using UnityEngine;

enum AttackMethod
{
    Melee,
    Bow // 기존의 'Attack'보다 구분하기 쉽게 'Bow'로 명명했습니다.
}

public class Player : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private AttackMethod currentMethod;

    private IAction currentAttack;

    // 인스펙터에서 값이 변경될 때마다 호출됨
    private void OnValidate()
    {
        UpdateStrategy();
    }

    void Awake()
    {
        UpdateStrategy();
    }

    private void UpdateStrategy()
    {
        // 현재 오브젝트에 붙은 모든 IAction 구현체(MeleeAttack, BowAttack 등)를 가져옵니다.
        IAction[] actions = GetComponents<IAction>();

        foreach (var action in actions)
        {
            // enum 값에 따라 맞는 클래스 타입을 찾아 할당합니다.
            if (currentMethod == AttackMethod.Melee && action is MeleeAttack)
            {
                currentAttack = action;
                return;
            }
            else if (currentMethod == AttackMethod.Bow && action is BowAttack)
            {
                currentAttack = action;
                return;
            }
        }

        // 만약 못 찾았다면 null 처리 (오류 방지)
        currentAttack = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 인터페이스의 메서드 호출 (Attack인지 Perform인지 확인 필요)
            currentAttack?.Attack();
        }
    }
}