using UnityEngine;

namespace Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao {
    public class Eventos_Float : MonoBehaviour{
        public Evento_Float evento;

        public void Acionar(float arg) {
            evento.Invoke(arg);
        }
    }
}
