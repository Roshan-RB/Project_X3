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
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        CGPROGRAM
        #pragma surface surf Lambert alpha:blend
        // Enable alpha blending
        
        sampler2D _MainTex;
        fixed4 _Color;
        fixed4 _ScatteringColor;
        half _ScatteringAmount;
        half _SubsurfaceRadius;
        half _TranslucencyAmount;
        half _FresnelPower;
        
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
            
            // Subsurface scattering
            float3 scatteringDir = reflect(IN.viewDir, IN.worldNormal);
            half3 scattering = saturate(dot(IN.viewDir, IN.worldNormal)) * _ScatteringAmount * _ScatteringColor * _SubsurfaceRadius;
            
            // Translucency
            half3 translucency = _TranslucencyAmount * c.rgb;
            
            // Fresnel effect (inverted)
            half fresnel = pow(dot(IN.viewDir, IN.worldNormal), _FresnelPower);
            
            // Calculate alpha value for transparency blending
            half alpha = max(max(scattering.r, translucency.r), fresnel);
            
            // Set final color with alpha blending
            o.Alpha = alpha;
            
            // Combine effects
            o.Emission += (scattering + translucency) * fresnel;
        }
        ENDCG
    }
    
    FallBack "Diffuse"
}
