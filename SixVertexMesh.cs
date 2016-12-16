using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
public class SixVertexMesh : MonoBehaviour {

	Mesh mesh;

	Vector3[] vertices;
	int[] triangles;

	void Awake() {
		mesh = GetComponent<MeshFilter> ().mesh;
	}

	// Use this for initialization
	void Update () {
		MakeMeshData ();
		CreateMesh ();
	}

	void MakeMeshData (){
		//create an array of vertices
		vertices = new Vector3[]{ 	new Vector3(0,YValue.ins.yValue,0), new Vector3(0,0,1), 	new Vector3 (1,0,0),
									new Vector3 (1,0,0), 				new Vector3(0,0,1), 	new Vector3 (1,0,1)};
		//create an array of integers
		triangles = new int[] { 0, 1, 2, 3, 4, 5 };

	}

	void CreateMesh(){
		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;

		mesh.RecalculateNormals ();



	}
}
