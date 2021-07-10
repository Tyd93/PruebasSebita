﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasSebita {
    class Conocimiento {
        Dictionary<string, Enfermedad> enfermedades;
        Dictionary<string, Sintomatologia> signos;
        Excel xlsx;

        public Conocimiento() {
            enfermedades = new Dictionary<string, Enfermedad>();
            signos = new Dictionary<string, Sintomatologia>();
            xlsx = new Excel();
            inicializarEnfermedades();
            InicializarSintomatologia();
        }
        public void inicializarEnfermedades() {
            //List<string> auxVarEnfermedades = xlsx.LeerFilaString(1,4);
            List<string> auxNombreEnfermedades = xlsx.LeerFilaString(2, 4);
            for (int i = 0; i < auxNombreEnfermedades.Count; i++) {
                enfermedades.Add(auxNombreEnfermedades[i], new Enfermedad(auxNombreEnfermedades[i]));
            }
        }

        public void InicializarSintomatologia() {
            //List<string> auxVarSintomatologia = xlsx.LeerColumnaString(3, 1);
            List<string> auxTipoSintomatologia = xlsx.LeerColumnaString(3, 2);
            List<string> auxNombreSintomatologia = xlsx.LeerColumnaString(3, 3);
            for (int i = 0; i < auxNombreSintomatologia.Count; i++) {
                signos.Add(auxNombreSintomatologia[i], new Sintomatologia(auxNombreSintomatologia[i],auxTipoSintomatologia[i]));
            }
            inicializarEnlaces();
        }

        public void inicializarEnlaces() {
            //ACa se viene lo chidooooo
            //signos["S2"].anadirEnlace(4, enfermedades["E1"]);
            //Este es para poder "probar" la propagacion
            int fila = 3;
            int columna = 4;
            double valorPeso = 0;
            List<string> varSinto = new List<string>();
            List<string> varEnfe = new List<string>();
            varSinto = xlsx.LeerColumnaString(fila, 3);
            varEnfe = xlsx.LeerFilaString(2, columna);
            for (int i = 0; i < varSinto.Count; i++) {
                for (int j = 0; j < varEnfe.Count; j++) {
                    valorPeso = xlsx.LeerCeldaDouble(fila, columna);
                    if (valorPeso != 0) {
                        Console.WriteLine(valorPeso);
                        //Se cayo aca
                        signos[varSinto[i]].AddEnlaces(valorPeso, enfermedades[varEnfe[j]]);
                    }
                    columna++;
                }
                columna = 4;
                fila++;
            }
            //array[i] => valor
            //Dict[llave] => valor
            signos["Tos"].Encontrado();
            signos["Fatiga"].Encontrado();
        }

        public void imprimirEnfermedades() {
            foreach (var entry in enfermedades) {
                //System.Console.WriteLine(entry.Key + " : " + entry.Value.ToString());
                //System.Console.WriteLine(entry.Key + " : " + entry.Value.ToString());
                System.Console.WriteLine(entry.Value.ToString());

            }
        }

        public Dictionary<string, Enfermedad> GetEnfermedades() {
            return enfermedades;
        }

        public Dictionary<string,Sintomatologia> GetSintomatologia() {
            return signos;
        }
    }
}
