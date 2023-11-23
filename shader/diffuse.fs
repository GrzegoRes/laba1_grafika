// DIFFUSE.FS

varying vec3 N; // interpolated surface normal vector
varying vec3 L[ 3 ]; // up to three interpolated light vectors

void main( void )
{
	float intensity = max(0.0, dot(normalize(N), normalize(L[0])));
   gl_FragColor = gl_Color; // primary color copying
   gl_FragColor = gl_FragColor * intensity;
}
