using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPosition : MonoBehaviour {
	[SerializeField] private float m_floorHeight;
	private float                  m_spriteLowerBound;
	private float                  m_spriteHalfWith;
	private readonly float    	   m_tan30 = Mathf.Tan(Mathf.PI / 5); 



	// Use this for initialization
	void Start () {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
		m_spriteLowerBound = spriteRenderer.bounds.size.y * 0.5f;
		m_spriteHalfWith = spriteRenderer.bounds.size.x * 0.5f;
	}
	
	// Update is called once per frame
	//#if UNITY_EDITOR
	void LateUpdate(){
		//if (!Application.isPlaying) {
		
			transform.position = new Vector3 
				(	
					transform.position.x,
					transform.position.y,
					(transform.position.y - m_spriteLowerBound + m_floorHeight) * m_tan30
				);
		}

	//}
	//#endif


void OnDrawGizmos(){
		Vector3 floorHeightPos = new Vector3 
			(transform.position.x, (transform.position.y - m_spriteLowerBound + m_floorHeight) * m_tan30, transform.position.z);

		Gizmos.color = Color.magenta;
		Gizmos.DrawLine (floorHeightPos + Vector3.left * m_spriteHalfWith,
			floorHeightPos + Vector3.right * m_spriteHalfWith);




	}
}