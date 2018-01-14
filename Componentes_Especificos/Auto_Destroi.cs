using UnityEngine;
using UnityEngine.Events;

namespace Componentes_Para_Unity {
    public class Auto_Destroi : MonoBehaviour {
        [Tooltip("tempo para auto-destruição, se for <= 0, então o gbj não será destruido por tempo")]
    	public float tempo;
    	[Tooltip("Caso verdadeiro, a contagem (que usa incremento por delta tempo) não será influenciada pela escala de tempo")]
    	public bool independenteDeEscalaDeTempo;
    	[Tooltip("Se deve haver a contagem")]
    	public bool contar;
        float contador;
    	[Tooltip("Gameobject que será destruido")]
    	public GameObject alvo;
    	public UnityEvent aoDestruir;

    	void Update() {
    		if (contar)
    			contador += independenteDeEscalaDeTempo ? Time.unscaledDeltaTime : Time.deltaTime;
    		if (contador > tempo && tempo > 0) {
    			Destrucao_Imediata();
    		}
    	}

        // TODO Mudar para Destruir() no próximo projeto
    	public void Destrucao_Imediata() {
    		aoDestruir.Invoke();
    		Destroy(alvo);
    	}

    	public void Definir_Contador(float novo_tempo) {
    		contador = novo_tempo;
    	}

    	public void Continuar_Contagem (bool novo_contar) {
    		contar = novo_contar;
    	}

    	public void Definir_Tempo (float novo_tempo) {
    		tempo = novo_tempo;
    	}

    	public void Definir_Alvo(GameObject definicao) {
    		alvo = definicao;
    	}

    	public void Definir_Alvo_Por_Nome (string nome) {
    		alvo = GameObject.Find(nome);
    	}

    	public void Definir_Alvo_Por_Tag (string etiqueta) {
    		alvo = GameObject.FindWithTag(etiqueta);
    	}
    }
}
