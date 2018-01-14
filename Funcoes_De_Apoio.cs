namespace Componentes_Para_Unity {
    public class Funcoes_De_Apoio {
        public static int Incrementa_Indice(int inicial, int incremento, int limite, bool ciclico) {
            int novo_indice = inicial + incremento;

            if (ciclico) {
                if (novo_indice < 0)
                    novo_indice = Incrementa_Indice(limite-1, novo_indice+1, limite, true);
                else if (novo_indice >= limite)
                    novo_indice = Incrementa_Indice(0, novo_indice-limite, limite, true);
            } else
                novo_indice = UnityEngine.Mathf.Clamp(novo_indice, 0, limite-1);

            return novo_indice;
        }
    }
}
