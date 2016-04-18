using UnityEngine;
using System.Collections;

public class Comida : MonoBehaviour
{

    public Comida esfcomida;
    GameObject objeto;
    // Use this for initialization
    void Start()
    {
       objeto = GameObject.Find("Food");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f));
        Instantiate(esfcomida, posicion, Quaternion.identity);
        Destroy(objeto);
        Destroy(this.gameObject);
    }

    /*void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }*/
}
