using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCube : MonoBehaviour {

	Mesh mesh;
	List<Vector3> vertices;
	List<int> triangles;

	public float scale = 1f;
	public int posX, posY, posZ;

	float adjScale;



	// Use this for initialization
	void Awake () {
		mesh = GetComponent<MeshFilter> ().mesh;
		adjScale = scale * 0.5f;
	}

	void Start() {
		MakeCube (adjScale, new Vector3((float)posX * scale, (float)posY * scale, (float)posZ * scale));
		UpdateMesh ();
	}

	void MakeCube (float cubeScale, Vector3 cubePos){
		vertices = new List<Vector3> ();
		triangles = new List<int> ();

		for (int i = 0; i < 6; i++) {
			MakeFace (i, cubeScale, cubePos);
		}
	}

	void MakeFace (int dir, float faceScale, Vector3 facePos){
		vertices.AddRange (CubeMeshData.faceVertices (dir, faceScale, facePos));
		int vCount = vertices.Count;

		triangles.Add (vCount - 4);
		triangles.Add (vCount - 4 + 1);
		triangles.Add (vCount - 4 + 2);
		triangles.Add (vCount - 4);
		triangles.Add (vCount - 4 + 2);
		triangles.Add (vCount - 4 + 3);

	}

	void UpdateMesh(){
		mesh.Clear ();

		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.RecalculateNormals ();
	}
}
