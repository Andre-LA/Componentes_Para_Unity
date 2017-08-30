using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Instanciador_De_Gbjs : MonoBehaviour {
	[Tooltip("Lista de modelos a serem instanciados")]
	public GameObject[] modelos;
	[HideInInspector]
	public GameObject ultimoInstanciado;
	int modelo_indice;
	[Tooltip("Operação a ser executada no contador da lista ao instanciar")]
	public Operadores operacao;
	[Tooltip("Caso verdadeiro, um modelo aleatório da lista de modelos será escolhido")]
	public bool escolherModeloAleatoriamente;
	[Tooltip("Caso verdadeiro, a posição do instanciado será a mesma do alvo")]
	public bool usarPosicaoDoAlvo;
	[Tooltip("Caso verdadeiro, a rotação do instanciado será a mesma do alvo")]
	public bool usarRotacaoDoAlvo;
	[Tooltip("Alvo de referência para a instanciação")]
	public Transform alvo;
	public UnityEvent aoInstanciar;
	
	public void Instanciar() {
		Vector3 posicao_final = usarPosicaoDoAlvo ? alvo.position : transform.position;
		Quaternion rotacao_final = usarRotacaoDoAlvo ? alvo.rotation : transform.rotation;

		GameObject modelo = Obtem_Modelo();

		ultimoInstanciado = Instantiate<GameObject>(modelo, posicao_final, rotacao_final);

		aoInstanciar.Invoke();
	}

	GameObject Obtem_Modelo() {
		if (escolherModeloAleatoriamente)
			modelo_indice = Random.Range(0, modelos.Length);

		return modelos[modelo_indice];
	}

	public void Mudar_Indice_Do_Modelo() {
		switch(operacao) {
			case Operadores.incremento:
				modelo_indice++;
				if (modelo_indice >= modelos.Length)
					modelo_indice = 0;
			break;
			case Operadores.decremento:
				modelo_indice--;
				if (modelo_indice < 0)
					modelo_indice = modelos.Length - 1;
			break;
			default:
				Debug.LogError("O valor de operação DEVE ser incremento ou decremento");
			break;
		} 
	}

	public void Definir_Indice_Do_Modelo(int definicao) {
		modelo_indice = definicao;
	}

	public void Definir_Modelos_Por_Tag (string etiqueta) {
		modelos = GameObject.FindGameObjectsWithTag(etiqueta);
	}
}
