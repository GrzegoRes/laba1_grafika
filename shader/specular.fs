// SPECULAR.FS

varying vec3 N; // interpolated surface normal vector
varying vec3 L[ 3 ]; // up to three interpolated light vectors

void main( void )
{
   const float specularExp = 128.0;
   vec3 NN = normalize(N);
   vec3 NL = normalize(L[0]);
   vec3 NH = normalize(NL + (0.0, 0.0, 1.0));

   float intensity = max(0.0, dot(normalize(NN), normalize(NL)));

   vec3 diffuse = gl_Color.rgb * intensity;


   vec3 specular;
   
   if(intensity <= 0.0) 
   {
		specular = (0.0, 0.0, 0.0);
   }
   else
   {
		float specularIntensity = max(0.0, dot(normalize(NN), normalize(NH)));
		specular = vec3(pow(specularIntensity, specularExp));
   }
   gl_FragColor = gl_Color; // primary color copying

   gl_FragColor.rgb = diffuse + specular;
   gl_FragColor.a = gl_Color.a;
}
