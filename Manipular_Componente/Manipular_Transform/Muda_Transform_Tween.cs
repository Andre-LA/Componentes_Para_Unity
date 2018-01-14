using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Transform {
    public class Muda_Transform_Tween : MonoBehaviour {
        [Tooltip("Transform a ser manipulado")]
        public Transform alvo;
        [Tooltip("Caso verdadeiro, essa variável será inicializada")]
        public bool usarPosInicial, usarRotacaoInicial, usarEscalaInicial;
        [Tooltip("Se os valores devem ser usados como definição ou multiplicação (ex: 1 = 100%)")]
        public bool usarPorMultiplicacao;
        [Tooltip("Caso verdadeiro, essa propriedade não será manipulada")]
    	public bool naoTrabalharEmPosicao, naoTrabalharEmRotacao, naoTrabalharEmEscala;
        [Tooltip("Por quanto tempo durará a execução")]
        public float tempoSegs;
        [Tooltip("Valor inicial da propriedade")]
        public Vector3 posicaoInicial, rotacaoInicial, escalaInicial;
        [Tooltip("Valor final da propriedade")]
        public Vector3 posicaoFinal, rotacaoFinal, escalaFinal;

        public UnityEvent aoIniciar, aoTerminar;

        public void Iniciar () {
            StartCoroutine(Comeca_Tween());
        }

    	IEnumerator Comeca_Tween () {
            aoIniciar.Invoke();

            Vector3 posicao = alvo.localPosition;
            Vector3 escala = alvo.localScale;
            Vector3 rotacao = alvo.eulerAngles;

            Vector3 pos_inicial_2lerp = usarPorMultiplicacao
                                            ? new Vector3(posicao.x * posicaoInicial.x,
                                                        posicao.y * posicaoInicial.y,
                                                        posicao.z * posicaoInicial.z)
                                            : posicaoInicial;

            Vector3 pos_final_2lerp = usarPorMultiplicacao
                                        ? new Vector3(posicao.x * posicaoFinal.x,
                                                        posicao.y * posicaoFinal.y,
                                                        posicao.z * posicaoFinal.z)
                                        : posicaoFinal;

            Vector3 rot_inicial_2lerp = usarPorMultiplicacao
                                            ? new Vector3(rotacao.x * rotacaoInicial.x,
                                                        rotacao.y * rotacaoInicial.y,
                                                        rotacao.z * rotacaoInicial.z)
                                            : rotacaoInicial;

            Vector3 rot_final_2lerp = usarPorMultiplicacao
                                        ? new Vector3(rotacao.x * rotacaoFinal.x,
                                                        rotacao.y * rotacaoFinal.y,
                                                        rotacao.z * rotacaoFinal.z)
                                        : rotacaoFinal;

            Vector3 esc_inicial_2lerp = usarPorMultiplicacao
                                            ? new Vector3(escala.x * escalaInicial.x,
                                                            escala.y * escalaInicial.y,
                                                            escala.z * escalaInicial.z)
                                            : escalaInicial;

            Vector3 esc_final_2lerp = usarPorMultiplicacao
                                            ? new Vector3(escala.x * escalaFinal.x,
                                                        escala.y * escalaFinal.y,
                                                        escala.z * escalaFinal.z)
                                            : escalaFinal;

            for (float i = 0; i < tempoSegs * 30; i++) {
                float interpol = i / (tempoSegs * 30);
    			if (!naoTrabalharEmPosicao)
                	alvo.localPosition    = Vector3.Lerp(pos_inicial_2lerp, pos_final_2lerp, interpol);
    			if (!naoTrabalharEmEscala)
                	alvo.localScale       = Vector3.Lerp(esc_inicial_2lerp, esc_final_2lerp, interpol);
    			if (!naoTrabalharEmRotacao)
                	alvo.localEulerAngles = Vector3.Lerp(rot_inicial_2lerp, rot_final_2lerp, interpol);
                yield return new WaitForSeconds(0.033f);
            }

            aoTerminar.Invoke();
        }

    	#region Definicoes

    	#region Posicao

    	public void Definir_Pos_Final_Por_Pos_Local_Transform (Transform tr_pos_local) {
    		posicaoFinal = tr_pos_local.localPosition;
    	}

    	public void Definir_Pos_Final_Por_Pos_Global_Transform (Transform tr_pos_global) {
    		posicaoFinal = tr_pos_global.position;
    	}

    	public void Definir_Pos_Inicial_Por_Pos_Local_Transform (Transform tr_pos_local) {
    		posicaoInicial = tr_pos_local.localPosition;
    	}

    	public void Definir_Pos_Inicial_Por_Pos_Global_Transform (Transform tr_pos_global) {
    		posicaoInicial = tr_pos_global.position;
    	}

    	#endregion

    	#region Escala

    	public void Definir_Escala_Final_Por_Escala_Local_Transform (Transform tr_esc_local) {
    		escalaFinal = tr_esc_local.localScale;
    	}

    	public void Definir_Escala_Final_Por_Escala_Global_Transform (Transform tr_esc_global) {
    		escalaFinal = tr_esc_global.lossyScale;
    	}

    	#endregion

    	#region Rotacao

    	public void Definir_Rotacao_Final_Por_Rotacao_Local_Transform (Transform tr_rot_local) {
    		rotacaoFinal = tr_rot_local.localRotation.eulerAngles;
    	}

    	public void Definir_Rotacao_Final_Por_Rotacao_Global_Transform (Transform tr_rot_global) {
    		rotacaoFinal = tr_rot_global.rotation.eulerAngles;
    	}

    	#endregion

    	#region segundos
    	public void Definir_Segundos(float definicao) {
    		tempoSegs = definicao;
    	}
    	#endregion

    	#endregion

        void Start () {
            if (usarPosInicial)
                posicaoInicial = usarPorMultiplicacao ? Vector3.one : alvo.localPosition;
            if (usarEscalaInicial)
                escalaInicial = usarPorMultiplicacao ? Vector3.one : alvo.localScale;
            if (usarRotacaoInicial)
                rotacaoInicial = usarPorMultiplicacao ? Vector3.one : alvo.eulerAngles;
        }
    }
}
