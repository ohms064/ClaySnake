using UnityEngine;
using System.Collections;
using System;

public class Cabeza : ACuerpo {
    //Se heredan las variables posicionAnterior, rotacionAnterior y siguienteParte.
    public float movimiento = 10.0f;            //Velocidad de la cabeza al ser multiplicado por deltatime
    public float limiteTiempoMovimiento = 1f;   //Tiempo movimiento
    //
    private Vector3 vectorRotacionAux;
    private Transform transformAnterior;
    //
    public GameObject cuerpo;
    private Vector3 cuerponuevo;
    // Use this for initialization
    void Start() {
        vectorRotacionAux = Vector3.zero;
        transformAnterior = this.transform;
        StartCoroutine( "IniciarMovimiento" );
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorTeclado = ChecarTeclas();
        if ( !vectorTeclado.Equals( Vector3.zero ) ) {
            vectorRotacionAux = vectorTeclado;
            GenerarRotacion( vectorRotacionAux );
            InicioGiro( transformAnterior );
        }
    }

    IEnumerator IniciarMovimiento()
    {
        yield return new WaitForSeconds( limiteTiempoMovimiento );
        while ( true ) {
            transformAnterior = this.transform;

            this.transform.position += this.transform.up * this.movimiento;
            vectorRotacionAux = Vector3.zero;

            siguienteParte.GenerarMovimiento();

            yield return new WaitForSeconds( limiteTiempoMovimiento );
        }
    }

    
    Vector3 ChecarTeclas()
    {
        float verticalValue = Input.GetAxisRaw("Vertical");
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        Vector3 vectorTeclado = Vector3.zero;
        if (verticalValue != 0)
            vectorTeclado = new Vector3(0, verticalValue, 0);        
        if (horizontalValue != 0)
            vectorTeclado = new Vector3(horizontalValue, 0, 0);
        return vectorTeclado;
    }

    override public void InicioGiro( Transform transAnterior ) {
        siguienteParte.InicioGiro( transAnterior );
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Player"))
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
        else if (c.collider.CompareTag("Pared"))
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
        else if (c.collider.CompareTag("Comida"))
        {
            //Vector3 cuerponuevo = new Vector3(2, 0, 2);
            //Instantiate(cuerpo, cuerponuevo, Quaternion.identity);
        }
    }

    public override void GenerarMovimiento() {
        throw new NotImplementedException();
    }
}


