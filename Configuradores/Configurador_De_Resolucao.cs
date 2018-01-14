using UnityEngine;
using UnityEngine.Events;
using Componentes_Para_Unity;

namespace Componentes_Para_Unity.Configuradores {
    public class Configurador_De_Resolucao : MonoBehaviour {
        public static int indiceResolucaoAtual;
        public bool indiceResolucaoCiclico;

        public UnityEvent aoMudarResolucao;

        void Start() {
            indiceResolucaoAtual = Descobrir_Indice_Da_Resolucao_Atual();
        }

        int Encontrar_Indice_Resolucao_Atual() {
            Resolution[] resolucoes = Screen.resolutions;
            for (int i = 0; i < resolucoes.Length; i++)
                if (resolucoes[i].width  == Screen.resolutions[indiceResolucaoAtual].width
                &&  resolucoes[i].height == Screen.resolutions[indiceResolucaoAtual].height)
                    return i;

            Debug.LogError("Resolucao Atual nao encontrada");
            return -1;
        }

        int Descobrir_Indice_Da_Resolucao_Atual() {
            Resolution[] resolucoes = Screen.resolutions;
            for (int i = 0; i < resolucoes.Length; i++)
                if (resolucoes[i].width  == Screen.width
                &&  resolucoes[i].height == Screen.height)
                    return i;

            Debug.LogError("Resolucao Atual nao encontrada");
            return -1;
        }

        public static Resolution Obter_Resolucao_Atual() {
            return Screen.resolutions[indiceResolucaoAtual];
        }

        public void Definir_Indice_Resolucao_Atual(int indiceResolucao) {
            indiceResolucaoAtual = indiceResolucao;
        }

        public void Atualizar_Resolucao() {
            Resolution nova_resolucao = Screen.resolutions[indiceResolucaoAtual];
            Screen.SetResolution(nova_resolucao.width, nova_resolucao.height, Screen.fullScreen);
            aoMudarResolucao.Invoke();
        }

        public void Incrementar_Indice_Resolucao_Atual(int inc) {
            Resolution resolucao_atual_antiga = Obter_Resolucao_Atual();
            bool estava_no_primeiro_ou_ultimo_indice = indiceResolucaoAtual == 0 || indiceResolucaoAtual == Screen.resolutions.Length - 1;

            // Essa função de apoio já limita se indice ciclico não é ciclico
            indiceResolucaoAtual = Funcoes_De_Apoio.Incrementa_Indice(indiceResolucaoAtual, inc, Screen.resolutions.Length, indiceResolucaoCiclico);

            Resolution resolucao_atual_nova = Obter_Resolucao_Atual(); // resolucao atual já foi modificada

            // Ao que parece, a ordenada de resoluções vem com várias resoluções iguais
            // por isso, o Incrementar vai pular se a nova resolução é igual a antiga
            // mas ele só faz isso se o indice for ciclico e se ele não estiver nos limites
            if (resolucao_atual_nova.width == resolucao_atual_antiga.width
            && resolucao_atual_nova.height == resolucao_atual_antiga.height
            && indiceResolucaoCiclico
            && !estava_no_primeiro_ou_ultimo_indice)
                Incrementar_Indice_Resolucao_Atual(inc > 0 ? 1 : -1);
        }
    }
}
