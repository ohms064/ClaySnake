using UnityEngine;
using System.Collections;

public class ObtenerPosicion : MonoBehaviour
{
    public Vector3 posicionAnterior;
    public Vector3 rotacionAnterior;
    public float movimiento = 10.0f;
    public float limiteTiempoMovimiento = 1f;
    //
    private float contadorTiempo;

    // Use this for initialization
    void Start ()
    {
        contadorTiempo = 0f;
        posicionAnterior = this.transform.position;
        rotacionAnterior = this.transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= limiteTiempoMovimiento)
        {
            posicionAnterior = this.transform.position;
            rotacionAnterior = this.transform.eulerAngles;
        }
    }
}
