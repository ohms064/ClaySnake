using UnityEngine;
using System.Collections;
using System;

public class Cabeza : MonoBehaviour
{ 
    public float movimiento = 10.0f;            //Velocidad de la cabeza al ser multiplicado por deltatime
    public float limiteTiempoMovimiento = 1f;   //Tiempo movimiento
    public Vector3 posicionAnterior;
    public Vector3 rotacionAnterior;
    //
    private Vector3 vectorRotacionAux;
    private float contadorTiempo;               //Axuliliar paraeltiempo de movimiento
    // Use this for initialization
    void Start() {
        contadorTiempo = 0f;
        vectorRotacionAux = Vector3.zero;
        posicionAnterior = this.transform.position;
        rotacionAnterior = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorTeclado = ChecarTeclas();
        if(!vectorTeclado.Equals(Vector3.zero))
            vectorRotacionAux = vectorTeclado;
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= limiteTiempoMovimiento)
        {
            GeneraRotacion(vectorRotacionAux);
            GenerarMovimiento();
            contadorTiempo = 0f;
            vectorRotacionAux = Vector3.zero;
        }
    }

    void GenerarMovimiento()
    {
        posicionAnterior = this.transform.position;
        rotacionAnterior = this.transform.eulerAngles;
        this.transform.position += this.transform.up * (Time.deltaTime) * this.movimiento;
    }

    
    Vector3 ChecarTeclas()
    {
        float verticalValue = Input.GetAxisRaw("Vertical");
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        Vector3 vectorTeclado = Vector3.zero;
        if (verticalValue < 0 || verticalValue > 0)
            vectorTeclado = new Vector3(0, verticalValue, 0);        
        if (horizontalValue < 0 || horizontalValue > 0)
            vectorTeclado = new Vector3(horizontalValue, 0, 0);
        return vectorTeclado;
    }
    //
    void GeneraRotacion(Vector3 vectorAux)
    {
        if (vectorAux.Equals(Vector3.zero))
            return;
        float dot = Vector3.Dot(this.transform.up, vectorAux);
        if (dot < 0.05 && dot > -0.05)
        {
            Vector3 cross = Vector3.Cross(this.transform.up, vectorAux);
            float angulo = Vector3.Angle(this.transform.up, vectorAux);
            print(string.Format("{0} {1} {2}", dot, cross, angulo));
            this.transform.eulerAngles += new Vector3(0f, 0f, angulo * (cross.z < 0 ? -1 : 1));
        }
    }

}


