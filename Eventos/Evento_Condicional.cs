using UnityEngine;
using UnityEngine.Events;

public class Evento_Condicional : MonoBehaviour {
	[Tooltip("o primeiro e segundo valor serão comparados através dessa condição")]
	public Condicoes condicional;
	[HideInInspector]
	public object valor1, valor2;
	[Tooltip("Como os valores deverão ser interpretados")]
	public Tipos interpretarValoresComo;

	public UnityEvent verdadeiro, falso, ambos;

	#region Comparacoes

	public void Verificar_Condicao() {
		bool verificao = false;

		switch (interpretarValoresComo) {
			case Tipos.inteiro:
				verificao = Compara_Inteiro();
			break;
			case Tipos.String:
				verificao = Compara_Strings();
			break;
			case Tipos.flutuante:
				verificao = Compara_Flutuante();
			break;
			case Tipos.duploFlutuante:
				verificao = Compara_Duplo_Flutuante();
			break;
			case Tipos.booleano:
				verificao = Compara_Booleanos();
			break;
		}

		if (verificao)
			verdadeiro.Invoke();
		else
			falso.Invoke();
		ambos.Invoke();
	}

	bool Compara_Inteiro() {
		int v1 = (int)valor1;
		int v2 = (int)valor2;

		switch (condicional) {
			case Condicoes.diferente:
				return v1 != v2;
			case Condicoes.igualA:
				return v1 == v2;
			case Condicoes.maiorOuIgualAQue:
				return v1 >= v2;
			case Condicoes.maiorQue:
				return v1 > v2;
			case Condicoes.menorOuIgualAQue:
				return v1 <= v2;
			case Condicoes.menorQue:
				return v1 < v2;
			default:
				Debug.Log("Condição de condicional não suportada");
				return false;
		}
	}

	bool Compara_Flutuante() {
		float v1 = (float)valor1;
		float v2 = (float)valor2;
		switch (condicional) {
			case Condicoes.diferente:
				return v1 != v2;
			case Condicoes.igualA:
				return v1 == v2;
			case Condicoes.maiorOuIgualAQue:
				return v1 >= v2;
			case Condicoes.maiorQue:
				return v1 > v2;
			case Condicoes.menorOuIgualAQue:
				return v1 <= v2;
			case Condicoes.menorQue:
				return v1 < v2;
			default:
				Debug.Log("Condição de condicional não suportada");
				return false;
		}
	}

	bool Compara_Strings() {
		switch (condicional) {
			case Condicoes.igualA:
				return valor1 == valor2;
			case Condicoes.diferente:
				return valor1 != valor2;
			default:
				Debug.LogError("Quando há comparação entre strings, apenas == ou != são suportados");
				return false;
		}
	}

	bool Compara_Duplo_Flutuante() {
		double v1 = (double)valor1;
		double v2 = (double)valor2;

		switch (condicional) {
			case Condicoes.diferente:
				return v1 != v2;
			case Condicoes.igualA:
				return v1 == v2;
			case Condicoes.maiorOuIgualAQue:
				return v1 >= v2;
			case Condicoes.maiorQue:
				return v1 > v2;
			case Condicoes.menorOuIgualAQue:
				return v1 <= v2;
			case Condicoes.menorQue:
				return v1 < v2;
			default:
				Debug.Log("Condição não suportada");
				return false;
		}
	}

	bool Compara_Booleanos() {
		bool v1 = (bool)valor1;
		bool v2 = (bool)valor2;

		switch (condicional) {
			case Condicoes.diferente:
				return v1 != v2;
			case Condicoes.igualA:
				return v1 == v2;
			default:
				Debug.LogError("Quando há comparação entre booleanos, apenas == ou != são suportados");
				return false;
		}
	}
	
	#endregion

	#region Definicoes dos valores 1 e 2

	public void Definir_Valor_1 (string valor_1) {
		valor1 = valor_1;
	}
	public void Definir_Valor_1 (int valor_1) {
		valor1 = valor_1;
	}
	public void Definir_Valor_1 (double valor_1) {
		valor1 = valor_1;
	}
	public void Definir_Valor_1 (float valor_1) {
		valor1 = valor_1;
	}
	public void Definir_Valor_1 (bool valor_1) {
		valor1 = valor_1;
	}

