using UnityEngine;
using System.Collections;

public class cambiarPosicion : MonoBehaviour {
	public float velocidad;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * velocidad;
		this.transform.Rotate(new Vector3 (1, 1, 1) * Time.deltaTime * velocidad); 
	
	}
}
