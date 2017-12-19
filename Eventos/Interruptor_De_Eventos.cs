using UnityEngine;
using UnityEngine.Events;

public class Interruptor_De_Eventos : MonoBehaviour {
	[Tooltip("Caso verdadeiro, o evento 'ligado' será executado, caso contrário, o 'desligado' será executado.\nEm ambos os casos, o 'ambos' será executado")]
	public bool interruptorLigado;
	public UnityEvent ligado, desligado, ambos;
	public void Mudar_Interruptor() {
		interruptorLigado = !interruptorLigado;
	}

	public void Executar_Interruptor() {
		if (interruptorLigado)
			ligado.Invoke();
		else
			desligado.Invoke();
		ambos.Invoke();
	}

    public void Ligar_Ou_Desligar(bool def) {
        interruptorLigado = def;
    }
}
