Shader "JST4FN/Triplanar"
{
    Properties
    {
        //_Color ("Color", Color) = (1,1,1,1)
        _MainTex ("XZ_TEX(Floor)", 2D) = "white" {}
        _MainTexTiling("Floor_Tiling", Vector) = (1,1,0,0)
        _SecondaryTex ("Floor_ColorMap", 2D) = "white" {}
        _SecondaryTexTiling("SecondaryTex_Tiling", Vector) = (1,1,0,0)
        _SecondaryTexAdditionTiling("SecondaryTex_Additional_Tiling", Vector) = (1,1,0,0)
        
        _xyTex("XY_TEX", 2D) = "white" {}
        _xyTexTiling("xyTex_Tiling", Vector) = (1,1,0,0)
        _zyTex("ZY_TEX", 2D) = "white" {}
        _zyTexTiling("zyTex_Tiling", Vector) = (1,1,0,0)
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _SecondaryTex;
        sampler2D _xyTex;
        sampler2D _zyTex;
        float4 _MainTexTiling;
        float4 _xyTexTiling;
        float4 _zyTexTiling;
        float4 _SecondaryTexTiling;
        float4 _SecondaryTexAdditionTiling;
        
        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
            float3 worldNormal;
        };

        half _Glossiness;
        half _Metallic;
        //fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 floor = tex2D (_MainTex, IN.worldPos.xz * _MainTexTiling.xy + _MainTexTiling.zw);
            fixed4 floorcol1 = tex2D(_SecondaryTex, IN.worldPos.xz * _SecondaryTexTiling.xy + _SecondaryTexTiling.zw);
            fixed4 floorcol2 = tex2D(_SecondaryTex, IN.worldPos.xz * _SecondaryTexAdditionTiling.xy + _SecondaryTexAdditionTiling.zw);
            fixed4 coloring = floorcol1 * floorcol2;
            fixed4 floorfin = floor * coloring;

            float4 upTex = max(0, IN.worldNormal.y * floorfin) + max(0, -IN.worldNormal.y * floorfin);

            fixed4 wallxy = tex2D(_zyTex, IN.worldPos.xy * _xyTexTiling.xy + _xyTexTiling.zw);
            fixed4 wallzy = tex2D(_zyTex, IN.worldPos.zy * _zyTexTiling.xy + _zyTexTiling.zw);
            float4 xyTex = max(0, IN.worldNormal.x * wallxy) + max(0, -IN.worldNormal.x * wallxy) * coloring;
            float4 zyTex = max(0, IN.worldNormal.z * wallzy) + max(0, -IN.worldNormal.z * wallzy) * coloring;

            fixed4 result = upTex + xyTex + zyTex;
            o.Albedo = result.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = result.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
