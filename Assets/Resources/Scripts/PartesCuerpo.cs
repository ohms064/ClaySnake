using UnityEngine;
using System.Collections;
using System;

public class PartesCuerpo : MonoBehaviour
{
    public GameObject objSiguiente;
    public GameObject objAnterior;
    public Vector3 posicionAnterior;
    public Vector3 rotacionAnterior;
    public float movimiento = 10.0f;            //Velocidad de la cabeza al ser multiplicado por deltatime
    public float limiteTiempoMovimiento = 1f;
    //
    private float contadorTiempo;
    private float verticalValue;
    private float horizontalValue;
    private bool inicio;
    
    // Use this for initialization
    void Start()
    {
        contadorTiempo = 0f;
    }

    // Update is called once per frame
    void Update()
    { 
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= limiteTiempoMovimiento)
        {
            GenerarMovimiento();
            if (verticalValue != 0 || horizontalValue != 0 )
            {
                inicio = true;
                if (inicio == true)
                {
                    StartCoroutine("AlcanzarSiguiente");
                }
            }
            
            contadorTiempo = 0f;
        }
        
    }
    void GenerarMovimiento()
    {
            posicionAnterior = this.transform.position;
            rotacionAnterior = this.transform.eulerAngles;
            this.transform.position += this.transform.up * (Time.deltaTime) * this.movimiento;
       
    }
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
    void ActualizaTransformacion()
    {
        Vector3 posicionCuerpo;
        posicionCuerpo = (objAnterior.GetComponent<ObtenerPosicion>().posicionAnterior); 
        this.transform.eulerAngles = objAnterior.GetComponent<ObtenerPosicion>().rotacionAnterior;
        print(objAnterior.GetComponent<ObtenerPosicion>().posicionAnterior);
        print(this.transform.position);
    }

    IEnumerator AlcanzarSiguiente()
    {
            while (this.transform.position != objAnterior.GetComponent<ObtenerPosicion>().posicionAnterior) 
            {
                yield return new WaitForEndOfFrame();
                ActualizaTransformacion();
            }
       
    }
    //if(comperatag("s")) && comparetag("wall")

}
