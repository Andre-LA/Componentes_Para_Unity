using UnityEngine;
using UnityEngine.UI;
using Componentes_Para_Unity.Enumeracoes;
using Componentes_Para_Unity.Configuradores;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Text {
    public class Escrever_Configuracoes : MonoBehaviour {
        public Configuracao configuracaoParaEscrever;
        public string prefixo;
        public Text textoAlvo;
        public string sufixo;

        public void Escrever_Configuracao() {
            switch(configuracaoParaEscrever) {
                case Configuracao.Qualidade:
                    int indice_qualidade_atual = QualitySettings.GetQualityLevel();
                    textoAlvo.text = string.Concat(prefixo, QualitySettings.names[indice_qualidade_atual], sufixo);
                    break;
                case Configuracao.Resolucao:
                    Resolution resolucao_atual = Configurador_De_Resolucao.Obter_Resolucao_Atual();
                    string resolucao = string.Concat(resolucao_atual.width, "x", resolucao_atual.height);
                    textoAlvo.text = string.Concat(prefixo, resolucao, sufixo);
                    break;
                case Configuracao.TelaCheia:

                    break;
                /* TODO Suportar as outras configuracoes
                case Configuracao.VolumeEfeitosSonoros:
                    break;
                case Configuracao.VolumeGeral:
                    break;
                case Configuracao.VolumeMusica:
                    break;
                case Configuracao.VSync:
                    break;
                */
                default:
                    Debug.LogWarning(string.Concat("Configuracao ", configuracaoParaEscrever.ToString(), " não é suportada"));
                    break;
            }
        }

        #if UNITY_EDITOR
        void OnValidate() {
            if (configuracaoParaEscrever != Configuracao.Qualidade
             && configuracaoParaEscrever != Configuracao.Resolucao
             && configuracaoParaEscrever != Configuracao.TelaCheia/*
             && configuracaoParaEscrever != Configuracao.VolumeEfeitosSonoros
             && configuracaoParaEscrever != Configuracao.VolumeGeral
             && configuracaoParaEscrever != Configuracao.VolumeMusica
             && configuracaoParaEscrever != Configuracao.VSync*/)
                Debug.LogWarning(string.Concat("André, você precisa implementar ", typeof(Configuracao), ".", configuracaoParaEscrever.ToString(), " no ", typeof(Escrever_Configuracoes)));
        }
        #endif
    }
}
