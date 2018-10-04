#if !defined(FLOW_INCLUDED)
#define FLOW_INCLUDED

float2 DirectionalFlowUV(float2 uv, float3 flowVectorAndSpeed, float tiling, float time, out float2x2 rotation)
{
	float2 dir = normalize(flowVectorAndSpeed.xy);
	rotation = float2x2(dir.y, dir.x, -dir.x, dir.y);
	uv = mul(float2x2(dir.y, dir.x, -dir.x, dir.y), uv);
	uv.y -= time * flowVectorAndSpeed.z;
	return uv * tiling;
}

#endif