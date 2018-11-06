using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// Script associado ao ImageTarget. Utilizado para controlar o uso de botões virtuais, nesse caso na troca entre objetos

public class Controle_Botao_Virtual : MonoBehaviour,
    IVirtualButtonEventHandler
{

    // Variáveis do tipo Private para armazenar os objetos a serem trocados
    private GameObject Objeto_1;
    private GameObject Objeto_2;



    void Start()
    {

        // Gera uma lista dos filhos que são botões virtuais 
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        // Percorre a lista
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Registra os botões para que eventos possam ser acionados
            vbs[i].RegisterEventHandler(this);
        }

        // Procura os GameObjects, filhos, específicos e associa-os as variáveis
        Objeto_1 = transform.Find("Cubo_Esquerdo").gameObject;
        Objeto_2 = transform.Find("Esfera_Direita").gameObject;

        // Desativa os GameObjects, assim não aparece ao iniciar, é necessário primeiro acionar um dos botões virtuais
        Objeto_1.SetActive(false);
        Objeto_2.SetActive(false);
    }


    // Chamado quando um botão virtual for acionado:
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Botão: " + vb.VirtualButtonName + " pressionado.");
        //Debug.Log("Botão pressionado!");

        switch (vb.VirtualButtonName)
        {
            case "VB_Esquerdo":
                Debug.Log("Botão esquerdo pressionado");
                Objeto_1.SetActive(true);   // Ativa o botão esquerdo
                Objeto_2.SetActive(false);  // Desativa o botão direito
                break;

            case "VB_Direito":
                Debug.Log("Botão direito pressionado");
                Objeto_1.SetActive(false);  // Ativa o botão esquerdo
                Objeto_2.SetActive(true);   // Desativa o botão direito
                break;
        }
    }

    /// Chamado quando um botão virtual deixa de ser acionado:
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Botão solto!");
    }
}
