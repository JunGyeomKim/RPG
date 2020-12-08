﻿Shader "dc/T_single" {
    Properties{
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Trans. (Alpha)", 2D) = "white" { }
    }
 
    Category
    {
        ZWrite On
        Alphatest Greater 0.5
        SubShader
        {	LOD 200
            Pass
            {
                Lighting Off
                SetTexture [_MainTex]
                {
                    constantColor [_Color]
                    Combine texture * constant, texture * constant
                }
            }
        }
    }
 }