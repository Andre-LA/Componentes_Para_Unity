using UnityEngine;
using UnityEngine.Events;

public class Eventos : MonoBehaviour {
    public UnityEvent evento;

    public void Acionar() {
        evento.Invoke();
    }

    public void Imprimir(string mensagem) {
        print (mensagem);
    }
}
