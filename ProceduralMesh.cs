using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
public class ProceduralMesh : MonoBehaviour {

	public float quadSize = 1f;
	public Vector3 quadOffset;


	Mesh mesh;

	Vector3[] vertices;
	int[] triangles;



	void Awake() {
		mesh = GetComponent<MeshFilter> ().mesh;
	}

	// Use this for initialization
	void Start () {
		MakeMeshData (quadSize, quadOffset);
		CreateMesh ();
	}
	
	void MakeMeshData (float size, Vector3 offset){
		//set size of vertices and triangles arrays
		vertices = new Vector3[4];
		triangles = new int[6];
		float vertexOffset = size / 2;

		//populate arrays
		vertices [0] = new Vector3 (-vertexOffset, 0, -vertexOffset) + offset;
		vertices [1] = new Vector3 (-vertexOffset, 0, vertexOffset) + offset;
		vertices [2] = new Vector3 (vertexOffset, 0, -vertexOffset) + offset;
		vertices [3] = new Vector3 (vertexOffset, 0,  vertexOffset) + offset;

		triangles [0] = 0;
		triangles [1] = 1;
		triangles [2] = 2;
		triangles [3] = 2;
		triangles [4] = 1;
		triangles [5] = 3;


	}

	void CreateMesh(){
		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;

		mesh.RecalculateNormals ();


	
	}
}
