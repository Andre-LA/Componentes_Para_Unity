using System.Collections.Generic;
using UnityEngine;
using Componentes_Para_Unity.Componentes_Especificos;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Controle_Virtual {
    public class Impor_Valor_No_Controle_Virtual : MonoBehaviour {
        public List<Controle_Virtual> controlesVirtuais;
        public string eixoParaImpor;
        bool impor = false;
        float valor_para_impor;

        public void Inserir_Controle_Virtual(Controle_Virtual novo_controle) {
            controlesVirtuais.Add(novo_controle);
        }

        public void Definir_Controles_Virtuais_Pela_Etiqueta(string etiqueta) {
            GameObject[] gbj_dos_controladores = GameObject.FindGameObjectsWithTag(etiqueta);
            print("achei " + gbj_dos_controladores.Length + " jogadores");
            for (int i = 0; i < gbj_dos_controladores.Length; i++)
                Inserir_Controle_Virtual(gbj_dos_controladores[i].GetComponent<Controle_Virtual>());
        }

        public void Impor_Valor_No_Final_Do_Quadro(float valor) {
            impor = true;
            valor_para_impor = valor;
        }

        public void Impor_Valor(float valor) {
            for (int i = 0; i < controlesVirtuais.Count; i++) {
                int indice = controlesVirtuais[i].Obter_Indice_Pelo_Nome_Do_Eixo(eixoParaImpor);
                controlesVirtuais[i].valoresFinais[indice] = valor;
            }
        }

        void Update() {
            if (impor) {
                Impor_Valor(valor_para_impor);
                impor = false;
            }
        }
    }
}
