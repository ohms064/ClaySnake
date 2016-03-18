using UnityEngine;
using System.Collections;

public class GeneradorHumanos : MonoBehaviour {

	public humano diego;
	public humano rodrigo;
	public humano orlando;
	public humano omar;
	public humano roque;
	public humano x;


	// Use this for initialization
	void Start () {
		this.diego = new humano (19, 1.82f, "Diego", "H");
		this.rodrigo = new humano (18, 1.80f, "Rodrigo", "H");
		this.orlando = new humano (19, 1.72f, "Orlando", "H");
		this.omar = new humano (23, 1.85f, "Omar", "H");
		this.roque = new humano (28, 1.76f, "Roque", "H");
		this.x = new humano ();
	}
	
	// Update is called once per frame
	void Update () {
		int edad01;
		int edad02;

		edad01 = this.diego.obtenerEdad ();
		edad02 = this.roque.obtenerEdad ();
		edad01++;
		edad02--;
		this.diego.ColocarEdad ( edad01 );
		this.roque.ColocarEdad ( edad02 );

		print ("Edad Diego: "+this.diego.obtenerEdad()+" Edad Roque: "+this.roque.obtenerEdad ());
	}
}
