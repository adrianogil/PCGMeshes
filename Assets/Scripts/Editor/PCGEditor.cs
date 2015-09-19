using UnityEngine;
using UnityEditor;
using System.Collections;

public class PCGEditor : MonoBehaviour {

	[MenuItem("PCG/Meshes/Planes")]
	static void GeneratePlane()
	{	
		Debug.Log("I am about to generate a plane.");

		Mesh mesh = MeshUtil.CreatePlane(1f,1f, 9, 9);

		GameObject gameObject = new GameObject("Plane");
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();

		MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
		meshFilter.mesh = mesh;

		meshFilter.sharedMesh.RecalculateBounds();

		Material planeMaterial = Resources.Load("Materials/PlaneMaterial") as Material;

		MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
		meshRenderer.material = planeMaterial;
	}		
}
