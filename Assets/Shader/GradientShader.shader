Shader "Unlit/GradientShader"
{
      Properties
    {
        _Color1 ("Color Top", Color) = (0,0,1,1)
        _Color2 ("Color Bottom", Color) = (1,1,0,1)
    }
    SubShader
    {
        Tags { "Queue"="Overlay" }
        Pass
        {
            ZWrite Off
            ZTest Always
            Cull Off
            Lighting Off
            Fog { Mode Off }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            uniform float4 _Color1;
            uniform float4 _Color2;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                return lerp(_Color1, _Color2, i.uv.y);
            }
            ENDCG
        }
    }
}