// SPECULAR.VS 

uniform vec3 lightPos[ 3 ]; // up to three light positions
varying vec3 N; // interpolated surface normal vector
varying vec3 L[ 3 ]; // up to three interpolated light vectors
vec4 V;

void main( void )
{
   // vertex transformation according to the current model view matrix and projection
   gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;


   N = gl_NormalMatrix * gl_Normal;
	V = gl_ModelViewMatrix * gl_Vertex;
	L[0] = lightPos[0] - V.xyz;

	// primary color copying
   gl_FrontColor = gl_Color;
}
