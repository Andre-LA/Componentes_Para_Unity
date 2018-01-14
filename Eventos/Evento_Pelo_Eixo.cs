using UnityEngine;
using UnityEngine.Events;
using Componentes_Para_Unity.Enumeracoes;

// TODO: Apenas há evento para quando entra e sai da condição,
// visto que temos botão baixo e cima, é realmente necessário
// limitar para não termos uma invocação por Update?
namespace Componentes_Para_Unity.Componentes_De_Eventos {
    public class Evento_Pelo_Eixo : MonoBehaviour {
        [Header("Condicional")]
        [Tooltip("Eixo para ser usado")]
        public string eixo;
        [Tooltip("Condição a ser usada")]
        public Condicoes condicaoParaAtivar;
        [Tooltip("Comparação, para poder fazer a checagem da condição anterior\n(perigoso usar igual ou diferente, visto que float as vezes dá uns errinhos (tipo 4/2 = 2.000001))")]
        public float comparacao;
        [Tooltip("Tipo de entrada")]
        public Formas_De_Obter_Eixos formaDeObterOEixo;
        [Header("Eventos")]
        public UnityEvent entrouNaCondicao;
        public UnityEvent saiuDaCondicao;
        bool acionado;

        void Update() {
            bool acionamento = Faz_Comparacao();
            if (acionamento) {
                if (!acionado) {
                    acionado = true;
                    entrouNaCondicao.Invoke();
                }
            } else if (acionado) {
                acionado = false;
                saiuDaCondicao.Invoke();
            }
        }

        float Obter_Eixo() {
            switch (formaDeObterOEixo) {
                case Formas_De_Obter_Eixos.Obter_Eixos:
                    return Input.GetAxis(eixo);
                case Formas_De_Obter_Eixos.Obter_Eixos_Puros:
                    return Input.GetAxisRaw(eixo);
                case Formas_De_Obter_Eixos.Obter_Botao:
                    bool res_b = Input.GetButton(eixo);
                    return res_b ? 1f : 0f;
                case Formas_De_Obter_Eixos.Obter_Botao_Baixo:
                    bool res_bd = Input.GetButtonDown(eixo);
                    return res_bd ? 1f : 0f;
                case Formas_De_Obter_Eixos.Obter_Botao_Cima:
                    bool res_bu = Input.GetButtonUp(eixo);
                    return res_bu ? 1f : 0f;
                case Formas_De_Obter_Eixos.Nao_Obter:
                    return 0f;
                default:
                    Debug.LogWarning(string.Concat("Forma de obter eixo não suportada: ", formaDeObterOEixo.ToString(), ". Gbj: ", name));
                    return -1;
            }
        }

        bool Faz_Comparacao() {
            bool resultado = false;
            float eixo_resultado = Obter_Eixo();

            switch (condicaoParaAtivar) {
                case Condicoes.igualA:
                    if (eixo_resultado == comparacao)
                    resultado = true;
                    break;
                case Condicoes.diferente:
                    if (eixo_resultado != comparacao)
                    resultado = true;
                    break;
                case Condicoes.maiorOuIgualAQue:
                    if (eixo_resultado >= comparacao)
                    resultado = true;
                    break;
                case Condicoes.maiorQue:
                    if (eixo_resultado > comparacao)
                    resultado = true;
                    break;
                case Condicoes.menorOuIgualAQue:
                    if (eixo_resultado <= comparacao)
                    resultado = true;
                    break;
                case Condicoes.menorQue:
                    if (eixo_resultado < comparacao)
                    resultado = true;
                    break;
                default:
                    Debug.LogWarning(string.Concat("Tipo de comparação não suportada: ", condicaoParaAtivar.ToString(), ". Gbj: ", name));
                    break;
            }

            return resultado;
        }
    }
}
