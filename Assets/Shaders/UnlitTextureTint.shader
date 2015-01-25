Shader "Unlit/UnlitAlphaWithFade"
 {
     Properties
     {
         _Color ("Color Tint", Color) = (1,1,1,1)   
         _MainTex ("Base (RGB)", 2D) = "white"
     }
 
     Category
     {
         Lighting Off
         //ZWrite Off
         ZWrite On  // uncomment if you have problems like the sprite disappear in some rotations.
         Cull back
         // Blend SrcAlpha OneMinusSrcAlpha
 
         SubShader
         {
              Pass
              {  SetTexture [_MainTex]
                         {
                     ConstantColor [_Color]
                    Combine Texture * constant
                 }
             }
         }
     }
 }