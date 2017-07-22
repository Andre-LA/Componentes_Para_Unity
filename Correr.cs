using UnityEngine;

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
	
	[Tooltip("World é relativo ao mundo, Self é é local")]
	public Space relativoAo;
	
	[Header("Trancas e Bloqueios")]	
	[Tooltip("Esse eixo não será movimentado")]
	public bool bloquearX, bloquearY, bloquearZ;
		
	void Update () {
		Movimentar();
	}

	public void Movimentar() {
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

		corredor.Translate(final_x, final_y, final_z, relativoAo);
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
