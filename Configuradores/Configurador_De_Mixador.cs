using UnityEngine;
using UnityEngine.Audio;

public class Configurador_De_Mixador : MonoBehaviour {
    public AudioMixer mixadorAlvo;
    public string parametroParaManipular;
    public string[] parametrosParaManipular;
    public int volumeDbMinimo, volumeDbMaximo;

    const float um_div_euler = 1/2.7182f; // 1 divido por euler

    public void Definir_Parametro_Db(float def) {
#if UNITY_EDITOR
        Debug.Assert(def <= 1 || def >= 0, string.Concat("def precisa ser entre 0 e 1, ele está ", def));
#endif
        int indice = Obter_Indice(parametroParaManipular);
        string parametro = parametrosParaManipular[indice];
        float def_euler = Mathf.Pow(def, um_div_euler);
        float diferenca_dos_volumes = Mathf.Abs(volumeDbMaximo - volumeDbMinimo);
        mixadorAlvo.SetFloat(parametro, volumeDbMinimo + (diferenca_dos_volumes * def_euler));
    }

    public void Definir_Parametro_Para_Manipuluar(string def) {
        parametroParaManipular = def;
    }

    int Obter_Indice(string parametro) {
        for (int i = 0; i < parametrosParaManipular.Length; i++)
            if (parametrosParaManipular[i] == parametro)
                return i;
        Debug.LogError(string.Concat("Parâmetro '" , parametro,"' não encontrado na ordenada parametrosParaManipular "));
        return -1;
    }

    #if UNITY_EDITOR
    void OnValidate() {
        if (!mixadorAlvo)
            return;

        float seila;
        // verifica se algum dos parametros não existe no mixador
        for (int i = 0; i < parametrosParaManipular.Length; i++) {
            if (!mixadorAlvo.GetFloat(parametrosParaManipular[i], out seila))
                Debug.LogError(string.Concat("O parâmetro ", parametrosParaManipular[i], ", dentro de parametrosParaManipular[", i,"], não existe no mixadorAlvo"));
        }

        Debug.Assert(volumeDbMinimo >= -80 || volumeDbMinimo <= 20 || volumeDbMaximo >= -80 || volumeDbMaximo <= 20, "volumes Db precisam estar entre -80 e 20");
    }
    #endif
}
