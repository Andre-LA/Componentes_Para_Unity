using UnityEngine;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Animator {
    public class Manipular_Parametros_Do_Animator : MonoBehaviour {
    	[Tooltip("Animador a ter seus parâmetros manipulados")]
    	public Animator animador;
    	[Tooltip("Indice do parâmetro (os parâmetros serão listados abaixo)")]
    	public int indice;
    	[Tooltip("Nome dos parâmetros a serem manipulados")]
    	public string[] parametrosParaManipular;

    	public void Definir_Indice(int i) {
    		indice = i;
    	}

    	public void Incrementa_Indice(int inc) {
    		indice += inc;

    		while (indice >= parametrosParaManipular.Length)
    			indice -= parametrosParaManipular.Length+1;

    		while (indice < 0)
    			indice += parametrosParaManipular.Length;
    	}

    	public void Definir_Parametro_Flutuante(float def) {
    		animador.SetFloat(parametrosParaManipular[indice], def);
    	}

    	public void Definir_Parametro_Inteiro(int def) {
    		animador.SetInteger(parametrosParaManipular[indice], def);
    	}

    	public void Definir_Parametro_Booleano(bool def) {
    		animador.SetBool(parametrosParaManipular[indice], def);
    	}

    	#region Definição do animador
    	public void Definir_Animador (Animator def) {
    		animador = def;
    	}

    	public void Definir_Animador_Por_Nome (string nome) {
    		animador = GameObject.Find(nome).GetComponent<Animator>();
    	}

    	public void Definir_Animador_Por_Etiqueta (string etiqueta) {
    		animador = GameObject.FindWithTag(etiqueta).GetComponent<Animator>();
    	}

    	#endregion
    }
}
