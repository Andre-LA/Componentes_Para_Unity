using UnityEngine;

public class Girar : MonoBehaviour {
	[Tooltip("Transform a sofrer rotação")]
	public Transform alvo;
	[Tooltip("Velocidade sobre do eixo")]
	public float velocidadeX, velocidadeY, velocidadeZ;
	[Tooltip("Relatividade, se deve girar nos eixos locais ou globais")]
	public Space relativoAo;
	[Tooltip("Se verdadeiro, a escala de tempo não interferirá na velocidade")]
	public bool independenteDeTimeScale;

	void Update() {
		Aplicar_Giro();
	}
	public void Aplicar_Giro() {
		float dt = independenteDeTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;
		alvo.Rotate(velocidadeX * dt, velocidadeY * dt, velocidadeZ * dt, relativoAo);
	}

	public void Definir_Rotacao_X(float def) {
		Vector3 rot = alvo.eulerAngles;
		rot.x = def;
		alvo.localRotation = Quaternion.Euler(rot);
	}
	public void Definir_Rotacao_Y(float def) {
		Vector3 rot = alvo.eulerAngles;
		rot.y = def;
		alvo.localRotation = Quaternion.Euler(rot);
	}
	public void Definir_Rotacao_Z(float def) {
		Vector3 rot = alvo.eulerAngles;
		rot.z = def;
		alvo.localRotation = Quaternion.Euler(rot);
	}

    public void Definir_Velocidade_X(float def) {
        velocidadeX = def;
    }
    public void Definir_Velocidade_Y(float def) {
        velocidadeY = def;
    }
    public void Definir_Velocidade_Z(float def) {
        velocidadeZ = def;
    }

    public void Incrementar_Velocidade_X(float inc) {
		velocidadeX += inc;
	}
	public void Incrementar_Velocidade_Y(float inc) {
		velocidadeY += inc;
	}
	public void Incrementar_Velocidade_Z(float inc) {
		velocidadeZ += inc;
	}

    public void Multiplicar_Velocidade_X(float mul) {
		velocidadeX *= mul;
	}
	public void Multiplicar_Velocidade_Y(float mul) {
		velocidadeY *= mul;
	}
	public void Multiplicar_Velocidade_Z(float mul) {
		velocidadeZ *= mul;
	}

	public void Definir_Alvo_Por_Nome(string nome) {
		alvo = GameObject.Find(nome).transform;
	}
	public void Definir_Alvo_Por_Etiqueta(string etiqueta) {
		alvo = GameObject.FindWithTag(etiqueta).transform;
	}
}
