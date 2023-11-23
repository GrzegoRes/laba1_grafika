// 3 LIGHTS.FS

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

   const vec3 lightCol[3] = { vec3(1.0, 0.0, 0.0),  vec3(0.0, 1.0, 0.0), vec3(0.0, 0.0, 1.0) };
   gl_FragColor.rgb = vec3(0.0, 0.0, 0.0);

   for(int i=0; i<3; i++)
   {
	   const float specularExp2 = 128.0;
	   vec3 NN2 = normalize(N);
	   vec3 NL2 = normalize(L[i]);
	   vec3 NH2 = normalize(NL2 + vec3(0.0, 0.0, 1.0));

	   float intensity2 = max(0.0, dot(normalize(NN2), normalize(NL2)));

	   vec3 diffuse2 = lightCol[i] * intensity2 * gl_Color.rgb;


	   vec3 specular2;
   
	   if(intensity2 <= 0.0) 
	   {
			specular2 = vec3(0.0, 0.0, 0.0);
	   }
	   else
	   {
			float specularIntensity2 = max(0.0, dot(normalize(NN2), normalize(NH2)));
			specular2 = vec3(pow(specularIntensity2, specularExp2));
	   }
	   gl_FragColor.rgb =  gl_FragColor.rgb + (diffuse2 + specular2)  * lightCol[i];
   }

}

