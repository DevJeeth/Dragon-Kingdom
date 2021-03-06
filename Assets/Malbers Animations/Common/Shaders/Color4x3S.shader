// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Malbers/Color4x3 One Side"
{
	Properties
	{
		_Color1("Color 1", Color) = (1,0.1544118,0.1544118,0.397)
		_Color2("Color 2", Color) = (1,0.1544118,0.8017241,0.334)
		_Color3("Color 3", Color) = (0.2535501,0.1544118,1,0.228)
		_Color4("Color 4", Color) = (0.1544118,0.5451319,1,0.472)
		_Color5("Color 5", Color) = (0.9533468,1,0.1544118,0.353)
		_Color6("Color 6", Color) = (0.8483773,1,0.1544118,0.341)
		_Color7("Color 7", Color) = (0.1544118,0.6151115,1,0.316)
		_Color8("Color 8", Color) = (0.4849697,0.5008695,0.5073529,0.484)
		_Color9("Color 9", Color) = (0.9099331,0.9264706,0.6267301,0.353)
		_Color10("Color 10", Color) = (0.1544118,0.1602434,1,0.341)
		_Color11("Color 11", Color) = (1,0.1544118,0.381846,0.316)
		_Color12("Color 12", Color) = (0.02270761,0.1632713,0.2205882,0.484)
		_Smoothness("Smoothness", Range( 0 , 1)) = 1
		_Metallic("Metallic", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float4 _Color1;
		uniform float4 _Color2;
		uniform float4 _Color3;
		uniform float4 _Color4;
		uniform float4 _Color5;
		uniform float4 _Color6;
		uniform float4 _Color7;
		uniform float4 _Color8;
		uniform float4 _Color9;
		uniform float4 _Color10;
		uniform float4 _Color11;
		uniform float4 _Color12;
		uniform float _Metallic;
		uniform float _Smoothness;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float temp_output_3_0_g184 = 1.0;
			float temp_output_7_0_g184 = 4.0;
			float temp_output_9_0_g184 = 3.0;
			float temp_output_8_0_g184 = 3.0;
			float temp_output_3_0_g186 = 2.0;
			float temp_output_7_0_g186 = 4.0;
			float temp_output_9_0_g186 = 3.0;
			float temp_output_8_0_g186 = 3.0;
			float temp_output_3_0_g180 = 3.0;
			float temp_output_7_0_g180 = 4.0;
			float temp_output_9_0_g180 = 3.0;
			float temp_output_8_0_g180 = 3.0;
			float temp_output_3_0_g187 = 4.0;
			float temp_output_7_0_g187 = 4.0;
			float temp_output_9_0_g187 = 3.0;
			float temp_output_8_0_g187 = 3.0;
			float temp_output_3_0_g189 = 1.0;
			float temp_output_7_0_g189 = 4.0;
			float temp_output_9_0_g189 = 2.0;
			float temp_output_8_0_g189 = 3.0;
			float temp_output_3_0_g182 = 2.0;
			float temp_output_7_0_g182 = 4.0;
			float temp_output_9_0_g182 = 2.0;
			float temp_output_8_0_g182 = 3.0;
			float temp_output_3_0_g181 = 3.0;
			float temp_output_7_0_g181 = 4.0;
			float temp_output_9_0_g181 = 2.0;
			float temp_output_8_0_g181 = 3.0;
			float temp_output_3_0_g185 = 4.0;
			float temp_output_7_0_g185 = 4.0;
			float temp_output_9_0_g185 = 2.0;
			float temp_output_8_0_g185 = 3.0;
			float temp_output_3_0_g190 = 1.0;
			float temp_output_7_0_g190 = 4.0;
			float temp_output_9_0_g190 = 1.0;
			float temp_output_8_0_g190 = 3.0;
			float temp_output_3_0_g191 = 2.0;
			float temp_output_7_0_g191 = 4.0;
			float temp_output_9_0_g191 = 1.0;
			float temp_output_8_0_g191 = 3.0;
			float temp_output_3_0_g183 = 3.0;
			float temp_output_7_0_g183 = 4.0;
			float temp_output_9_0_g183 = 1.0;
			float temp_output_8_0_g183 = 3.0;
			float temp_output_3_0_g188 = 4.0;
			float temp_output_7_0_g188 = 4.0;
			float temp_output_9_0_g188 = 1.0;
			float temp_output_8_0_g188 = 3.0;
			float4 temp_output_155_0 = ( ( ( _Color1 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g184 - 1.0 ) / temp_output_7_0_g184 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g184 / temp_output_7_0_g184 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g184 - 1.0 ) / temp_output_8_0_g184 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g184 / temp_output_8_0_g184 ) ) * 1.0 ) ) ) ) + ( _Color2 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g186 - 1.0 ) / temp_output_7_0_g186 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g186 / temp_output_7_0_g186 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g186 - 1.0 ) / temp_output_8_0_g186 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g186 / temp_output_8_0_g186 ) ) * 1.0 ) ) ) ) + ( _Color3 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g180 - 1.0 ) / temp_output_7_0_g180 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g180 / temp_output_7_0_g180 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g180 - 1.0 ) / temp_output_8_0_g180 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g180 / temp_output_8_0_g180 ) ) * 1.0 ) ) ) ) + ( _Color4 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g187 - 1.0 ) / temp_output_7_0_g187 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g187 / temp_output_7_0_g187 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g187 - 1.0 ) / temp_output_8_0_g187 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g187 / temp_output_8_0_g187 ) ) * 1.0 ) ) ) ) ) + ( ( _Color5 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g189 - 1.0 ) / temp_output_7_0_g189 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g189 / temp_output_7_0_g189 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g189 - 1.0 ) / temp_output_8_0_g189 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g189 / temp_output_8_0_g189 ) ) * 1.0 ) ) ) ) + ( _Color6 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g182 - 1.0 ) / temp_output_7_0_g182 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g182 / temp_output_7_0_g182 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g182 - 1.0 ) / temp_output_8_0_g182 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g182 / temp_output_8_0_g182 ) ) * 1.0 ) ) ) ) + ( _Color7 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g181 - 1.0 ) / temp_output_7_0_g181 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g181 / temp_output_7_0_g181 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g181 - 1.0 ) / temp_output_8_0_g181 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g181 / temp_output_8_0_g181 ) ) * 1.0 ) ) ) ) + ( _Color8 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g185 - 1.0 ) / temp_output_7_0_g185 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g185 / temp_output_7_0_g185 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g185 - 1.0 ) / temp_output_8_0_g185 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g185 / temp_output_8_0_g185 ) ) * 1.0 ) ) ) ) ) + ( ( _Color9 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g190 - 1.0 ) / temp_output_7_0_g190 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g190 / temp_output_7_0_g190 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g190 - 1.0 ) / temp_output_8_0_g190 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g190 / temp_output_8_0_g190 ) ) * 1.0 ) ) ) ) + ( _Color10 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g191 - 1.0 ) / temp_output_7_0_g191 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g191 / temp_output_7_0_g191 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g191 - 1.0 ) / temp_output_8_0_g191 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g191 / temp_output_8_0_g191 ) ) * 1.0 ) ) ) ) + ( _Color11 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g183 - 1.0 ) / temp_output_7_0_g183 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g183 / temp_output_7_0_g183 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g183 - 1.0 ) / temp_output_8_0_g183 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g183 / temp_output_8_0_g183 ) ) * 1.0 ) ) ) ) + ( _Color12 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g188 - 1.0 ) / temp_output_7_0_g188 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g188 / temp_output_7_0_g188 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g188 - 1.0 ) / temp_output_8_0_g188 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g188 / temp_output_8_0_g188 ) ) * 1.0 ) ) ) ) ) );
			o.Albedo = temp_output_155_0.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = ( (temp_output_155_0).a * _Smoothness );
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16200
81;249;1309;794;1001.251;675.1448;3.140695;True;True
Node;AmplifyShaderEditor.ColorNode;23;-199.8005,-326.2955;Float;False;Property;_Color1;Color 1;0;0;Create;True;0;0;False;0;1,0.1544118,0.1544118,0.397;0.1102941,0.1102941,0.1102941,0.116;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;182;-190.5642,2431.409;Float;False;Property;_Color12;Color 12;11;0;Create;True;0;0;False;0;0.02270761,0.1632713,0.2205882,0.484;0.5858564,0.7534364,0.9485294,0.834;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;180;-189.1549,2188.253;Float;False;Property;_Color11;Color 11;10;0;Create;True;0;0;False;0;1,0.1544118,0.381846,0.316;0.1176471,0.1098616,0.1098616,0.472;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;181;-202.6826,1954.387;Float;False;Property;_Color10;Color 10;9;0;Create;True;0;0;False;0;0.1544118,0.1602434,1,0.341;0.5514706,0.3635456,0.1621972,0.209;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;158;-183.7895,1424.406;Float;False;Property;_Color8;Color 8;7;0;Create;True;0;0;False;0;0.4849697,0.5008695,0.5073529,0.484;0,0,0,1;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;157;-182.3802,1181.25;Float;False;Property;_Color7;Color 7;6;0;Create;True;0;0;False;0;0.1544118,0.6151115,1,0.316;0.2205882,0.2189662,0.2189662,0.1176471;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;183;-194.742,1695.03;Float;False;Property;_Color9;Color 9;8;0;Create;True;0;0;False;0;0.9099331,0.9264706,0.6267301,0.353;0.6544118,0.5129174,0.3272059,0;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;159;-187.9672,688.0273;Float;False;Property;_Color5;Color 5;4;0;Create;True;0;0;False;0;0.9533468,1,0.1544118,0.353;0.6544118,0.5677984,0.4378785,0.1176471;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;154;-195.6228,411.2479;Float;False;Property;_Color4;Color 4;3;0;Create;True;0;0;False;0;0.1544118,0.5451319,1,0.472;0.4264706,0.4264706,0.4264706,0.1176471;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;152;-194.2135,166.9271;Float;False;Property;_Color3;Color 3;2;0;Create;True;0;0;False;0;0.2535501,0.1544118,1,0.228;0.4264706,0.4264706,0.4264706,0.1176471;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;150;-207.7412,-66.93771;Float;False;Property;_Color2;Color 2;1;0;Create;True;0;0;False;0;1,0.1544118,0.8017241,0.334;0.4264706,0.4264706,0.4264706,0.1176471;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;156;-195.9079,947.3851;Float;False;Property;_Color6;Color 6;5;0;Create;True;0;0;False;0;0.8483773,1,0.1544118,0.341;0.1911765,0.1883651,0.1883651,0.1176471;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;153;122.0185,410.1585;Float;True;ColorShartSlot;-1;;187;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;186;186.9198,1938.3;Float;True;ColorShartSlot;-1;;191;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;184;194.8606,1678.942;Float;True;ColorShartSlot;-1;;190;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;163;127.7504,688.1025;Float;True;ColorShartSlot;-1;;189;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;190;200.9619,2415.321;Float;True;ColorShartSlot;-1;;188;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;149;107.9764,-66.86263;Float;True;ColorShartSlot;-1;;186;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;145;115.9171,-326.2204;Float;True;ColorShartSlot;-1;;184;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;188;200.4478,2172.165;Float;True;ColorShartSlot;-1;;183;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;160;119.8096,947.4603;Float;True;ColorShartSlot;-1;;182;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;161;133.3375,1181.325;Float;True;ColorShartSlot;-1;;181;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;151;121.5042,167.0022;Float;True;ColorShartSlot;-1;;180;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;162;133.8517,1424.481;Float;True;ColorShartSlot;-1;;185;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;3;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;146;1124.026,-170.6852;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;164;1130.732,57.40811;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;193;1126.266,334.7972;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;155;1378.894,-29.6249;Float;True;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;166;1496.486,1037.67;Float;False;Property;_Smoothness;Smoothness;12;0;Create;True;0;0;False;0;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;194;1523.734,407.4271;Float;False;False;False;False;True;1;0;COLOR;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;165;1691.967,238.6589;Float;False;Property;_Metallic;Metallic;13;0;Create;True;0;0;False;0;0;0.4;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;178;1803.628,700.3177;Float;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2076.697,169.3291;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Malbers/Color4x3 One Side;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;153;38;154;0
WireConnection;186;38;181;0
WireConnection;184;38;183;0
WireConnection;163;38;159;0
WireConnection;190;38;182;0
WireConnection;149;38;150;0
WireConnection;145;38;23;0
WireConnection;188;38;180;0
WireConnection;160;38;156;0
WireConnection;161;38;157;0
WireConnection;151;38;152;0
WireConnection;162;38;158;0
WireConnection;146;0;145;0
WireConnection;146;1;149;0
WireConnection;146;2;151;0
WireConnection;146;3;153;0
WireConnection;164;0;163;0
WireConnection;164;1;160;0
WireConnection;164;2;161;0
WireConnection;164;3;162;0
WireConnection;193;0;184;0
WireConnection;193;1;186;0
WireConnection;193;2;188;0
WireConnection;193;3;190;0
WireConnection;155;0;146;0
WireConnection;155;1;164;0
WireConnection;155;2;193;0
WireConnection;194;0;155;0
WireConnection;178;0;194;0
WireConnection;178;1;166;0
WireConnection;0;0;155;0
WireConnection;0;3;165;0
WireConnection;0;4;178;0
ASEEND*/
//CHKSM=0A1815ABD541FDA4248610520A8132B6CDCEA6D1