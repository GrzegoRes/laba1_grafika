// Fragment Shader v4
// Simple Diffuse lighting Shader

#version 130

// PARAMETRY OBIEKTU
uniform vec4 Light0Ambient; // sk�adowa ambient �wiat�a 0
uniform vec4 Light0Diffuse; // sk�adowa diffuse �wiat�a 0
uniform vec4 Light0Specular; // sk�adowa specular �wiat�a 0
uniform vec4 MaterialAmbient; // sk�adowa ambient materia�u
uniform vec4 MaterialDiffuse; // sk�adowa diffuse materia�u
uniform vec4 MaterialSpecular; // sk�adowa specular materia�u

// INTERPOLOWANE WEJ�CIE z VS (varying)
smooth in vec3 vVaryingNormal;
smooth in vec3 vVaryingLightDir;

// WYJ�CIE
out vec4 vFragColor; // kolor fragmentu

void main( void )
{ 
   vec3 NN = normalize(vVaryingNormal);
   vec3 NL = normalize(vVaryingLightDir);
   vec3 ambientColor = Light0Ambient.rgb * MaterialAmbient.rgb;
   float diffuseIntensity = max(0.0, dot(NN, NL));
   vec3 diffuseColor = diffuseIntensity * Light0Diffuse.rgb * MaterialDiffuse.rgb;
   vFragColor.rgb = ambientColor + diffuseColor; // przepisanie interpolowanego koloru
   vFragColor.a = MaterialDiffuse.a;
   if(diffuseIntensity > 0.0){
   		vec3 vReflection = normalize(reflect(-NL, NN));
   		float SpecularIntensity = max( 0.0, dot( NN, vReflection ) );
   		float fSpecular = pow(SpecularIntensity, 128.0);
   		vFragColor.rgb += fSpecular * Light0Specular.rgb * MaterialSpecular.rgb;
   	}
}