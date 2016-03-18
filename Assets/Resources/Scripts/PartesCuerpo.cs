using UnityEngine;
using System.Collections;

public class PartesCuerpo : MonoBehaviour
{
    public GameObject objSiguiente;
    public GameObject objAnterior;
    public Vector3 posicionAnterior;
    public Vector3 rotacionAnterior;
    public Vector3 op;
    public DistanceJoint2D distancia;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ActualizaTransformacion();
    }
    void ActualizaTransformacion()
    {
        op = objAnterior.GetComponent<Cabeza>().posicionAnterior;
        this.transform.position = objAnterior.GetComponent<Cabeza>().posicionAnterior;
        this.transform.eulerAngles = objAnterior.GetComponent<Cabeza>().rotacionAnterior;
		this.distancia.distance = 20;
    }
}