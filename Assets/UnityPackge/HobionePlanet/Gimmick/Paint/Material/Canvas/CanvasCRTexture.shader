Shader "HobionePlanet/Unlit/CanvasCRTexture"
{
    Properties
    {
        _DrawTex ("DrawTexture", 2D) = "white" {}
        _CanvasColor("CanvasColor", Color) = (1,1,1,1)
    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            Name "Update"
            CGPROGRAM

            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag

            sampler2D _DrawTex;
            fixed4 _CanvasColor;

            fixed4 frag(v2f_customrendertexture i) : SV_Target
            {
                if (_Time.y < 1) return _CanvasColor;  // ここで初期化する
                float2 uv = i.globalTexcoord.xy;
                fixed4 prev = tex2D(_SelfTexture2D, uv);
                fixed4 draw = tex2D(_DrawTex, uv);
                fixed3 color = lerp(prev.rgb, draw.rgb, draw.a);
                return fixed4(color, _CanvasColor.a);
            }
            ENDCG
        }
    }
}
