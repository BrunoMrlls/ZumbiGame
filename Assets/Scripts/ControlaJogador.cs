using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10;
    Vector3 dir;
    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis( "Horizontal" );
        float eixoZ = Input.GetAxis( "Vertical" );

        dir = new Vector3( eixoX, 0, eixoZ );

        
        //transform.Translate( passosPorSegundo( dir ) * Velocidade );
       
        bool ativarAnimacao = isEstaSeMovendo( dir );
        ativaAnimacaoMoverPersonagem( ativarAnimacao );
      
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(
             GetComponent<Rigidbody>().position + (passosPorSegundo( dir ) * Velocidade) );
    }

    private void ativaAnimacaoMoverPersonagem( bool ativar ) {
        GetComponent<Animator>().SetBool("Movendo", ativar);
    }

    private bool isEstaSeMovendo( Vector3 dir ) {
            return dir != Vector3.zero;
    }

    private Vector3 passosPorSegundo( Vector3 vector ) {
        return vector * Time.deltaTime;
    }
}
