using UnityEngine;
using UnityEngine.Events;
using Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao;

namespace Componentes_Para_Unity.Configuradores {
    public class Configurador_De_Tela_Cheia : MonoBehaviour {
        public UnityEvent aoMudarTelaCheia;
        public bool transmitirTelaCheia;
        public Evento_Bool transmissaoTelaCheia;

        public void Definir_Tela_Cheia(bool def) {
            Screen.fullScreen = def;
            aoMudarTelaCheia.Invoke();
            Transmitir_Tela_Cheia();
        }

        public void Transmitir_Tela_Cheia() {
            if (transmitirTelaCheia)
                transmissaoTelaCheia.Invoke(Screen.fullScreen);
        }

        public void set_transmitirTelaCheia(bool def) {
            transmitirTelaCheia = def;
        }
    }
}
