using UnityEngine;

public class Rect_Transform_Segue_Apontador : MonoBehaviour {
    public RectTransform rectTransform;
    public bool usarTouch;
    public bool alinharComX, alinharComY;
    public float limitePositivoX, limiteNegativoX,
                 limitePositivoY, limiteNegativoY;
    int toque_indice;

    void Update() {
        Seguir_Mouse();
    }

    public void Reconhecer_Indice_do_Toque() {
        Touch[] toques = Input.touches;
        for (int i = 0; i < toques.Length; i++) {
            float toque_x = toques[i].position.x / Camera.main.pixelWidth;
            float toque_y = toques[i].position.y / Camera.main.pixelHeight;

            if (alinharComX ? (toque_x > limiteNegativoX && toque_x < limitePositivoX) : true
            && alinharComY ? (toque_y > limiteNegativoY && toque_y < limitePositivoY) : true) {
                toque_indice = i;
                break;
            }
        }
    }

    void Seguir_Mouse() {
        float apontador_x = 0f;
        float apontador_y = 0f;

        if (!usarTouch) {
            apontador_x = Input.mousePosition.x / Camera.main.pixelWidth;
            apontador_y = Input.mousePosition.y / Camera.main.pixelHeight;
        } else {
            Touch[] toques = Input.touches;
            if (toque_indice < 0 || toques.Length - 1 > toque_indice) {
                Debug.LogWarning("Indíce inválido, tenha certeza que executar o Reconhecer_Indice_do_Toque antes");
                return;
            }
            apontador_x = toques[toque_indice].position.x / Camera.main.pixelWidth;
            apontador_y = toques[toque_indice].position.y / Camera.main.pixelHeight;
        }

        float pos_x;
        if (alinharComX) {
            pos_x = apontador_x > limitePositivoX
                        ? limitePositivoX
                        : (apontador_x < limiteNegativoX
                            ? limiteNegativoX
                            : apontador_x);
        } else
            pos_x = rectTransform.position.x / Camera.main.pixelWidth;

        float pos_y;
        if (alinharComY) {
            pos_y = apontador_y > limitePositivoY
                        ? limitePositivoY
                        : (apontador_y < limiteNegativoY
                            ? limiteNegativoY
                            : apontador_y);
        } else
            pos_y = rectTransform.position.y / Camera.main.pixelHeight;

        Vector3 new_pos = new Vector3(pos_x * (float)Camera.main.pixelWidth, pos_y * (float)Camera.main.pixelHeight, rectTransform.position.z);
        rectTransform.position = new_pos;
    }

    public void Definir_Rect_Transform_Por_Nome (string nome) {
        rectTransform = GameObject.Find(nome).GetComponent<RectTransform>();
    }
    public void Definir_Rect_Transform_Por_Etiqueta (string nome) {
        rectTransform = GameObject.FindWithTag(nome).GetComponent<RectTransform>();
    }
    public void Definir_Rect_Transform(RectTransform def) {
        rectTransform = def;
    }
    public void Definir_Nova_Posicao(Vector3 nova_pos) {
        rectTransform.position = nova_pos;
    }
    public void Definir_Nova_Posicao(float nova_pos_x, float nova_pos_y, float nova_pos_z) {
        rectTransform.position = new Vector3(nova_pos_x, nova_pos_y, nova_pos_z);
    }
    public void Definir_Nova_Posicao_Copiando(RectTransform copia) {
        rectTransform.position = copia.position;
    }
    public void Definir_Usar_Touch(bool def) {
        usarTouch = def;
    }
}
