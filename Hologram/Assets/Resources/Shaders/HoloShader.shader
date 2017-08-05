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
		Tags
		{
			"Queue" = "Transparent"
			"RenderType" = "Opaque"
		}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			half4 _MainColor;

			struct vertInput {
				float4 pos : POSITION;
			};

			struct vertOutput {
				float4 pos : SV_POSITION;
			};

			vertOutput vert (vertInput input)
			{
				vertOutput o;
				o.pos = UnityObjectToClipPos(input.pos);
				return o;
			}

			half4 frag (vertOutput output) : COLOR
			{
				return _MainColor;
			}

			ENDCG
		}
	}
}
