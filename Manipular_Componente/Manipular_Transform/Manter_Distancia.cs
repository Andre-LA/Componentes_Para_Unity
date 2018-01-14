using UnityEngine;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Transform {
    public class Manter_Distancia : MonoBehaviour {
    	#if UNITY_EDITOR

        [Header("Para o Editor")]
        [Tooltip("Isso desenhará uma linha (Gizmos) entre o apontador e o alvo")]
        public bool desenharLinhas = true;
        [Tooltip("Cor da distância")]
        public Color corDaDistancia = Color.red;
    	[Tooltip("Cor da distância máxima")]
    	public Color corDaDistanciaMaxima = Color.red;
    	[Tooltip("Cor da distância mínima")]
    	public Color corDaDistanciaMinima = Color.red;

        #endif

    	[Header("Componentes Transform")]
    	[Tooltip("Quem: quem sofrerá limitação relativo ao Do Que")]
    	public Transform quem;
    	[Tooltip("Do Que: será o ponto relativo de Quem para obter a distância")]
    	public Transform doQue;

    	[Header("Limitações")]
    	[Tooltip("Faz com que haja um limite mínimo")]
    	public bool limitarMinimo;
    	[Tooltip("Faz com que haja um limite máximo")]
    	public bool limitarMaximo;
    	[Tooltip("Distância Mínima para a limitação")]
    	public float distanciaMinima;
    	[Tooltip("Distância Máxima para a limitação")]
    	public float distanciaMaxima;

    	void Update() {
    		Aplicar_Distancia();
    	}

    	public void Aplicar_Distancia() {
    		if (!enabled)
    			return;

    		float distancia = Vector3.Distance(quem.position, doQue.position);
    		Vector3 deslocar = quem.position - doQue.position;

    		if (limitarMaximo && distancia > distanciaMaxima) {
    			deslocar = deslocar.normalized * (distancia - distanciaMaxima);
    			quem.position = quem.position - deslocar;
    		} else if (limitarMinimo && distancia < distanciaMinima) {
    			deslocar = deslocar.normalized * (distancia - distanciaMinima);
    			quem.position = quem.position - deslocar;
    		}
    	}

    	public void Definir_Quem(Transform definicao) {
    		quem = definicao;
    	}

    	public void Definir_Quem_Por_Nome (string nome) {
    		quem = GameObject.Find(nome).transform;
    	}

    	public void Definir_Quem_Por_Tag (string etiqueta) {
    		quem = GameObject.FindWithTag(etiqueta).transform;
    	}

        public void Definir_DoQue(Transform definicao) {
    		doQue = definicao;
    	}

    	public void Definir_DoQue_Por_Nome (string nome) {
    		doQue = GameObject.Find(nome).transform;
    	}

    	public void Definir_DoQue_Por_Tag (string etiqueta) {
    		doQue = GameObject.FindWithTag(etiqueta).transform;
    	}

    	#if UNITY_EDITOR

    	void OnDrawGizmos() {
    		if (desenharLinhas && quem && doQue) {
                float distancia = Vector3.Distance(quem.position, doQue.position);

    			Gizmos.color = corDaDistancia;
    			Gizmos.DrawWireCube(quem.position, new Vector3(distancia, distancia, distancia));

    			Gizmos.color = corDaDistanciaMaxima;
    			Gizmos.DrawWireCube(quem.position, new Vector3(distanciaMaxima, distanciaMaxima, distanciaMaxima));

    			Gizmos.color = corDaDistanciaMinima;
    			Gizmos.DrawWireCube(quem.position, new Vector3(distanciaMinima, distanciaMinima, distanciaMinima));
            }
    	}

    	#endif
    }
}
