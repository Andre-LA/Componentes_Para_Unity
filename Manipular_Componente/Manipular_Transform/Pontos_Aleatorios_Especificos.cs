using UnityEngine;
using Componentes_Para_Unity.Enumeracoes;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Transform {
    public class Pontos_Aleatorios_Especificos : MonoBehaviour {
        [Tooltip("Alvo a ter posição global alterada")]
        public Transform alvo;
        [Tooltip("Em que ordem o indice deve ser atu")]
        public OrdemNumerica ordemNumerica;
        public Vector3[] posicoes;
        int indice;

        void Update() {
            Atualizar_Posicao();
        }

        public void Atualizar_Indice() {
            switch (ordemNumerica) {
                case OrdemNumerica.Aleatoria:
                    indice = Random.Range(0, posicoes.Length);
                    break;
                case OrdemNumerica.SequencialIncremento:
                    indice++;
                    if (indice > posicoes.Length - 1)
                        indice = 0;
                    break;
                case OrdemNumerica.SequencialDecremento:
                    indice--;
                    if (indice < 0)
                        indice = posicoes.Length - 1;
                    break;
                default:
                    Debug.LogWarning("Ordem númerica não reconhecida");
                    break;
            }
        }

        public void Atualizar_Posicao() {
            alvo.position = posicoes[indice];
        }

        public void Definir_Indice(int def) {
            if (indice >= 0 || indice < posicoes.Length)
                indice = def;
        }
    }
}
