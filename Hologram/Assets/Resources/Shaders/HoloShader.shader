Shader "Custom/HoloShader"
{
	Properties
	{
		_MainColor("Main Color",Color) = (1,1,1,1)
		_OutlineColor("Outline Color",Color) = (1,1,1,1)
		_VerticalLines("Vertical Lines",Range(1,100)) = 50
		_HorizontalFlashes("Horizontal Flashes",Range(1,10)) = 2
	}

	SubShader
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200

		Pass
		{
			ZWrite On
			ColorMask 0
		}

		Pass
		{
			Lighting On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f {
				float4 pos : SV_POSITION;
				fixed3 color : COLOR0;
			};

			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = v.normal * 0.5 + 0.5;
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				return fixed4 (i.color,1);
			}

			ENDCG
		}
	}
}
