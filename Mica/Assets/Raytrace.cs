using UnityEngine;
using System.Collections;

public class Raytrace : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Trace(0f,1000f,90f);
	}

	public Color Trace(float x, float width, float fov){
		float k = Mathf.Tan(fov * Mathf.Deg2Rad/2f);

		float xDir = (x - width/2f) * (2f * k)/width;
		float rotation = Mathf.Atan(xDir) * Mathf.Rad2Deg;
		Vector2 direction = Quaternion.AngleAxis(rotation, new Vector3(0,0,-1)) * transform.forward;
		direction.Normalize();
		Vector2 origin = transform.position;

		//Debug.DrawRay(origin,direction);

		Ray ray = new Ray(origin,direction);
		RaycastHit[] hits = Physics.RaycastAll(ray);

		if(hits.Length > 0){
			//Find closest hit
			RaycastHit closestHit = new RaycastHit();
			float minDistance = Mathf.Infinity;

			foreach(RaycastHit hit in hits){
				//Debug.Log("Distance" + hit.distance);
				if(hit.distance < minDistance){
					minDistance = hit.distance;
					closestHit = hit;
				}
			}

			//get color off of hit
			Renderer rend = closestHit.transform.GetComponent<Renderer>();
			MeshCollider meshCollider = closestHit.collider as MeshCollider;
			Texture2D tex = rend.material.mainTexture as Texture2D;

			Color pixel = tex.GetPixelBilinear(closestHit.textureCoord.x, closestHit.textureCoord.y);

			//Debug.Log("Color " + pixel);

			return pixel;
		}
		else return new Color(0,0,0);

	}
}
