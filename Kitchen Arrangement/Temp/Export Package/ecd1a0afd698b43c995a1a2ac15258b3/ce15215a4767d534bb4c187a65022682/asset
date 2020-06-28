// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Kandooz/HandShader"

{
	Properties
	{
		[HDR]_AlbedoTint("Albedo Tint", Color) = (1,1,1,0)
		[HDR][Gamma]_AlbedoMap("Albedo Map", 2D) = "white" {}
		[HDR][Gamma]_WrinkleAlbedoMap("Wrinkle Albedo Map", 2D) = "white" {}
		_NormalStrength("Normal Strength", Range( 0 , 2)) = 0
		[Normal]_NormalMap("Normal Map", 2D) = "bump" {}
		[Normal]_WrinkleNormalMap("Wrinkle Normal Map", 2D) = "bump" {}
		_CombinedMap("Combined Map", 2D) = "white" {}
		_WrinkleCombinedMap("Wrinkle Combined Map", 2D) = "white" {}
		_AO("AO", Float) = 1
		_Glossiness("Glossiness", Range( 0 , 1)) = 0
		_Metalness("Metalness", Range( 0 , 1)) = 0
		[Header(Translucency)]
		_Translucency("Strength", Range( 0 , 50)) = 1
		_TransNormalDistortion("Normal Distortion", Range( 0 , 1)) = 0.1
		_TransScattering("Scaterring Falloff", Range( 1 , 50)) = 2
		_TransDirect("Direct", Range( 0 , 1)) = 1
		_TransAmbient("Ambient", Range( 0 , 1)) = 0.2
		_TransShadow("Shadow", Range( 0 , 1)) = 0.9
		[HDR]_TranslucencyColor("Translucency Color", Color) = (0,0,0,0)
		_WrinkleMaskMap("Wrinkle Mask Map", 2D) = "black" {}
		_HandSurface("HandSurface", Range( 0 , 1)) = 0
		_FingerThree("Finger Three", Range( 0 , 1)) = 0
		_FingerThumb("Finger Thumb", Range( 0 , 1)) = 0
		_FingerIndex("Finger Index", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityPBSLighting.cginc"
		#pragma target 3.0
		#pragma surface surf StandardCustom keepalpha addshadow fullforwardshadows exclude_path:deferred 
		struct Input
		{
			float2 uv_texcoord;
		};

		struct SurfaceOutputStandardCustom
		{
			half3 Albedo;
			half3 Normal;
			half3 Emission;
			half Metallic;
			half Smoothness;
			half Occlusion;
			half Alpha;
			half3 Translucency;
		};

		uniform sampler2D _NormalMap;
		uniform float4 _NormalMap_ST;
		uniform sampler2D _WrinkleNormalMap;
		uniform float4 _WrinkleNormalMap_ST;
		uniform sampler2D _WrinkleMaskMap;
		uniform float4 _WrinkleMaskMap_ST;
		uniform float _FingerThumb;
		uniform float _FingerIndex;
		uniform float _FingerThree;
		uniform float _HandSurface;
		uniform float _NormalStrength;
		uniform sampler2D _AlbedoMap;
		uniform float4 _AlbedoMap_ST;
		uniform sampler2D _WrinkleAlbedoMap;
		uniform float4 _WrinkleAlbedoMap_ST;
		uniform float4 _AlbedoTint;
		uniform sampler2D _CombinedMap;
		uniform float4 _CombinedMap_ST;
		uniform sampler2D _WrinkleCombinedMap;
		uniform float4 _WrinkleCombinedMap_ST;
		uniform float _Metalness;
		uniform float _Glossiness;
		uniform float _AO;
		uniform half _Translucency;
		uniform half _TransNormalDistortion;
		uniform half _TransScattering;
		uniform half _TransDirect;
		uniform half _TransAmbient;
		uniform half _TransShadow;
		uniform float4 _TranslucencyColor;

		inline half4 LightingStandardCustom(SurfaceOutputStandardCustom s, half3 viewDir, UnityGI gi )
		{
			#if !DIRECTIONAL
			float3 lightAtten = gi.light.color;
			#else
			float3 lightAtten = lerp( _LightColor0.rgb, gi.light.color, _TransShadow );
			#endif
			half3 lightDir = gi.light.dir + s.Normal * _TransNormalDistortion;
			half transVdotL = pow( saturate( dot( viewDir, -lightDir ) ), _TransScattering );
			half3 translucency = lightAtten * (transVdotL * _TransDirect + gi.indirect.diffuse * _TransAmbient) * s.Translucency;
			half4 c = half4( s.Albedo * translucency * _Translucency, 0 );

			SurfaceOutputStandard r;
			r.Albedo = s.Albedo;
			r.Normal = s.Normal;
			r.Emission = s.Emission;
			r.Metallic = s.Metallic;
			r.Smoothness = s.Smoothness;
			r.Occlusion = s.Occlusion;
			r.Alpha = s.Alpha;
			return LightingStandard (r, viewDir, gi) + c;
		}

		inline void LightingStandardCustom_GI(SurfaceOutputStandardCustom s, UnityGIInput data, inout UnityGI gi )
		{
			#if defined(UNITY_PASS_DEFERRED) && UNITY_ENABLE_REFLECTION_BUFFERS
				gi = UnityGlobalIllumination(data, s.Occlusion, s.Normal);
			#else
				UNITY_GLOSSY_ENV_FROM_SURFACE( g, s, data );
				gi = UnityGlobalIllumination( data, s.Occlusion, s.Normal, g );
			#endif
		}

		void surf( Input i , inout SurfaceOutputStandardCustom o )
		{
			float2 uv_NormalMap = i.uv_texcoord * _NormalMap_ST.xy + _NormalMap_ST.zw;
			float2 uv_WrinkleNormalMap = i.uv_texcoord * _WrinkleNormalMap_ST.xy + _WrinkleNormalMap_ST.zw;
			float2 uv_WrinkleMaskMap = i.uv_texcoord * _WrinkleMaskMap_ST.xy + _WrinkleMaskMap_ST.zw;
			float4 tex2DNode65 = tex2D( _WrinkleMaskMap, uv_WrinkleMaskMap );
			float temp_output_61_0 = ( ( tex2DNode65.r * _FingerThumb ) + ( tex2DNode65.g * _FingerIndex ) + ( tex2DNode65.b * _FingerThree ) + ( tex2DNode65.a * _HandSurface ) );
			float3 lerpResult52 = lerp( UnpackNormal( tex2D( _NormalMap, uv_NormalMap ) ) , UnpackNormal( tex2D( _WrinkleNormalMap, uv_WrinkleNormalMap ) ) , temp_output_61_0);
			float3 lerpResult64 = lerp( float3(0,0,1) , lerpResult52 , _NormalStrength);
			o.Normal = lerpResult64;
			float2 uv_AlbedoMap = i.uv_texcoord * _AlbedoMap_ST.xy + _AlbedoMap_ST.zw;
			float2 uv_WrinkleAlbedoMap = i.uv_texcoord * _WrinkleAlbedoMap_ST.xy + _WrinkleAlbedoMap_ST.zw;
			float4 lerpResult62 = lerp( tex2D( _AlbedoMap, uv_AlbedoMap ) , tex2D( _WrinkleAlbedoMap, uv_WrinkleAlbedoMap ) , temp_output_61_0);
			o.Albedo = ( lerpResult62 * _AlbedoTint ).rgb;
			float2 uv_CombinedMap = i.uv_texcoord * _CombinedMap_ST.xy + _CombinedMap_ST.zw;
			float2 uv_WrinkleCombinedMap = i.uv_texcoord * _WrinkleCombinedMap_ST.xy + _WrinkleCombinedMap_ST.zw;
			float4 lerpResult82 = lerp( tex2D( _CombinedMap, uv_CombinedMap ) , tex2D( _WrinkleCombinedMap, uv_WrinkleCombinedMap ) , temp_output_61_0);
			float4 break89 = lerpResult82;
			o.Metallic = ( break89.r * _Metalness );
			o.Smoothness = ( break89.g * _Glossiness );
			o.Occlusion = ( break89.b * _AO );
			o.Translucency = ( _TranslucencyColor * break89.a ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "Kandooz.HandShaderEditor"
	//	CustomEditor "ASEMaterialInspector"

}
/*ASEBEGIN
Version=15800
1921;23;1678;986;931.802;-1141.46;1;False;False
Node;AmplifyShaderEditor.CommentaryNode;51;-1881.629,956.1556;Float;False;766.4768;648.1967;Mask map;10;61;59;57;58;55;53;54;65;90;91;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;54;-1841.994,1205.325;Float;False;Property;_FingerThumb;Finger Thumb;21;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;91;-1842.936,1444.193;Float;False;Property;_HandSurface;HandSurface;19;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;65;-1849.018,1010.961;Float;True;Property;_WrinkleMaskMap;Wrinkle Mask Map;18;0;Create;True;0;0;False;0;None;220e4445d01b3b44498783a33da3e3ce;True;0;False;black;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;55;-1843.994,1363.325;Float;False;Property;_FingerThree;Finger Three;20;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;53;-1843.994,1281.325;Float;False;Property;_FingerIndex;Finger Index;22;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;57;-1450.994,1117.325;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;20;-1432.016,1656.653;Float;False;1021.095;495.8348;Combined Maps;12;11;6;16;17;18;15;14;5;89;82;13;75;;0.3270047,1,0,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;59;-1453.994,1310.325;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;58;-1451.994,1211.325;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;90;-1452.936,1415.193;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;31;-965.1263,921.4152;Float;False;551.187;667.3091;Wrinklemaps;6;52;64;24;29;30;22;;1,0,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;19;-1144.824,338.3245;Float;False;740.6456;542.8185;Albedo;5;10;9;63;62;8;;0,0.4434402,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;75;-1399.915,1912.527;Float;True;Property;_WrinkleCombinedMap;Wrinkle Combined Map;7;0;Create;True;0;0;False;0;None;7a2afdcc08f2f3243b992398d42ba58c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;13;-1405.543,1714.021;Float;True;Property;_CombinedMap;Combined Map;6;0;Create;True;0;0;False;0;None;c87879222c10afd4db54fa2e233a9e2e;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;61;-1275.266,1142.163;Float;False;4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;22;-919.4886,964.7832;Float;True;Property;_NormalMap;Normal Map;4;1;[Normal];Create;True;0;0;False;0;None;0befdc88fe4998240988a1c9ca785d24;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;30;-922.3532,1153.834;Float;True;Property;_WrinkleNormalMap;Wrinkle Normal Map;5;1;[Normal];Create;True;0;0;False;0;None;0efd5ec7b1b63724f91b17b35fb07deb;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;63;-1097.915,584.3355;Float;True;Property;_WrinkleAlbedoMap;Wrinkle Albedo Map;2;2;[HDR];[Gamma];Create;True;0;0;False;0;None;60764817ce2ccd54f96b06f2fc30ed15;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;8;-1098.824,389.3245;Float;True;Property;_AlbedoMap;Albedo Map;1;2;[HDR];[Gamma];Create;True;0;0;False;0;None;60764817ce2ccd54f96b06f2fc30ed15;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;82;-1085.843,1767.095;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-905.2751,1494.364;Float;False;Property;_NormalStrength;Normal Strength;3;0;Create;True;0;0;False;0;0;2;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;29;-800.1449,1349.681;Float;False;Constant;_Vector0;Vector 0;10;0;Create;True;0;0;False;0;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ColorNode;5;-811.6425,1971.613;Float;False;Property;_TranslucencyColor;Translucency Color;17;1;[HDR];Create;True;0;0;False;0;0,0,0,0;0.9811321,0.6331519,0.3008188,1;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;14;-855.1794,1791.828;Float;False;Property;_Glossiness;Glossiness;9;0;Create;True;0;0;False;0;0;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;62;-703.9161,466.3355;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-849.9825,1710.079;Float;False;Property;_Metalness;Metalness;10;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;-732.426,1886.522;Float;False;Property;_AO;AO;8;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;52;-584.814,1112.248;Float;False;3;0;FLOAT3;0,0,1;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;10;-776.4784,697.0425;Float;False;Property;_AlbedoTint;Albedo Tint;0;1;[HDR];Create;True;0;0;False;0;1,1,1,0;1,1,1,1;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BreakToComponentsNode;89;-1089.116,1934.526;Float;False;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-550.4789,592.0425;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;64;-587.7839,1250.097;Float;False;3;0;FLOAT3;0,0,1;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-554.9572,2014.75;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-555.6189,1797.087;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-550.3655,1696.281;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-556.8655,1903.781;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;35;90.10133,1170.182;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Hand Shader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;ForwardOnly;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;11;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;57;0;65;1
WireConnection;57;1;54;0
WireConnection;59;0;65;3
WireConnection;59;1;55;0
WireConnection;58;0;65;2
WireConnection;58;1;53;0
WireConnection;90;0;65;4
WireConnection;90;1;91;0
WireConnection;61;0;57;0
WireConnection;61;1;58;0
WireConnection;61;2;59;0
WireConnection;61;3;90;0
WireConnection;82;0;13;0
WireConnection;82;1;75;0
WireConnection;82;2;61;0
WireConnection;62;0;8;0
WireConnection;62;1;63;0
WireConnection;62;2;61;0
WireConnection;52;0;22;0
WireConnection;52;1;30;0
WireConnection;52;2;61;0
WireConnection;89;0;82;0
WireConnection;9;0;62;0
WireConnection;9;1;10;0
WireConnection;64;0;29;0
WireConnection;64;1;52;0
WireConnection;64;2;24;0
WireConnection;6;0;5;0
WireConnection;6;1;89;3
WireConnection;11;0;89;1
WireConnection;11;1;14;0
WireConnection;17;0;89;0
WireConnection;17;1;18;0
WireConnection;16;0;89;2
WireConnection;16;1;15;0
WireConnection;35;0;9;0
WireConnection;35;1;64;0
WireConnection;35;3;17;0
WireConnection;35;4;11;0
WireConnection;35;5;16;0
WireConnection;35;7;6;0
ASEEND*/
//CHKSM=26A183C7ADD95208D25ECA9B0138AB59FAC5DE62