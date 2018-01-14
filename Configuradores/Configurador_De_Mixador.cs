using UnityEngine;
using UnityEngine.Audio;
using Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao;

namespace Componentes_Para_Unity.Configuradores {
    public class Configurador_De_Mixador : MonoBehaviour {
        public AudioMixer mixadorAlvo;
        public string parametroParaManipular;
        public string[] parametrosParaManipular;

        public Evento_Float aoManipularParametro;

        public void Definir_Parametro_Db(float def) {
            #if UNITY_EDITOR
            Debug.Assert(def <= 1 || def >= 0, string.Concat("def precisa ser entre 0 e 1, ele está ", def));
            #endif
            int indice = Obter_Indice(parametroParaManipular);
            string parametro = parametrosParaManipular[indice];

            float db = def == 0 ? -80 : 20 * Mathf.Log(def);
            mixadorAlvo.SetFloat(parametro, db);

            aoManipularParametro.Invoke(db);
        }

        public void Definir_Valor_Parametro(float def) {
            int indice = Obter_Indice(parametroParaManipular);
            string parametro = parametrosParaManipular[indice];

            mixadorAlvo.SetFloat(parametro, def);

            aoManipularParametro.Invoke(def);
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
            for (int i = 0; i < parametrosParaManipular.Length; i++)
                if (!mixadorAlvo.GetFloat(parametrosParaManipular[i], out seila))
                    Debug.LogError(string.Concat("O parâmetro ", parametrosParaManipular[i], ", dentro de parametrosParaManipular[", i,"], não existe no mixadorAlvo"));
        }
        #endif
    }
}
