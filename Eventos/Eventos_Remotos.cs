using UnityEngine;
using UnityEngine.Events;

public class Eventos_Remotos : MonoBehaviour {
    [Tooltip("Componente de outro gameobject que será acionado")]
	public Eventos eventosRemotos;
    public UnityEvent aoAcionarRemotamente;

    public void Executar_Evento_Remoto() {
        if (eventosRemotos) {
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
}
