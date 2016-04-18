using UnityEngine;
using System.Collections;
using System;

public class PartesCuerpo : MonoBehaviour
{
    public GameObject objSiguiente;
    public GameObject objAnterior;
    public Vector3 posicionAnterior;
    public Vector3 rotacionAnterior;
    public DistanceJoint2D distancia;
    public float movimiento = .5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verticalValue = Input.GetAxisRaw("Vertical");
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        GeneraRotacion(Vector3.zero);
        this.transform.position = ActualizaTransformacion();
        if (verticalValue!=0)
        {
            StartCoroutine("AlcanzarSiguiente");
            GeneraRotacion(Vector3.zero);
            this.transform.position = ActualizaTransformacion();
        }
        if (horizontalValue != 0)
        {
            StartCoroutine("AlcanzarSiguiente");
            GeneraRotacion(Vector3.zero);
            this.transform.position = ActualizaTransformacion();
        }
    }

    Vector3 ActualizaTransformacion()
    {
        float verticalValue = Input.GetAxisRaw("Vertical");
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        Vector3 vectorTeclado = Vector3.zero;
        Vector3 posicionCuerpo;
        posicionCuerpo = (objAnterior.GetComponent<Cabeza>().posicionAnterior);
        if (verticalValue < 0 || verticalValue > 0) // verticalValue != 0
        {
            this.transform.position = posicionCuerpo - new Vector3(0, verticalValue, 0);
            this.transform.position += this.transform.up * (Time.deltaTime) * verticalValue;
            this.transform.eulerAngles = objAnterior.GetComponent<Cabeza>().rotacionAnterior;
            print(objAnterior.GetComponent<Cabeza>().posicionAnterior);
            print(this.transform.position);
        }
        else
        {
            if (horizontalValue < 0 || horizontalValue > 0)
            {
                this.transform.position = posicionCuerpo - new Vector3(horizontalValue, 0, 0);

                this.transform.eulerAngles = objAnterior.GetComponent<Cabeza>().rotacionAnterior;
                print(objAnterior.GetComponent<Cabeza>().posicionAnterior);
                print(this.transform.position);
            }
        }
        return this.transform.position;
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
    IEnumerator AlcanzarSiguiente()
    {
        float verticalValue = Input.GetAxisRaw("Vertical");
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        while (true)
        {
            if (this.transform.position == objAnterior.GetComponent<Cabeza>().posicionAnterior)
            {
                while (this.transform.position != objAnterior.GetComponent<Cabeza>().posicionAnterior)
                {
                    if (verticalValue != 0)
                    {
                        this.transform.up = objAnterior.GetComponent<Cabeza>().transform.up;
                    }
                    if (horizontalValue != 0)
                    {
                        this.transform.up = objAnterior.GetComponent<Cabeza>().transform.up;
                    }
                }
                break;
            }
            transform.position += new Vector3(0,1,0);
            yield return new WaitForEndOfFrame();
        }
    }
    //if(comperatag("s")) && comparetag("wall")

}
