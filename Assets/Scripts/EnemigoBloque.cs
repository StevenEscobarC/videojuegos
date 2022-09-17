using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBloque : MonoBehaviour
{
    Vector3 psInicial;
    bool colision;
    float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        this.colision = false;
        this.psInicial = this.transform.position;
        this.velocidad = 8f;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Terrain")
        {
            
            this.colision = true;
            reproducirSonido();
            this.velocidad = 3f;
        }
    }

    void reproducirSonido()
    {
        if(!this.GetComponent<AudioSource>().isPlaying)
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, GameObject.Find("FPSController").transform.position) < 10f){
            accion();
        } else {
            if(this.transform.position.y < this.psInicial.y){
                regresarInicial();
            }
            
        }
        
    }

    void regresarInicial(){
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (velocidad * Time.deltaTime), this.transform.position.z);
    }

    void accion(){
        if (!colision)
        { //bajar
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (velocidad * Time.deltaTime), this.transform.position.z);
        }
        if(colision)
        { //subir
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (velocidad * Time.deltaTime), this.transform.position.z);
            if (this.transform.position.y > this.psInicial.y)
            {
                colision = false;
                velocidad = 2f;
            }

        }
    }

}

