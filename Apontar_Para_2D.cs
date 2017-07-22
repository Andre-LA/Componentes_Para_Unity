using UnityEngine;

public class Apontar_Para_2D : MonoBehaviour {
    #if UNITY_EDITOR

    [Header("Para o Editor")]
    [Tooltip("Isso desenhará uma linha (Gizmos) entre o apontador e o alvo")]
    public bool desenharLinhas = true;
    [Tooltip("Cor da linha entre os dois")]
    public Color corEntreOsDois = Color.red;
    [Tooltip("Cor da rotação do apontador")]
    public Color corDaRotacao = Color.red;

    #endif

    [Header("Componentes Transforms")]
	[Tooltip("Transform do Gbj que vai apontar ao alvo")]
    public Transform apontador;
    [Tooltip("Transform do alvo que o apontador vai apontar")]
    public Transform alvo;
    
    [Header("Propriedades modificadoras")]
    [Tooltip("Se for > 0, então a quantidade de ângulos possíveis será a abaixo")]
    public int limiteAngulos;
    [Tooltip("Use isso para adicionar na rotação resultante (assim mudará qual a ponta do apontador)")]
    public float rotacaoExtra;

    void Update() {
        float angulo = Obtem_Angulo_Para_Apontar();
        if (limiteAngulos > 0) {
            float pedaco_angulo = 360f / limiteAngulos;
            for (int i = 0; i <= limiteAngulos; i++) {
                if (angulo > i * pedaco_angulo - pedaco_angulo/2)
                    Aplica_Rotacao(i * pedaco_angulo + rotacaoExtra);
            }            
        } else {
            angulo += rotacaoExtra;
            Aplica_Rotacao(angulo);
        }
    }

    void Aplica_Rotacao(float angulo) {
        apontador.rotation = Quaternion.Euler(0, 0, angulo);
    }

    float Obtem_Angulo_Para_Apontar() {
        Vector2 posicao_relativa = new Vector2(alvo.position.x - apontador.position.x, alvo.position.y - apontador.position.y);
        posicao_relativa.Normalize();
            
        float angulo_180 = Vector2.Angle(new Vector2(1, 0), posicao_relativa);

        if (posicao_relativa.y < 0)
            angulo_180 = 360f - angulo_180;
            
        return angulo_180;
    }

    #if UNITY_EDITOR

    void OnDrawGizmos() {
        if (desenharLinhas && alvo && apontador) {
            Gizmos.color = corEntreOsDois;
            Gizmos.DrawLine(apontador.position, alvo.position);
            Gizmos.DrawWireSphere(apontador.position, 0.5f);

            Gizmos.color = corDaRotacao;
            Vector3 direcao = new Vector3( Mathf.Cos(apontador.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(apontador.eulerAngles.z * Mathf.Deg2Rad) );
            Gizmos.DrawRay(apontador.position, direcao);
        }
    }

    #endif
}
