using UnityEngine;
using System.Collections;
using System;

public class Cola : ACuerpo {
    public float movimiento = 10.0f;
    public override void InicioGiro( Transform transAnterior ) {
        StartCoroutine( "AlcanzarSiguiente", transAnterior );
    }

    override public void GenerarMovimiento() {

        this.transform.position += this.transform.up * movimiento;
    }

    IEnumerator AlcanzarSiguiente( Transform transAlcanzar ) {
        Vector3 posicionAlcanzar = transAlcanzar.position;
        Vector3 rotacionAlcanzar = transAlcanzar.localEulerAngles;
        while ( this.transform.position != posicionAlcanzar ) {
            yield return new WaitForFixedUpdate();
        }
        this.transform.localEulerAngles = rotacionAlcanzar;

    }


}
