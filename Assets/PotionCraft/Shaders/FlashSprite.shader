Shader "PotionCraft/FlashSprite"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _FlashColor ("Flash Color", Color) = (1,1,1,1)
        _FlashSpeed ("Flash Speed", Float) = 2.0
        _FlashIntensity ("Flash Intensity", Range(0, 1)) = 0.5
        _IsHovered ("Is Hovered", Float) = 0.0
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
            "Queue"="Geometry"
        }
        Lighting Off
        ZWrite On
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 uv       : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 uv       : TEXCOORD0;
            };

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _FlashColor;
            float _FlashSpeed;
            float _FlashIntensity;
            float _IsHovered;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 mainColor = tex2D(_MainTex, i.uv) * i.color;
                float flash = _IsHovered * (sin(_Time.y * _FlashSpeed) * 0.5 + 0.5) * _FlashIntensity;
                fixed4 flashColor = _FlashColor * flash;
                fixed4 finalColor = mainColor + flashColor;
                return finalColor;
            }
            ENDCG
        }
    }
}
