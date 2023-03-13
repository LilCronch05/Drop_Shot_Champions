This package contains a didimo.

Inside you will find the core avatar file:

"avatar.gltf": your didimo in industry-standard glTF format.

Along with the following binary files:
"animations.bin": animation data
"ddmo_body.bin": body mesh
"ddmo_head.bin": head mesh
"ddmo_eyeRight.bin": right eye mesh
"ddmo_eyeLeft.bin": left eye mesh
"ddmo_eyelashes.bin": eyelashes mesh
"ddmo_mouth.bin": mouth mesh
"ddmo_clothing.bin": clothing mesh

And texture files:
"ddmo_head_albedo.png": albedo map texture covering the head and face
"ddmo_head_normal.png": normal map texture covering the head and face
"ddmo_head_AO.png": ambient occlusion map texture covering the head and face
"ddmo_head_cavity.png": cavity map texture covering the head and face
"ddmo_head_micronormal.png": micro normal map texture covering the head and face
"ddmo_head_rough.png": roughness map texture covering the head and face
"ddmo_head_spec.png": specular map texture covering the head and face
"ddmo_head_SSS_AO_mask.png": determines by how much the subsurface scattering contribution is modulated with the ambient occlusion map on head and face
"ddmo_head_trans.png": translucency map texture covering the head and face
"ddmo_mouth_albedo.png": albedo map texture covering the mouth
"ddmo_mouth_normal.png": normal map texture covering the mouth
"ddmo_mouth_AO.png": ambient occlusion map texture covering the mouth
"ddmo_eye_albedo.png": albedo map texture covering the eyes
"ddmo_eye_normal.png": normal map texture covering the eyes
"ddmo_eyelashes_albedo_opacity.png": albedo opacity map texture covering the eyelashes
"ddmo_body_albedo.png": albedo map texture covering the body
"ddmo_body_normal.png": normal map texture covering the body
"ddmo_body_AO.png": ambient occlusion map texture covering the body
"ddmo_body_cavity.png": cavity map texture covering the body
"ddmo_body_micronormal.png": micro normal map texture covering the body
"ddmo_body_rough.png": roughness map texture covering the body
"ddmo_body_spec.png": specular map texture covering the head and face
"ddmo_body_SSS_AO_mask.png": determines by how much the subsurface scattering contribution is modulated with the ambient occlusion map on the body
"ddmo_body_trans.png": translucency map texture covering the body
"ddmo_body_clothing_mask.png": clothing mask covering the body
"ddmo_clothing_albedo_opacity.png": albedo opacity map texture covering the clothing
"ddmo_clothing_normal.png": normal map texture covering the clothing
"ddmo_clothing_AO.png": ambient occlusion map texture covering the clothing
"ddmo_clothing_metal_rough.png": roughness and metallic map textures covering the clothing

Extras:
"deformation_matrix.dmx": to be used on deformation related endpoints
"metadata.json": includes metadata about the package
"avatar_info.json": companion file that specifies didimo meta information (texture maps, animation frames)


Instructions for the use of your didimo:
----------------------------------------

The provided glTF file includes the mesh geometry of the didimo, an attached facial skeleton, blendshapes, and keyframes for animation and posing.

To use your didimo inside a project or application, import the glTF file using an appropriate glTF importer.

Sometimes the textures may have to be assigned manually, according to the application.

Enjoy your didimo!


Website: https://didimo.co
Customer Portal: https://app.didimo.co
Developer Portal: https://docs.didimo.co
Email: support@didimo.co