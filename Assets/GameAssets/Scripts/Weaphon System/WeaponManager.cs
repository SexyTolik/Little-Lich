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
        if (primaryCooldown < Time.time)
        {
            currentWeapon.PrimaryAttack.PerformAttack(transform, GetLookDirection());
            primaryCooldown = Time.time + currentWeapon.PrimaryAttack.Cooldown;
        }
        
    }

    private void SecondaryAttack(InputAction.CallbackContext context)
    {
        if (secondaryCooldown < Time.time)
        {
            currentWeapon.SecondaryAttack.PerformAttack(transform,GetLookDirection());
            secondaryCooldown = Time.time + currentWeapon.SecondaryAttack.Cooldown;
        }
        
    }

    public Vector2 GetLookDirection()
    {
        return LookAction.ReadValue<Vector2>();
    }
}
