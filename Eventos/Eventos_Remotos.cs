using UnityEngine;
using UnityEngine.Events;
using Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao;

namespace Componentes_Para_Unity.Componentes_De_Eventos {
    public class Eventos_Remotos : MonoBehaviour {
        [Tooltip("Componente de outro gameobject que será acionado")]
    	public Eventos eventosRemotos;
        public UnityEvent aoAcionarRemotamente;

        public void Executar_Evento_Remoto() {
            if (eventosRemotos && enabled) {
                aoAcionarRemotamente.Invoke();
                eventosRemotos.Acionar();
            }
        }

        public void Definir_Eventos_Remotos_Por_Nome(string nome) {
            eventosRemotos = GameObject.Find(nome).GetComponent<Eventos>();
        }
        public void Definir_Eventos_Remotos_Por_Etiqueta(string etiqueta) {
            eventosRemotos = GameObject.FindWithTag(etiqueta).GetComponent<Eventos>();
        }
        public void Definir_Eventos (Eventos def) {
            eventosRemotos = def;
        }
        public void Anular_Eventos () {
            eventosRemotos = null;
        }
    }
}
