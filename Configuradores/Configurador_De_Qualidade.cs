using UnityEngine;
using Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao;

namespace Componentes_Para_Unity.Configuradores {
    public class Configurador_De_Qualidade : MonoBehaviour {
        public Evento_Int aoMudarQualidade;

        public void Definir_Qualidade(int def) {
            QualitySettings.SetQualityLevel(def);
            aoMudarQualidade.Invoke(QualitySettings.GetQualityLevel());
        }
        public void Incrementar_Qualidade(bool applicarMudancasPesadas) {
            QualitySettings.IncreaseLevel(applicarMudancasPesadas);
            aoMudarQualidade.Invoke(QualitySettings.GetQualityLevel());
        }
        public void Decrementar_Qualidade(bool applicarMudancasPesadas) {
            QualitySettings.DecreaseLevel(applicarMudancasPesadas);
            aoMudarQualidade.Invoke(QualitySettings.GetQualityLevel());
        }
    }
}
