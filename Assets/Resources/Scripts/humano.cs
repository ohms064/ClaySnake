using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class humano{
	//Atributos = Variables globales
	private int edad;
	public float estatura;
	public string nombre;
	public string sexo;

	//Constructor
	public humano(int EDAD, float ESTATURA, string NOMBRE, string SEXO) 
	{
		this.edad = EDAD;
		this.estatura = ESTATURA;
		this.nombre = NOMBRE;
		this.sexo = SEXO;
	}
	public humano()
	{
		this.edad = 99;
		this.estatura = 2.0f;
		this.nombre = "XYZ";
		this.sexo = "H";
	}

	public int obtenerEdad()
	{
		return this.edad;
	}
	public void ColocarEdad(int EDAD)
	{
		this.edad = EDAD;
	}
}