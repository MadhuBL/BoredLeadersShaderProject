// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CardFan : MonoBehaviour
// {
//     public static AlignParameters[] GetAlignHandParameters(int alignAmount,float xOffset,float yOffset,float zRotOffset,int handCardsCount){
//         // AlignParameters[] alignParameters = new AlignParameters[alignAmount];
//         if(alignAmount == 1){ //Ignore this part. Only one card so no need to do anything.
//             alignParameters[0].pos = Vector2.zero;
//             alignParameters[0].rot = new Vector3(0,0,0);
//             alignParameters[0].scale = 1;
//             return alignParameters;
//         }
//         else if(alignAmount < 1){
//             return alignParameters; //There are no cards
//         }
//         int modulo = alignAmount % 2;
//         bool isEven = modulo == 0;
     
//         float xStartPos = -1;
//         float yStartPos = -1;
//         float zStartRot = -1;
     
//         int midIndex = - 1;
     
//         if(!isEven){
//             midIndex = (alignAmount / 2) + modulo; //Get the middle card
//             xStartPos = xOffset / 2 * (alignAmount / 2 + modulo); // Account for the middle number
//             yStartPos = yOffset * (alignAmount/ 2 + modulo);
//             zStartRot = zRotOffset * (alignAmount / 2 + modulo);
//         }
//         else{
//             midIndex = handCardsCount / 2;
//             xStartPos = xOffset / 2 * alignAmount / 2;
//             yStartPos = yOffset * alignAmount / 2;
//             zStartRot =  zRotOffset * alignAmount / 2;
//         }
//         Vector2 prevPos = new Vector2(-xStartPos,-yStartPos);
//         float prevZRot= zStartRot;
//         Vector2 targetPos = prevPos;
//         float targetZRot = prevZRot;
     
//         float targetXOffset = xOffset;
//         float targetYOffset = yOffset;
 
//         alignParameters[0].pos = targetPos;
//         alignParameters[0].rot = new Vector3(0,0,targetZRot);
//         alignParameters[0].scale = 1;
 
//         for(int i=1; i < alignAmount; i++){
//             targetPos = prevPos;
//             if(isEven && i > alignAmount / 2||!isEven && i >midIndex){ // If we are past the middle index, it is time to reverse the Y to descending.
//                 targetYOffset = -Mathf.Abs(yOffset);
//                 //zRotOffset= Mathf.Abs(yOffset);
//             }
//             else if(!isEven && i == midIndex - 1){ //An odd number so we want to make rotation and X/Y to 0.
//                 targetPos = new Vector2(prevPos.x + targetXOffset,prevPos.y + targetYOffset);
//                 targetZRot = 0;
//                 alignParameters[i].pos = targetPos;
//                 alignParameters[i].rot = new Vector3(0,0,targetZRot);
//                 alignParameters[i].scale = 1;
//                 prevPos = targetPos;
//                 prevZRot = targetZRot;
//                 continue; //MiddleCard of uneven number.
//             }
         
//             targetPos = new Vector2(prevPos.x + xOffset,prevPos.y + targetYOffset);
//             targetZRot = prevZRot - zRotOffset;
//             //Debug.Log(cardPos);
         
//             if(i == midIndex ||i  == midIndex - 1){ //We want both even cards in the middle to be on the same Y axis and have opposite rotations on the same value.
//                 if(isEven && i  == midIndex){
//                     targetZRot = - prevZRot;
//                 }
//                 targetPos.y = -targetYOffset;
//             }
 
//             alignParameters[i].pos = targetPos;
//             alignParameters[i].rot = new Vector3(0,0,targetZRot);
//             alignParameters[i].scale = 1;
//             prevPos = targetPos;
//             prevZRot = targetZRot;
 
//         }
//         return alignParameters;
//     }
// }
