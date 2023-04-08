using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private PlayerControls playerControls;
    private int[] weaponNumber;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Player.BasicAttack1.performed -= BasicAttack1;
        playerControls.Player.BasicAttack2.performed -= BasicAttack2;
        playerControls.Player.Ability1.performed -= Ability1;
        playerControls.Player.Ability2.performed -= Ability2;
        playerControls.Player.Ability3.performed -= Ability3;
        playerControls.Player.Ability4.performed -= Ability4;
        playerControls.Player.Ability5.performed -= Ability5;
        
    }

    private void Start()
    {
        playerControls.Player.BasicAttack1.performed += BasicAttack1;
        playerControls.Player.BasicAttack2.performed += BasicAttack2;
        playerControls.Player.Ability1.performed += Ability1;
        playerControls.Player.Ability2.performed += Ability2;
        playerControls.Player.Ability3.performed += Ability3;
        playerControls.Player.Ability4.performed += Ability4;
        playerControls.Player.Ability5.performed += Ability5;
    }

    private void BasicAttack1(InputAction.CallbackContext context)
    {

    }

    private void BasicAttack2(InputAction.CallbackContext context)
    {

    }
    
    private void Ability1(InputAction.CallbackContext context)
    {
        //zuerst playerinventory machen
        //weaponNumber = 
    }
    private void Ability2(InputAction.CallbackContext context)
    {

    }
    private void Ability3(InputAction.CallbackContext context)
    {

    }
    private void Ability4(InputAction.CallbackContext context)
    {

    }
    private void Ability5(InputAction.CallbackContext context)
    {

    }
}
