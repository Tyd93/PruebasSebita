using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasSebita {
    class Inferencia {
        Conocimiento pruebaRedUno;

        public Inferencia() {
            pruebaRedUno = new Conocimiento();
        }

        public void propagarSignos() {
            foreach(KeyValuePair<string, Sintomatologia> entrada in pruebaRedUno.GetSintomatologia()) {
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
            return pruebaRedUno;
        }
    }
}
