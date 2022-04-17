using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodConfig : MonoBehaviour
{
   public bool main;
   public bool ignoreMain;
   public float minHeight;
   public float maxHeight;
   public bool changeScale;
   public AnimationCurve ScaleCurve;
   private Vector3 defaultScale;
   private float mainCollisionHeight;
   public bool myCity;
   
   private void Awake()
   {
      Init();
   }
   public void Init()
   {
      defaultScale = transform.localScale;
      CameraController.Instance.onHeightEvent += onHeightEvent;
     // onHeightEvent(CameraController.Instance.transform.position.y);
   }
   private void onHeightEvent(float height)
   {
      if (height>minHeight&&height<=maxHeight)
      {
         if (main==false &&height>mainCollisionHeight&&mainCollisionHeight>0)
         {
            gameObject.SetActive(false);
         }
         else
         {
            gameObject.SetActive(true);
            if (changeScale)
            {
               transform.localScale=ScaleCurve.Evaluate(height) * defaultScale;
            }
         }
        
      }
      else
      {
         if (height>maxHeight)
         {
            if (myCity)
            {
               gameObject.SetActive(true);
            }
            else
            {
               gameObject.SetActive(false);
            }
         }
         else
         {
            gameObject.SetActive(false);
         }
        
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (ignoreMain)
      {
         return;
      }
      var lod = other.GetComponent<LodConfig>();
      if (lod!=null)
      { 
         if (main)
         {
            lod.gameObject.SetActive(false);
            lod.setMainCollisionHeight(Camera.main.transform.position.y);
         }
         else
         {
            if (lod.main)
            {
               gameObject.SetActive(false);
            }
            else
            {  
               var i = other.transform.GetSiblingIndex();
               var j = transform.GetSiblingIndex();
               if (i>j)
               {
                  lod.gameObject.SetActive(false);
               }
               else
               {
                  gameObject.SetActive(false);
               }
               
            }
          
            
         }
        
      }

   }
   
   private void setMainCollisionHeight(float height)
   {
      mainCollisionHeight = height;

   }
}
