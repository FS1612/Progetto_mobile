//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class InputManager : MonoBehaviour
//{
   
//    movimentoauto MovimentoAuto;
//    InputPlayer InputSystem;
//     void Awake()
//    {
//        InputSystem = new InputPlayer();
//        MovimentoAuto = GetComponent<movimentoauto>();
//        InizializeInputSystem();
//    }
//    private void OnEnable()
//    {
//        InputSystem.player.Enable();
//    }
//    private void OnDisable()
//    {
//        InputSystem.player.Disable();
//    }
//    void InizializeInputSystem()
//    {//* per ottenere le componenti sull'asse verticale
//    //    InputSystem.player.bottone.performed += ctx => MovimentoAuto.PremiAcceleratore(ctx.ReadValue<float>());
//    }
//}
