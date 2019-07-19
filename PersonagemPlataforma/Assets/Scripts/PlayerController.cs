using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float velocidade, forcaPulo;

    private bool verificaChao;

    public Transform chaoVerificador;
  
    void Update()
    {
        Movimentacao();
    }

    public void Movimentacao()
    {
        verificaChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));
        Debug.Log(verificaChao);

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetButtonDown("Jump") && verificaChao)
        {
            Debug.Log("Pulo");
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }

        /*
        //Movimentação, direita e esquerda.
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }

        //Pulo.
        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(Vector2.up * forcaPulo * Time.deltaTime);
            ChaoVerificador = false;
        }
        */
    }
}
