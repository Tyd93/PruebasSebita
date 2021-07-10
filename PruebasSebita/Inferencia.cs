using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasSebita {
    class Inferencia {
        Conocimiento red;
        //Lista posibles enfermedades
        List<Enfermedad> enfermedades;
        Paciente pacienteActual;

        //Constructor de prueba 
        public Inferencia() {
            red = new Conocimiento();
            enfermedades = new List<Enfermedad>();
        }

        public Inferencia(Paciente pacienteActual) {
            red = new Conocimiento();
            enfermedades = new List<Enfermedad>();
            this.pacienteActual = pacienteActual;
        }

        //propagacion sintomas
        public void Propagacion() {
            List<string> auxSintomas = pacienteActual.GetSintomas();
            //Hacer match con la red de conocimiento
            //E1 S1
            //MatchConocimiento pasarle nombresSintomas retornar Enfermedades -> almacenando 
            //preguntar si la enfermedad ya esta
        }

        public void MatchSintomas(List<string> sintomasPaciente) {
            //List<Enfermedad> enfermedadesHipotesis = new List<Enfermedad>();
            //Vamos a usar el conocimiento\
            //Tenemos nombres de sintomas.
            //Queremos obtener los sintomas(objeto) con sus enlaces
            //Para obtener las enfermedades a las que referencian
            Dictionary<string, Sintomatologia> auxSintomas = red.GetSintomatologia();
            for (int i = 0; i < sintomasPaciente.Count; i++) {
                Sintomatologia auxAuxSintoma = auxSintomas[sintomasPaciente[i]];
                //anadir enfermedades a la lista segun conexiones
                List<Enlace> enlaces = auxAuxSintoma.GetEnlaces();
                //Iterar enlaces, para construir y/o sumar a enfermedades.
                for (int j = 0; j < enlaces.Count; j++) {
                    //if para preguntar si la enfermedad no exister
                    
                    //Esto lo copia como REFERENCIA, OJO!!
                    enfermedades.Add(enlaces[j].getEnfermedad());
                    enfermedades[j].AddPertenencia(enlaces[j].getPeso());
                }
            }
        }

        public void propagarSignos() {
            foreach(KeyValuePair<string, Sintomatologia> entrada in red.GetSintomatologia()) {
                string id = entrada.Key;
                Sintomatologia auxSigno = entrada.Value;
                if (auxSigno.getPresencia()) {
                    //Aca logro la propagacion de evidencia
                    List<Enlace> auxEnlaces = auxSigno.GetEnlaces();
                    for (int i = 0; i < auxEnlaces.Count; i++) {
                        double auxPeso = auxEnlaces[i].getPeso();
                        auxEnlaces[i].getEnfermedad().AddPertenencia(auxPeso);
                    }
                }
            }
        }

        public Conocimiento GetConocimiento() {
            return red;
        }
    }
}
