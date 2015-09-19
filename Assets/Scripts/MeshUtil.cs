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
}
