// Vertex Shader v4
// Simple Diffuse lighting Shader

#version 130

// PARAMETRY WIERZCHO£KA
in vec4 vVertex; // wspó³rzêdne wierzcho³ka
in vec3 vNormal; // wektor normalny powierzchni w wierzcho³ka

uniform vec3 vLightPosition; // pozycja œwiat³a
uniform mat4 mvpMatrix; // macierz Model-View-Projection
uniform mat4 mvMatrix; // macierz Model-View
uniform mat3 normalMatrix; // macierz przekszta³cenia wektora normalnego


// WYJŒCIE PROGRAMU WIERZCHO£KA (varying)
smooth out vec3 vVaryingNormal;
smooth out vec3 vVaryingLightDir;

void main( void ) 
{ 
	vVaryingNormal = normalMatrix * vNormal;


	vec4 vPosition4 = mvMatrix * vVertex; // wspó³rzêdne wierzcho³ka w uk³adzie wspó³rzêdnych oka (kamery)
	
		vVaryingLightDir = normalize( vLightPosition - vPosition4.xyz / vPosition4.w );
	//vec3 ambientColor = Light0Ambient.rgb * MaterialAmbient.rgb;  // sk³adowa ambient

	//float diffuseIntensity = max( 0.0, dot( vEyeNormal, vLightDir ) ); // intensywnoœæ oœwietlenia na podstawie prawa Lamberta
	//vec3 diffuseColor = diffuseIntensity * Light0Diffuse.rgb * MaterialDiffuse.rgb; // kolor œwiat³a rozproszonego na obiekcie

	//vVaryingColor.rgb =  ambientColor + diffuseColor; // kolor wierzcho³ka uwzglêdniaj¹cy oœwietlenie otaczaj¹ce oraz rozproszone
	//vVaryingColor.a = MaterialDiffuse.a; // sk³adowa przezroczystoœci

	gl_Position = mvpMatrix * vVertex; // po³o¿enie wierzcho³ka w przestrzeni obcinania (przemno¿enie przez macierz rzutowania)
	//if(diffuseIntensity > 0.0){
	//	vec3 vReflection = normalize(reflect(-vLightDir, vEyeNormal));
		//float SpecularIntensity = max( 0.0, dot( vEyeNormal, vReflection ) );
		//float fSpecular = pow(SpecularIntensity, 128.0);
		//vVaryingColor.rgb += fSpecular * Light0Specular.rgb * MaterialSpecular.rgb;
	//}
}