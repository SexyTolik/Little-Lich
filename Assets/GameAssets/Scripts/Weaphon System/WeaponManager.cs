using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponData currentWeapon;
    private float primaryCooldown = 0f;
    private float secondaryCooldown = 0f;

    private PlayerInputActions actionMap;
    private InputAction primaryAttackAction;
    private InputAction secondaryAttackAction;
    private InputAction LookAction;

    void Awake()
    {
        actionMap = new PlayerInputActions();
        primaryAttackAction = actionMap.Player.PrimaryAttak;
        secondaryAttackAction = actionMap.Player.SecondaryAttak;
        LookAction = actionMap.Player.Look;
        LookAction.Enable();
        primaryAttackAction.Enable();
        secondaryAttackAction.Enable();
        primaryAttackAction.performed += PrymaryAttack;
        secondaryAttackAction.performed += SecondaryAttack;

    }

    private void PrymaryAttack(InputAction.CallbackContext context)
    {
        currentWeapon.PrimaryAttack.PerformAttack(transform,GetLookDirection());
    }

    private void SecondaryAttack(InputAction.CallbackContext context)
    {
        currentWeapon.SecondaryAttack.PerformAttack(transform,GetLookDirection());
    }

    public Vector2 GetLookDirection()
    {
        return LookAction.ReadValue<Vector2>();
    }
}