	public void Definir_Valor_2 (string valor_2) {
		valor2 = valor_2;
	}
	public void Definir_Valor_2 (int valor_2) {
		valor2 = valor_2;
	}
	public void Definir_Valor_2 (double valor_2) {
		valor2 = valor_2;
	}
	public void Definir_Valor_2 (float valor_2) {
		valor2 = valor_2;
	}
	public void Definir_Valor_2 (bool valor_2) {
		valor2 = valor_2;
	}

	public void Definir_Valores (string valor_1, string valor_2) {
		valor1 = valor_1;
		valor2 = valor_2;
	}
	public void Definir_Valores (int valor_1, int valor_2) {
		valor1 = valor_1;
		valor2 = valor_2;
	}
	public void Definir_Valores (double valor_1, double valor_2) {
		valor1 = valor_1;
		valor2 = valor_2;
	}
	public void Definir_Valores (float valor_1, float valor_2) {
		valor1 = valor_1;
		valor2 = valor_2;
	}
	public void Definir_Valores (bool valor_1, bool valor_2) {
		valor1 = valor_1;
		valor2 = valor_2;
	}

	#endregion

	#region Manipulacao dos valores 1 e 2

	public void Incrementar_Valor_1 (int incremento) {
		int v1 = (int)valor1 + incremento;
		valor1 = v1;
	}
	public void Incrementar_Valor_1 (float incremento) {
		float v1 = (float)valor1 + incremento;
		valor1 = v1;
	}
	public void Incrementar_Valor_1 (double incremento) {
		double v1 = (double)valor1 + incremento;
		valor1 = v1;
	}

	public void Incrementar_Valor_2 (int incremento) {
		int v2 = (int)valor2 + incremento;
		valor2 = v2;
	}
	public void Incrementar_Valor_2 (float incremento) {
		float v2 = (float)valor2 + incremento;
		valor2 = v2;
	}
	public void Incrementar_Valor_2 (double incremento) {
		double v2 = (double)valor2 + incremento;
		valor2 = v2;
	}

	public void Incrementar_Valores (int incremento) {
		int v1 = (int)valor1 + incremento;
		int v2 = (int)valor2 + incremento;
		valor1 = v1;
		valor2 = v2;
	}
	public void Incrementar_Valores (float incremento) {
		float v1 = (float)valor1 + incremento;
		float v2 = (float)valor2 + incremento;
		valor1 = v1;
		valor2 = v2;
	}
	public void Incrementar_Valores (double incremento) {
		double v1 = (double)valor1 + incremento;
		double v2 = (double)valor2 + incremento;
		valor1 = v1;
		valor2 = v2;
	}

	public void Multiplicar_Valor_1 (int multiplicador) {
		int v1 = (int)valor1 * multiplicador;
		valor1 = v1;
	}
	public void Multiplicar_Valor_1 (float multiplicador) {
		float v1 = (float)valor1 * multiplicador;
		valor1 = v1;
	}
	public void Multiplicar_Valor_1 (double multiplicador) {
		double v1 = (double)valor1 * multiplicador;
		valor1 = v1;
	}

	public void Multiplicar_Valor_2 (int multiplicador) {
		int v2 = (int)valor2 * multiplicador;
		valor2 = v2;
	}
	public void Multiplicar_Valor_2 (float multiplicador) {
		float v2 = (float)valor2 * multiplicador;
		valor2 = v2;
	}
	public void Multiplicar_Valor_2 (double multiplicador) {
		double v2 = (double)valor2 * multiplicador;
		valor2 = v2;
	}

	public void Multiplicar_Valores (int multiplicador) {
		int v1 = (int)valor1 * multiplicador;
		int v2 = (int)valor2 * multiplicador;
		valor1 = v1;
		valor2 = v2;
	}
	public void Multiplicar_Valores (float multiplicador) {
		float v1 = (float)valor1 * multiplicador;
		float v2 = (float)valor2 * multiplicador;
		valor1 = v1;
		valor2 = v2;
	}
	public void Multiplicar_Valores (double multiplicador) {
		double v1 = (double)valor1 * multiplicador;
		double v2 = (double)valor2 * multiplicador;
		valor1 = v1;
		valor2 = v2;
	}

	#endregion
}
