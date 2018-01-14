using UnityEngine;
using UnityEngine.Audio;
using Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao;

namespace Componentes_Para_Unity.Configuradores {
    public class Transmitir_Parametro_De_Mixador : MonoBehaviour {
        public AudioMixer mixador;
        public Evento_Float eventoTransmissor;

        public void Transmitir_Parametro_Especifico(string parametro) {
            float valor_param;
            if (mixador.GetFloat(parametro, out valor_param)) {
                float valor_param_linear = Mathf.Pow(2.7182f, valor_param/20);
                eventoTransmissor.Invoke(valor_param_linear);
            }
            else
                Debug.LogError(string.Concat("Parâmetro \'", parametro ,"\' do mixador não encontrado"));
        }
    }
}
