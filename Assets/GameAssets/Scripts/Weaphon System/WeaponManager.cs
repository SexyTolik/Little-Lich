using UnityEngine;
using UnityEngine.InputSystem;
//TODO: добавить инпуты основной и второстепенной атаки. добавить метод получения направления атаки
public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponData currentWeapon;
    private float primaryCooldown = 0f;
    private float secondaryCooldown = 0f;

    private PlayerInputActions actionMap;
    private InputAction attackAction;

    void Awake()
    {
        actionMap = new PlayerInputActions();
        attackAction = actionMap.Player.Fire;
        attackAction.Enable();


    }

    private void PrymaryAttack()
    {

    }

    private void SecondaryAttack()
    {
        
    }
}
