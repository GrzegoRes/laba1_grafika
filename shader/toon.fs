// TOON.FS

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

   float gray = (gl_FragColor.r + gl_FragColor.g + gl_FragColor.b)/3.0;
   
   if(gray > 0.9)
   {
		  gl_FragColor.rgb = vec3(1.0, 0.0, 0.0);
   }
   else if(gray > 0.8)
   {
		  gl_FragColor.rgb = vec3(0.9, 0.0, 0.0);
   }
   else if(gray > 0.7)
   {
		  gl_FragColor.rgb = vec3(0.8, 0.0, 0.0);
   }
   else if(gray > 0.6)
   {
		  gl_FragColor.rgb = vec3(0.7, 0.0, 0.0);
   }
   else if(gray > 0.5)
   {
		  gl_FragColor.rgb = vec3(0.6, 0.0, 0.0);
   }
   else if(gray > 0.4)
   {
		  gl_FragColor.rgb = vec3(0.5, 0.0, 0.0);
   }
   else if(gray > 0.3)
   {
		  gl_FragColor.rgb = vec3(0.4, 0.0, 0.0);
   }
   else if(gray > 0.2)
   {
		  gl_FragColor.rgb = vec3(0.3, 0.0, 0.0);
   }
   else if(gray > 0.1)
   {
		  gl_FragColor.rgb = vec3(0.2, 0.0, 0.0);
   }
   else if(gray >= 0.0)
   {
		  gl_FragColor.rgb = vec3(0.1, 0.0, 0.0);
   }
}

