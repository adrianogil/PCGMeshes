using UnityEngine;
using System.Collections;

public class MeshUtil : MonoBehaviour {

	/// <summary>
	/// Generate a Plane
	/// </summary>
	public static Mesh CreatePlane(float width, float height)
	{
		Mesh mesh = new Mesh();

		// Vertices
		Vector3[] vertices = new Vector3[4]
		{
			new Vector3(0,0,0),
			new Vector3(0,width,0),
			new Vector3(0,0,height),
			new Vector3(0,width,height)
		};

		// Triangles
		int[] triangles = new int[6];

		triangles[0] = 0;
		triangles[1] = 2;
		triangles[2] = 1;

		triangles[3] = 2;
		triangles[4] = 3;
		triangles[5] = 1;

		// Normals
		Vector3[] normals = new Vector3[4];

		normals[0] = -Vector3.forward;
		normals[1] = -Vector3.forward;
		normals[2] = -Vector3.forward;
		normals[3] = -Vector3.forward;

		// UV
		Vector2[] uv = new Vector2[4];

		uv[0] = new Vector2(0,0);
		uv[1] = new Vector2(1,0);
		uv[2] = new Vector2(0,1);
		uv[3] = new Vector2(1,1);

		// Setup mesh
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;

		return mesh;
	}

	/// <summary>
	/// Generate a Plane
	/// </summary>
	public static Mesh CreatePlane(float width, float length, int sideVerticesX, int sideVerticesZ)
	{
		Mesh mesh = new Mesh();

		if (sideVerticesX < 2 || sideVerticesZ < 2)
		{
			return mesh;
		}

		// Vertices
		#region Plane - Vertices Calculation
		Vector3[] vertices = new Vector3[sideVerticesX * sideVerticesZ];

		float zPos, xPos;

		for (int z = 0; z < sideVerticesZ; z++ )
		{
			// [ -length/2 , length/2]
			zPos = ((float)z / (sideVerticesZ - 1) - 0.5f) * length;

			for (int x = 0; x < sideVerticesX; x++)
			{
				// [ - width/2, width/2]
				xPos = ((float)x / (sideVerticesX - 1) - 0.5f) * width;

				vertices[x + z * sideVerticesX] = new Vector3(xPos, 0f, zPos);
			}
		}
		#endregion

		// Triangles
		#region Plane - Triangles Calculation
		int numberFaces = (sideVerticesX - 1) * (sideVerticesZ - 1);
		int[] triangles = new int[numberFaces * 6];

		int tIndex = 0, i;

		for (int face = 0; face < numberFaces; face++)
		{
			// Retrieve lower left corner from face index
			i = face % (sideVerticesX - 1) + (face / (sideVerticesZ - 1) * sideVerticesX);

			Debug.Log("Face " + face + ": " + i);

			triangles[tIndex++] = i + sideVerticesX;
			triangles[tIndex++] = i + 1;
			triangles[tIndex++] = i;

			triangles[tIndex++] = i + sideVerticesX;
			triangles[tIndex++] = i + sideVerticesX + 1;
			triangles[tIndex++] = i + 1;	
		}
		#endregion

		// Normals
		#region Plane - Normals Calculation
		Vector3[] normals = new Vector3[vertices.Length];
		for (int n = 0; n < vertices.Length; n++)
		{
			normals[n] = Vector3.up;
		}
		#endregion

		// UV
		#region Plane - UV Calculation
		Vector2[] uv = new Vector2[vertices.Length];
		for (int v = 0; v < sideVerticesZ; v++)
		{
			for (int u = 0; u < sideVerticesX; u++)
			{
				uv[u + v * sideVerticesX] = new Vector2((float)u/(sideVerticesX-1),
														(float)v/(sideVerticesZ-1));
			}
		}
		#endregion

		// Setup mesh
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;

		mesh.RecalculateBounds();
		mesh.Optimize();

		return mesh;
	}
}
