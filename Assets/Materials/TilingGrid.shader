Shader "Abi/TilingGrid"
{
    Properties
    {
        _CellNumber("Cells per row", Range(1.0, 20)) = 5.0
        _BorderWidth("Border width", Range(0.005, 0.5)) = 0.2
        _BorderFalloff("Border sharpness", Range(0.005, 0.4)) = 0.2
        _RotationFactor("Rotation (º)", float) = 0
        _GridLineColor("Border color", Color) = (0, 0, 0, 1)
        _CellColor("Cell color", Color) = (0.5, 0.5, 0.5, 1)
    }
    
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            float _CellNumber;
            float _BorderWidth;
            float _BorderFalloff;
            float _RotationFactor;
            float4 _CellColor;
            float4 _GridLineColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                // NOTE(abi): it tiles nicely, but being fixed in world-space it breaks 
                // when rotating.
                // o.uv = mul(unity_ObjectToWorld, v.vertex).xy;
                
                // NOTE(abi): it's supposedly not great for performance to get object 
                // scale this way.
                float3 objectScale = float3(length(unity_ObjectToWorld._m00_m10_m20),
                                            length(unity_ObjectToWorld._m01_m11_m21),
                                            length(unity_ObjectToWorld._m02_m12_m22));

                o.uv = v.uv * objectScale;
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float angleRad = _RotationFactor * 2 * 3.14159265358979323846 / 360;
                float2x2 rotationMatrix = float2x2(cos(angleRad), -sin(angleRad),
                                                   sin(angleRad), cos(angleRad));

                // NOTE(abi): uvs need to be centered at the origin
                float2 rotatedUvs = mul(rotationMatrix, i.uv - 0.5);

                float2 cellUvs = float2(frac(_CellNumber * (rotatedUvs + 0.5)));
                float distToCenter = max(abs(cellUvs.x - 0.5), abs(cellUvs.y - 0.5));
                float distToBorder = abs(0.5 - distToCenter);

                float falloffValue = smoothstep(_BorderWidth, _BorderWidth + _BorderFalloff, distToBorder);
                return float4(lerp(_GridLineColor, _CellColor, falloffValue));        
            }
            ENDCG
        }
    }
}
