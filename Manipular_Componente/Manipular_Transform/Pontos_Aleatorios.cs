using UnityEngine;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Transform {
    public class Pontos_Aleatorios : MonoBehaviour {
        [Tooltip("Transform a ser manipulado")]
        public Transform alvo;
        [Tooltip("Caso verdadeiro, o alvo \"caminhará\" até a posição, caso contrário, será apenas uma definição")]
        public bool usarLerp;
        [Tooltip("Velocidade da interpolação (caso use)")]
        public float velocidade;
        [Tooltip("Caso verdadeiro, a velocidade não será influenciada pela escala de tempo")]
        public bool independenteDeEscalaDeTempo;
        [Tooltip("Posição inicial do alvo (quando gameobject despertar (awake))")]
        public Vector3 posInicial;
        [Tooltip("Posição mímima para limitar aleatório")]
        public Vector3 minimo;
        [Tooltip("Posição máxima para limitar aleatório")]
        public Vector3 maximo;
        Vector3 pos_alvo;

        void Awake() {
            alvo.localPosition = posInicial;
        }

        void Start() {
            Criar_Nova_Pos_Alvo();
        }

        void Update() {
            if (usarLerp)
                alvo.position = Vector3.Lerp(alvo.position, pos_alvo, velocidade * (independenteDeEscalaDeTempo ? Time.unscaledDeltaTime : Time.deltaTime));
            else
                alvo.position = pos_alvo;
        }

        public void Criar_Nova_Pos_Alvo() {
            pos_alvo.x = Random.Range(minimo.x, maximo.x);
            pos_alvo.y = Random.Range(minimo.y, maximo.y);
            pos_alvo.z = Random.Range(minimo.z, maximo.z);
        }
    }
}
