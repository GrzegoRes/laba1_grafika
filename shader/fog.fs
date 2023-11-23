// FOG.FS

varying vec3 N; // interpolated surface normal vector
varying vec3 L[ 3 ]; // up to three interpolated light vectors
varying float distance;

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

   const vec4 fogColor = vec4(1.0, 0.0, 0.0, 1.0);
   float e = 2.71828;
   float density = 0.9;

   gl_FragColor = gl_Color; // primary color copying

   gl_FragColor.rgb = diffuse + specular;
   gl_FragColor.a = gl_Color.a;

   float fogExp = density * distance/200.0;
   float fogFactor = clamp(pow(e, -fogExp * fogExp), 0.0, 1.0);

   gl_FragColor = mix(fogColor, gl_FragColor, fogFactor);
}

