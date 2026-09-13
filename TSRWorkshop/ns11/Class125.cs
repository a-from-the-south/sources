using System;
using ns10;
using ns12;
using ns2;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns11
{
	// Token: 0x02000115 RID: 277
	internal sealed class Class125 : DefaultAllocateHierarchy
	{
		// Token: 0x06000C7A RID: 3194 RVA: 0x0009E040 File Offset: 0x0009C240
		public MeshContainer CreateMeshContainer(string name, MeshData meshData, ExtendedMaterial[] materials, EffectInstance[] effectInstances, int[] adjacency, SkinInfo skinInfo)
		{
			if (meshData.Mesh == null)
			{
				throw new ArgumentException();
			}
			if (meshData.Mesh.VertexFormat == VertexFormat.None)
			{
				throw new ArgumentException();
			}
			Class126 @class = new Class126();
			@class.Name = name;
			int faceCount = meshData.Mesh.FaceCount;
			Device device = meshData.Mesh.Device;
			if ((meshData.Mesh.VertexFormat & VertexFormat.Normal) == VertexFormat.None)
			{
				meshData.Mesh.Clone(device, meshData.Mesh.CreationOptions, meshData.Mesh.VertexFormat | VertexFormat.Normal);
			}
			@class.SetMaterials(materials);
			@class.SetAdjacency(adjacency);
			Texture[] array = new Texture[materials.Length];
			for (int i = 0; i < materials.Length; i++)
			{
				if (materials[i].TextureFileName != null)
				{
					array[i] = Class123.smethod_0().method_0(device, materials[i].TextureFileName);
				}
			}
			@class.method_1(array);
			@class.MeshData = meshData;
			if (skinInfo != null)
			{
				@class.SkinInfo = skinInfo;
				int boneCount = skinInfo.BoneCount;
				Matrix[] array2 = new Matrix[boneCount];
				for (int j = 0; j < boneCount; j++)
				{
					array2[j] = skinInfo.GetBoneOffsetMatrix(j);
				}
				@class.method_7(array2);
				Class128.smethod_0(@class);
			}
			return @class;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x0009E180 File Offset: 0x0009C380
		public Frame CreateFrame(string name)
		{
			return new Class127
			{
				Name = name,
				TransformationMatrix = Matrix.Identity,
				CombinedTransformationMatrix = Matrix.Identity
			};
		}
	}
}
