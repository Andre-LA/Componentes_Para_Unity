using UnityEngine;

public class Transladar : MonoBehaviour {
	[Tooltip("Alvo que será transladado")]
	public Transform alvo;
	[Tooltip("direção (e velocidade) de translação")]
	public Vector3 translacao;
	[Tooltip("espaço relativo, define se deve usar os eixos locais ou globais")]
	public Space espacoRelativo;
	[Tooltip("Se deve ser usado o delta tempo")]
	public bool usarDeltaTime;
	[Tooltip("Se o delta tempo não será influenciado pela escala de tempo")]
	public bool independenteDeEscalaDeTempo;
	
	public void Aplicar_Translacao() {
		alvo.Translate(translacao * (usarDeltaTime ? (independenteDeEscalaDeTempo ? Time.unscaledDeltaTime : Time.deltaTime) : 1) , espacoRelativo);
	}

	public void Definir_Translacao(Vector3 definicao) {
		translacao = definicao;
	}
	public void Definir_Translacao(float x, float y, float z) {
		translacao.x = x;
		translacao.y = y;
		translacao.z = z;
	}
	public void Definir_Translacao_X(float definicao) {
		translacao.x = definicao;
	}
	public void Definir_Translacao_Y(float definicao) {
		translacao.y = definicao;
	}
	public void Definir_Translacao_Z(float definicao) {
		translacao.z = definicao;
	}
}
