Shader "Custom/DSAlikeEffect2"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" {}
        _Color ("Base Color", Color) = (1,1,1,1)
        _ScatteringColor ("Scattering Color", Color) = (1,1,1,1)
        _ScatteringAmount ("Scattering Amount", Range(0,1)) = 0.5
        _SubsurfaceRadius ("Subsurface Radius", Range(0,1)) = 0.5
        _TranslucencyAmount ("Translucency Amount", Range(0,1)) = 0.5
        _FresnelPower ("Fresnel Power", Range(0,10)) = 5
        _AlphaCutoff ("Alpha Cutoff", Range(0,1)) = 0.5
    }
    
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200
        
        Blend SrcAlpha OneMinusSrcAlpha // Enable alpha blending
        
        CGPROGRAM
        #pragma surface surf Lambert alpha
        
        sampler2D _MainTex;
        fixed4 _Color;
        fixed4 _ScatteringColor;
        half _ScatteringAmount;
        half _SubsurfaceRadius;
        half _TranslucencyAmount;
        half _FresnelPower;
        half _AlphaCutoff;
        
        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
            float3 worldNormal;
            float3 viewDir;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a; // Set the alpha value
            
            // Subsurface scattering
            float3 scatteringDir = reflect(IN.viewDir, IN.worldNormal);
            half3 scattering = saturate(dot(IN.viewDir, IN.worldNormal)) * _ScatteringAmount * _ScatteringColor * _SubsurfaceRadius;
            
            // Translucency
            half3 translucency = _TranslucencyAmount * c.rgb;
            
            // Fresnel effect
            half fresnel = pow(1 - dot(IN.viewDir, IN.worldNormal), _FresnelPower);
            
            // Combine effects
            o.Emission += (scattering + translucency) * fresnel;
        }
        
        // GI function
        void LightingCombined_GI (SurfaceOutput s, UnityGI gi)
        {
            #ifdef UNITY_PASS_FORWARDBASE
                half3 indirectDiffuse = gi.indirect.diffuse;
                s.Albedo += indirectDiffuse;
            #endif
        }
        
        ENDCG
    }
    
    FallBack "Diffuse"
}
