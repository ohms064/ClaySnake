using UnityEngine;
using System.Collections;
using System;

public class PartesCuerpo : MonoBehaviour
{
    public GameObject objSiguiente;
    public GameObject objAnterior;
    public Vector3 posicionAnterior;
    public Vector3 rotacionAnterior;
    public DistanceJoint2D distancia; // Esta variable no se está utilizando
    public float movimiento = .5f;

    //Te recomiendo que declares tus variables aquí y en el Update lo iguales en GetAxisRaw correspondiente.
    //private float verticalValue;
    //private float horizontalValue;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verticalValue = Input.GetAxisRaw("Vertical"); 
        float horizontalValue = Input.GetAxisRaw("Horizontal");//aquí hay un problema, se está obteniendo el GetAxisRaw varias veces en el código. En el Update, en ActualizaTransformación y en AlcanzarSiguiente.

        GeneraRotacion(Vector3.zero); //Esta función no está haciendo nada, es mejor quitarla.

        this.transform.position = ActualizaTransformacion(); //Aquí vuelves a obtener el GetAxisRaw, te recomiendo que verticalValue y horizontalValue sean globales (por así decir, técnicamente este script es un objeto y sus variables se llaman propiedades) y las utilices en donde corresponda.
        //Además ActualizaTransformacion retorna justamente this.transform.position así que es redundante igualarlo

        if (verticalValue!=0)
        {
            StartCoroutine("AlcanzarSiguiente");
            GeneraRotacion(Vector3.zero); //Esta función no está haciendo nada, es mejor quitarla.
            //this.transform.position = ActualizaTransformacion();
        }
        if (horizontalValue != 0)
        {
            StartCoroutine("AlcanzarSiguiente");
            GeneraRotacion(Vector3.zero); //Esta función no está haciendo nada, es mejor quitarla.
            //this.transform.position = ActualizaTransformacion();
        }
    }

    Vector3 ActualizaTransformacion()
    {
        float verticalValue = Input.GetAxisRaw("Vertical");
        float horizontalValue = Input.GetAxisRaw("Horizontal"); // Nada más decláralas en un lugar
        Vector3 vectorTeclado = Vector3.zero; // No veo que utilices esta variable
        Vector3 posicionCuerpo;
        posicionCuerpo = (objAnterior.GetComponent<Cabeza>().posicionAnterior); //Aquí estas asumiendo que el objeto anterior es la Cabeza lo cual sólo será cierto cuando tengamos dos partes del cuerpo.
        if (verticalValue < 0 || verticalValue > 0) // verticalValue != 0, recuerda cambiarlo a esta forma en lugar del mayor y menor que
        {
            this.transform.position = posicionCuerpo - new Vector3(0, verticalValue, 0); // Aquí está el porque sólo cuando presionas una tecla de dirección te sigue esto es porque forzas a que se igualen. No hagas esto, mejor haz que cada parte del cuerpo se mueva en la dirección de la última rotación.
            this.transform.position += this.transform.up * (Time.deltaTime) * verticalValue; //Esta parte debería ir en el update. 
            //La linea anterior veo que no la usas en el caso de horizontalValue.
            this.transform.eulerAngles = objAnterior.GetComponent<Cabeza>().rotacionAnterior;
            print(objAnterior.GetComponent<Cabeza>().posicionAnterior);
            print(this.transform.position);
        }
        else
        {
            if (horizontalValue < 0 || horizontalValue > 0)
            {
                this.transform.position = posicionCuerpo - new Vector3(horizontalValue, 0, 0);
                //Falta la linea que mencioné arriba, igual debería usarse en el update.
                this.transform.eulerAngles = objAnterior.GetComponent<Cabeza>().rotacionAnterior;
                print(objAnterior.GetComponent<Cabeza>().posicionAnterior);
                print(this.transform.position);
            }
        }
        return this.transform.position; // No tiene caso retornar esto por que ya se puede accesar a la posición en cualquier momento
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
            if (this.transform.position == objAnterior.GetComponent<Cabeza>().posicionAnterior) //Esta condición hace que el siguiente while nunca se ejecute
            {
                while (this.transform.position != objAnterior.GetComponent<Cabeza>().posicionAnterior) //Para este momento ya sabemos que la condición no se cumple así que nunca se ejecutará el while
                {
                    if (verticalValue != 0)
                    {
                        this.transform.up = objAnterior.GetComponent<Cabeza>().transform.up; // Perdona aquí sí te lo dije yo pero me parece que sí debes rotarlo de otra forma, ya tienes la función de GenerarRotación. Además no es necesario obtener Cabeza, puedes acceder el transform directametne
                    }
                    if (horizontalValue != 0)
                    {
                        this.transform.up = objAnterior.GetComponent<Cabeza>().transform.up;
                    }
                }
                break; //A este break nunca se llega por lo que la corutina nunca termina. Por eso se mueve hacia arriba indefinidamente.
            }
            transform.position += new Vector3(0,1,0); //Aquí está la razón por la que se mueve hacia arriba. Piensa de esta corrutina como un Update, se estará ejecutando en cada Frame. Borra esta linea
            yield return new WaitForEndOfFrame();
        }
    }
    //if(comperatag("s")) && comparetag("wall")

}
