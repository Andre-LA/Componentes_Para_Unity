using UnityEngine;

public class Manipulador_AudioSource : MonoBehaviour {
    public AudioSource fonteDeAudio;
    public OrdemNumerica ordem;
    public bool inicializarFonteDeAudio;
    public AudioClip[] sons;
    public int indice;

    void Start() {
        if (inicializarFonteDeAudio) {
            Atualizar_Indice();
            Atualizar_Musica();
        }
    }

    public void Atualizar_Indice() {
        switch (ordem) {
            case OrdemNumerica.Aleatoria:
                indice = Random.Range(0, sons.Length);
            break;
            case OrdemNumerica.SequencialIncremento:
                indice++;
                if (indice >= sons.Length)
                    indice = 0;
            break;
            case OrdemNumerica.SequencialDecremento:
                indice--;
                if (indice < 0)
                    indice = sons.Length - 1;
                break;
            default:
                Debug.LogError("Tipo de ordem numérica não suportada");
            break;
        }
    }

    public void Atualizar_Musica() {
        fonteDeAudio.Stop();
        fonteDeAudio.clip = sons[indice];
        if (fonteDeAudio.enabled)
            fonteDeAudio.Play();
    }

    #region Definições

    public void Definir_Indice(int def) {
        if (def < 0) {
            Debug.LogError("Definição de índice apenas poderia ser dentro do intervalo [0, " + sons.Length.ToString() + "[, mas foi " + def.ToString());
            return;
        }

        indice = def;
        while (indice >= sons.Length)
            indice -= sons.Length;
    }

    public void Definir_AudioFonte(AudioSource def) {
        fonteDeAudio = def;
    }

    public void Definir_ClipeDeAudio(AudioClip def, int i) {
        if (i >= 0 && i < sons.Length)
            sons[i] = def;
        else
            Debug.LogError("Indice inválido: apenas poderia ser dentro do intervalo [0, " + sons.Length.ToString() + "[, mas foi " + i.ToString());
    }

    #endregion
}
