using UnityEngine;
using UnityEngine.Events;

public class Eventos_ColTrig_Condicional_porTag_2D : MonoBehaviour {
    [Tooltip("Se verdadeiro, essa função da Unity não será interrompida")]
    public bool
        usarColEnter2D,  usarColStay2D,  usarColExit2D,  // <-- On Colisions
        usarTrigEnter2D, usarTrigStay2D, usarTrigExit2D; // <-- On Triggers
    [Tooltip("Etiqueta para comparação, se a entiqueta for igual a etiqueta do objeto estrangeiro, então o evento correspondente será executado")]
    public string
        casoTagOnColEnter2D,  casoTagOnColStay2D,  casoTagOnColExit2D,  // <-- On Colisions
        casoTagOnTrigEnter2D, casoTagOnTrigStay2D, casoTagOnTrigExit2D; // <-- On Triggers

    public UnityEvent
        onColEnter2D,  onColStay2D,  onColExit2D,  // <-- On Colisions
        onTrigEnter2D, onTrigStay2D, onTrigExit2D; // <-- On Triggers

    void OnCollisionEnter2D(Collision2D colisao) {
        if (usarColEnter2D) {
            if (colisao.gameObject.CompareTag(casoTagOnColEnter2D))
                onColEnter2D.Invoke();
        }
    }

    void OnCollisionStay2D(Collision2D colisao) {
        if (usarColStay2D) {
            if (colisao.gameObject.CompareTag(casoTagOnColStay2D))
                onColStay2D.Invoke();
        }
    }

    void OnCollisionExit2D(Collision2D colisao) {
        if (usarColExit2D) {
            if (colisao.gameObject.CompareTag(casoTagOnColExit2D))
                onColExit2D.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D colisor) {
        if (usarTrigEnter2D) {
            if (colisor.CompareTag(casoTagOnTrigEnter2D)) {
                onTrigEnter2D.Invoke();
            }
        }
    }

    void OnTriggerStay2D(Collider2D colisor) {
        if (usarTrigStay2D) {
            if (colisor.CompareTag(casoTagOnTrigStay2D))
                onTrigStay2D.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D colisor) {
        if (usarTrigExit2D) {
            if (colisor.CompareTag(casoTagOnTrigExit2D))
                onTrigExit2D.Invoke();
        }
    }

    public void Definir_Uso_Como_Verdadeiro (string nome_da_variavel) {
        Definir_Uso(nome_da_variavel, true);
    }

    public void Definir_Uso_Como_Falso (string nome_da_variavel) {
        Definir_Uso(nome_da_variavel, false);
    }

    public void Definir_Uso(string nome_da_variavel, bool def) {
        switch(nome_da_variavel) {
            case "usarColEnter2D":
                usarColEnter2D = def;
            break;
            case "usarColStay2D":
                usarColStay2D = def;
            break;
            case "usarColExit2D":
                usarColExit2D = def;
            break;
            case "usarTrigEnter2D":
                usarTrigEnter2D = def;
            break;
            case "usarTrigStay2D":
                usarTrigStay2D = def;
            break;
            case "usarTrigExit2D":
                usarTrigExit2D = def;
            break;
        }
    }
}
