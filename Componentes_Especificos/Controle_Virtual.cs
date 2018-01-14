using UnityEngine;
using Componentes_Para_Unity.Enumeracoes;

namespace Componentes_Para_Unity.Componentes_Especificos {
    public class Controle_Virtual : MonoBehaviour {
        [System.Serializable]
        public struct Eixos {
            public string eixosVirtuais;
            public string eixosDaEngine;
            public Formas_De_Obter_Eixos obterEixoUsando;
        }

        public Eixos[] eixos;

        [HideInInspector]
        public float[] valoresFinais;

        void Awake() {
            valoresFinais = new float[eixos.Length];
        }

        void Update() {
            for (int i = 0; i < eixos.Length; i++) {
                switch (eixos[i].obterEixoUsando) {
                    case Formas_De_Obter_Eixos.Obter_Botao:
                        valoresFinais[i] = Input.GetButton(eixos[i].eixosDaEngine) ? 1f : 0f;
                    break;
                    case Formas_De_Obter_Eixos.Obter_Botao_Baixo:
                        valoresFinais[i] = Input.GetButtonDown(eixos[i].eixosDaEngine) ? 1f : 0f;
                    break;
                    case Formas_De_Obter_Eixos.Obter_Botao_Cima:
                        valoresFinais[i] = Input.GetButtonUp(eixos[i].eixosDaEngine) ? 1f : 0f;
                        break;
                    case Formas_De_Obter_Eixos.Obter_Eixos:
                        valoresFinais[i] = Input.GetAxis(eixos[i].eixosDaEngine);
                    break;
                    case Formas_De_Obter_Eixos.Obter_Eixos_Puros:
                        valoresFinais[i] = Input.GetAxisRaw(eixos[i].eixosDaEngine);
                    break;
                    case Formas_De_Obter_Eixos.Nao_Obter: break;
                    default:
                        Debug.LogError("Entrada não suportada");
                    break;
                }
            }
        }

        public void Definir_Valor(int indice, float def) {
            valoresFinais[indice] = def;
        }

        public void Definir_Valor(string eixo, float def) {
            int indice = Obter_Indice_Pelo_Nome_Do_Eixo(eixo);
            if (indice >= 0)
                Definir_Valor(indice, def);
        }

        public int Obter_Indice_Pelo_Nome_Do_Eixo (string nome) {
            for (int i = 0; i < eixos.Length; i++) {
                if (eixos[i].eixosVirtuais == nome)
                    return i;
            }
            Debug.LogError("Eixo \"" + nome + "\" não encontrado");
            return -1;
        }

        public float Obter_Valor_Flutuante(string eixo) {
            int indice = Obter_Indice_Pelo_Nome_Do_Eixo(eixo);
            return valoresFinais[indice];
        }

        public bool Obter_Valor_Booleano (string eixo) {
            return Obter_Valor_Flutuante(eixo) > 0.5f;
        }
    }
}
