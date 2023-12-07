// Fragment Shader v4
// Simple Diffuse lighting Shader

#version 130

// INTERPOLOWANE WEJ�CIE z VS (varying)
smooth in vec4 vVaryingColor;

// WYJ�CIE
out vec4 vFragColor; // kolor fragmentu

void main( void )
{ 
   vFragColor = vVaryingColor; // przepisanie interpolowanego koloru
}