using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// By Madhusudan
namespace ShaderEffects
{
    // This class has methods to help control VFX effects like fade and create boundry
    public static class CommonVfxEffect 
    {

        //  Get material of the object
        public static Material GetMaterial<T>(GameObject gameObj) where T : Component
        {

            Material mat = null;
            if(gameObj.TryGetComponent<T>(out T component))
            {   
                if(component is Image)
                {
                    Image img = component as Image;
                    mat = img.material;
                } 
                else if(component is TrailRenderer)
                {
                    TrailRenderer trailRenderer = component as TrailRenderer;
                    mat = trailRenderer.material;
                } 
                else if(component is ParticleSystem)
                {
                    ParticleSystem particleSystem = component as ParticleSystem;
                    ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)particleSystem.GetComponent<Renderer>();
                    mat = particleSystemRenderer.material;

                }
                
            }

            return mat;
  
        }


        // Set custom shader material parameter
        public static void SetCustomMatPara(Material mat, string matPara, float val)
        {
            int matParaInt =  Shader.PropertyToID(matPara); 
		    mat.SetFloat(matParaInt, val);
        }

        // Lerp custom shader material parameter
        public static void LerpCustomMatPara(Material mat, string matPara, float fromVal, float toVal, float lerpSpeed)
        {

            SetCustomMatPara(mat,matPara,fromVal);
            DOVirtual.Float(fromVal, toVal, lerpSpeed, v => {SetCustomMatPara(mat,matPara,v); }).SetEase(Ease.Linear);

        }


        // Lerp alpha of image component of UI elements for fade effect
        public static void LerpImageAlpha(Image image, float fromVal, float toVal, float lerpSpeed) 
        {
            Color imgColor = image.color;
            imgColor.a = fromVal;
            image.color = imgColor;

            DOVirtual.Float(fromVal, toVal, lerpSpeed, v => {imgColor.a = v;  image.color = imgColor; } ).SetEase(Ease.Linear);

        }

        // change the startwidth of the trail renderer 
        public static void ChangeTrailWidth(GameObject gameObj, float fromVal, float toVal, float speed)
        {
            if(gameObj.TryGetComponent<TrailRenderer>(out TrailRenderer trailRenderer))
            {
                DOVirtual.Float(fromVal, toVal, speed, v => {trailRenderer.startWidth = v; }).SetEase(Ease.Linear);
            }
        }



        // // Change Rect Transfrom of a UI element (for boundry image element) 
        // public static void ChangeRectTran(GameObject gameObj, float x, float y)
        // {
        //     if(gameObj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
        //     {
        //         rectTransform.sizeDelta  += new Vector2(x,y);
        //     }
            
        // }


    }
}

