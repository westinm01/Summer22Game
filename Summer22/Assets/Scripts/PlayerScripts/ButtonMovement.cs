  using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.EventSystems;
     
     public class ButtonMovement: MonoBehaviour,IUpdateSelectedHandler,IPointerDownHandler,IPointerUpHandler
     {

        public List <PlayerMovement> playerMovements = new List <PlayerMovement>();
         public bool isPressed;
         public float direction = 1f;
     
         // Start is called before the first frame update
         public void OnUpdateSelected(BaseEventData data)
         {
             
              foreach (PlayerMovement p in playerMovements)
              {
                if (p.enabled)
                {
                    p.isButtonPressed = isPressed;
                    p.buttonDirection = direction;
                }
                
              }
         }
         public void OnPointerDown(PointerEventData data)
         {
             isPressed = true;
         }
         public void OnPointerUp(PointerEventData data)
         {
             isPressed = false;
         }
     }