using UnityEngine;
using System.Collections;

public abstract class ACuerpo : MonoBehaviour {
    [SerializeField]
    public ACuerpo siguienteParte;


    public abstract void InicioGiro(Transform transAnterior);

    public abstract void GenerarMovimiento();

    public void GenerarRotacion( Vector3 vectorAux ) {
        if ( vectorAux.Equals( Vector3.zero ) )
            return;
        float dot = Vector3.Dot( this.transform.up, vectorAux );
        if ( dot < 0.05 && dot > -0.05 ) {
            Vector3 cross = Vector3.Cross( this.transform.up, vectorAux );
            float angulo = Vector3.Angle( this.transform.up, vectorAux );
            print( string.Format( "{0} {1} {2}", dot, cross, angulo ) );
            this.transform.eulerAngles += new Vector3( 0f, 0f, angulo * (cross.z < 0 ? -1 : 1) );
        }
    }

}
