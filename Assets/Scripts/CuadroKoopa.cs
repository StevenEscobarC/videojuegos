using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadroKoopa : MonoBehaviour
{
    public int limite;
    public Vector3 inicio;

    public int dir;

    bool direccion;

    // Start is called before the first frame update
    void Start()
    {
        direccion = true;
        this.inicio = this.transform.position;
        

    }

    // Update is called once per frame
    // ciclo infinito
    void Update()
    {
        if(dir == 1){
            desplazamientoX();
        } else {
            desplazamientoZ();
        }
    }

    void desplazamientoX()
    {
        if (this.transform.position.x < this.limite && direccion)
        {
            this.transform.position = new Vector3(this.transform.position.x + (3f * Time.deltaTime), this.transform.position.y, this.transform.position.z);
            if (transform.position.x > limite)
            {
                direccion = false;
            }
        }

        if (this.transform.position.x > this.inicio.x && direccion == false)
        {
            this.transform.position = new Vector3(this.transform.position.x - (3f * Time.deltaTime), this.transform.position.y, this.transform.position.z);
            if (this.transform.position.x < this.inicio.x)
            {
                direccion = true;
            }

        }
    }

    void desplazamientoZ()
    {
        if (this.transform.position.z < this.limite && direccion)
        {
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z + (3f * Time.deltaTime));
            if (transform.position.z > limite)
            {
                direccion = false;
            }
        }

        if (this.transform.position.z > this.inicio.z && direccion == false)
        {
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z - (3f * Time.deltaTime));
            if (this.transform.position.z < this.inicio.z)
            {
                direccion = true;
            }

        }
    }

}




