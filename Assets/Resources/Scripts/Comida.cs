using UnityEngine;
using System.Collections;

public class Comida : MonoBehaviour
{
    public GameObject esfcomida;

    void OnTriggerEnter(Collider triggerFood)
    {
        Vector3 posicion = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f));
        Instantiate(esfcomida, posicion, Quaternion.identity);
        Destroy(this.gameObject);

        //esfcomida.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f));
    }
}