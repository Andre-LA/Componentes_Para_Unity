using UnityEngine;

public class Dificuldade_Linear : MonoBehaviour {
    static int dificuldade_estatica = 0;
    public Eventos_Ordenados eventosDeDificuldade;

    void Start() {
        eventosDeDificuldade.indice = dificuldade_estatica;
        Executar_Dificuldade();
    }

    void Update() {
        if (eventosDeDificuldade.indice != dificuldade_estatica) {
            eventosDeDificuldade.indice = dificuldade_estatica;
            Executar_Dificuldade();
        }
    }

    public void Executar_Dificuldade() {
        eventosDeDificuldade.Executar();
    }
    public void Executar_Dificuldade_Especifica(int i) {
        eventosDeDificuldade.Executar_Especifico(i);
    }

    public void Definir_Dificuldade(int def) {
        dificuldade_estatica = def;
    }
    public void Incrementa_Dificuldade(int inc) {
        dificuldade_estatica += inc;
    }

    public void Definir_Eventos_Ordenados_Por_Nome(string nome) {
        eventosDeDificuldade = GameObject.Find(nome).GetComponent<Eventos_Ordenados>();
    }
    public void Definir_Eventos_Ordenados_Por_Etiqueta(string etiqueta) {
        eventosDeDificuldade = GameObject.FindWithTag(etiqueta).GetComponent<Eventos_Ordenados>();
    }
}
