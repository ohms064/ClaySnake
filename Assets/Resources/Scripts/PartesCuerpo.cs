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
        float verticalValue = Input.GetAxisRaw("Vertical");
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        Vector3 vectorTeclado = Vector3.zero;
        Vector3 posicionCuerpo;
        op = objAnterior.GetComponent<Cabeza>().posicionAnterior;
        if (verticalValue < 0 || verticalValue > 0)
        {
            posicionCuerpo = (objAnterior.GetComponent<Cabeza>().posicionAnterior) - new Vector3(0, 1, 0);
            this.transform.position = posicionCuerpo;
            this.transform.eulerAngles = objAnterior.GetComponent<Cabeza>().rotacionAnterior;
        }
        else
        {
            if (horizontalValue < 0 || horizontalValue > 0)
            {
                posicionCuerpo = (objAnterior.GetComponent<Cabeza>().posicionAnterior) - new Vector3(0, 0, 1);
                this.transform.position = posicionCuerpo;
                this.transform.eulerAngles = objAnterior.GetComponent<Cabeza>().rotacionAnterior;
            }
            else
            {
                this.transform.position = (objAnterior.GetComponent<Cabeza>().posicionAnterior)-new Vector3(0, 1, 0);
            }
        }
        
 
    }
}