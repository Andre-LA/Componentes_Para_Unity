using System.Collections.Generic;
using UnityEngine;

namespace Componentes_Para_Unity.Componentes_Especificos {
    public class Apenas_Pode_Haver_Um : MonoBehaviour {
        static List<string>	nomes_dos_gbjs = new List<string>();
        int meu_indice = -1;

        void Awake() {
            if (Existe_Outro_Semelhante())
                Destroy(gameObject);
            else {
                nomes_dos_gbjs.Add(gameObject.name);
                meu_indice = nomes_dos_gbjs.Count - 1;
            }
        }

        bool Existe_Outro_Semelhante () {
            for (int i = 0; i < nomes_dos_gbjs.Count; i++)
                if (meu_indice != i && nomes_dos_gbjs[i] == gameObject.name)
                    return true;
            return false;
        }

        void OnDestroy() {
            if (!Existe_Outro_Semelhante()) {
                nomes_dos_gbjs.RemoveAt(meu_indice);
            }
        }
    }
}
