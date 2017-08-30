using UnityEngine;
using UnityEngine.Events;

public class Correr : MonoBehaviour {

	#if UNITY_EDITOR

	[Header("Para o Editor")]
    [Tooltip("Isso desenhará uma linha (Gizmos) entre o apontador e o alvo")]
    public bool desenharLinhas = true;

    [Tooltip("Cor da seta de movimento")]
    public Color corDaSeta = Color.red;

	#endif

	[Header("Componente Transform")]
	[Tooltip("Os valores de posição desse Transform que serão modificados ao correr")]
	public Transform corredor;
	
	[Header("Eixos e velocidade")]
	[Tooltip("Velocidade de movimento")]	
	public float velocidade;

	[Tooltip("São os eixos para o Input.GetAxis")]
	public string eixoParaX, eixoParaY, eixoParaZ;
	
	[Tooltip("Isso ativa o uso de Input.GetRawAxis ao invés de Input.GetAxis, a direfença é que não há aquela suavização quando solta/aperta")]
	public bool usarEixosPuros;
	
	[Tooltip("World é relativo ao mundo, Self é local")]
	public Space relativoAo;
	
	[Header("Trancas e Bloqueios")]	
	[Tooltip("Esse eixo não será movimentado")]
	public bool autoExecutar;
	public bool bloquearX, bloquearY, bloquearZ;
	

	[Header("Eventos")]
	[Tooltip("Ao iniciar corrida")]
	public UnityEvent aoIniciarCorrida;

    [Tooltip("Ao parar corrida")]
	public UnityEvent aoTerminarCorrida;

    bool estaCorrendo;

    void Update () {
		if (autoExecutar)
			Movimentar(eixoParaX, eixoParaY, eixoParaZ);
	}

	public void Movimentar(string eixo_x, string eixo_y, string eixo_z) {
		float final_x = bloquearX 
							? 0
							: (usarEixosPuros
								? Input.GetAxisRaw(eixo_x)
								: Input.GetAxis(eixo_x));
		float final_y = bloquearY
							? 0
							: (usarEixosPuros
								? Input.GetAxisRaw(eixo_y)
								: Input.GetAxis(eixo_y));
		float final_z = bloquearZ
							? 0
							: (usarEixosPuros
								? Input.GetAxisRaw(eixo_z)
								: Input.GetAxis(eixo_z));
		Movimentar_Eixos_Dados(final_x, final_y, final_z);
	}

	public void Movimentar_Eixos_Dados(float eixo_x, float eixo_y, float eixo_z) {
		if (!enabled)
			return;
			
		if (eixo_x != 0 || eixo_y != 0 || eixo_z != 0) {
			if (!estaCorrendo)
				aoIniciarCorrida.Invoke();				
			estaCorrendo = true;
		} else {
			if (estaCorrendo)
				aoTerminarCorrida.Invoke();
			estaCorrendo = false;
		}
		
		float velocidade_final = Time.deltaTime * velocidade;
		corredor.Translate(eixo_x * velocidade_final, eixo_y * velocidade_final, eixo_z * velocidade_final, relativoAo);
	}

	public void Parou_Externamente_A_Corrida(bool executar_evento) {
		estaCorrendo = false;
		if (executar_evento)
			aoTerminarCorrida.Invoke();
	}

	public void Iniciou_Externamente_A_Corrida(bool executar_evento) {
		estaCorrendo = true;
		if (executar_evento)
			aoIniciarCorrida.Invoke();
	}

	public void Correr_Externamente_Em_X (float eixo_x) {
		Movimentar_Eixos_Dados(eixo_x, 0f, 0f);
	}

	public void Correr_Externamente_Em_Y (float eixo_y) {
		Movimentar_Eixos_Dados(0f, eixo_y, 0f);
	}

	public void Correr_Externamente_Em_Z (float eixo_z) {
		Movimentar_Eixos_Dados(0f, 0f, eixo_z);
	}

	#region Definicoes

	public void Definir_Velocidade(float definicao) {
		velocidade = definicao;
	}

	public void Definir_Corredor(Transform definicao) {
		corredor = definicao;
	}

	public void Definir_Corredor_Por_Nome (string nome) {
		corredor = GameObject.Find(nome).transform;
	}

	public void Definir_Corredor_Por_Tag (string etiqueta) {
		corredor = GameObject.FindWithTag(etiqueta).transform;
	}

	#endregion

	public void Multiplicar_Velocidade (float multiplicador) {
		velocidade *= multiplicador;
	}

	public void Dividir_Velocidade (float divisor) {
		velocidade /= divisor;
	}

	public void Incrementar_Velocidade(float incrementador) {
		velocidade += incrementador;
	}

	public void Decrementar_Velocidade(float decrementador) {
		velocidade -= decrementador;
	}

	#if UNITY_EDITOR

	void OnDrawGizmos() {
		if (desenharLinhas && corredor) {
			Gizmos.color = corDaSeta;

			float final_x = bloquearX
								? 0
								: (usarEixosPuros
									? Input.GetAxisRaw(eixoParaX)
									: Input.GetAxis(eixoParaX)) * Time.deltaTime * velocidade;
			float final_y = bloquearY
								? 0
								: (usarEixosPuros
									? Input.GetAxisRaw(eixoParaY)
									: Input.GetAxis(eixoParaY)) * Time.deltaTime * velocidade;
			float final_z = bloquearZ
								? 0
								: (usarEixosPuros
									? Input.GetAxisRaw(eixoParaZ)
									: Input.GetAxis(eixoParaZ)) * Time.deltaTime * velocidade;

			Vector3 direcao = new Vector3(final_x, final_y, final_z);
			direcao.Normalize();
			Gizmos.DrawRay(corredor.position, direcao);
			Gizmos.DrawWireSphere(corredor.position + direcao, 0.1f);
		}
	}

	#endif
}
