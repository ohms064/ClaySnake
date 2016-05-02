using UnityEngine;
using System.Collections;
using System;

public class PartesCuerpo : ACuerpo
{
    //Se heredan las variables posicionAnterior, rotacionAnterior y siguienteParte.
    public float movimiento = 10.0f;            //Velocidad de la cabeza al ser multiplicado por deltatime
    public float limiteTiempoMovimiento = 1f;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame

    override public void GenerarMovimiento() {
        this.transform.position += this.transform.up * this.movimiento;  
        siguienteParte.GenerarMovimiento();  
    }

    IEnumerator AlcanzarSiguiente(Transform transAlcanzar) {
        Vector3 posicionAlcanzar = transAlcanzar.position;
        Vector3 rotacionAlcanzar = transAlcanzar.localEulerAngles;
        while (this.transform.position != posicionAlcanzar ) {
            yield return new WaitForFixedUpdate();
        }
        this.transform.localEulerAngles = rotacionAlcanzar;
        siguienteParte.InicioGiro( this.transform ); //Iniciamos la corutina para la siguiente pieza
       
    }
    /// <summary>
    /// Esta función es llamada desde una sección anterior del cuerpo.
    /// </summary>
    /// <param name="posicion"></param>
    override public void InicioGiro( Transform transAnterior ) {
        StartCoroutine( "AlcanzarSiguiente", transAnterior );
    }

}
