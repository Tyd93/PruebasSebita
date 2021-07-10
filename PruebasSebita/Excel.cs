using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SpreadsheetLight;

/**
 * Clase encargada de la carga y procesamiento del archivo excel
 * 
 */
namespace PruebasSebita {
    class Excel {
        SLDocument archivoSLD;
        
        public Excel() {
            //rutaPrueba = @"C:\datos_prueba1.xlsx";
            System.Reflection.Assembly appdb = System.Reflection.Assembly.GetExecutingAssembly();
            Stream stream = appdb.GetManifestResourceStream("PruebasSebita.data.datosDrRomero.xlsx");
            archivoSLD = new SLDocument(stream);
        }

        public string LeerCeldaString(int fila, int columna) {
            return archivoSLD.GetCellValueAsString(fila,columna);
        }

        public double LeerCeldaDouble(int fila, int columna) {
            return archivoSLD.GetCellValueAsDouble(fila, columna);
        }

        public List<string> LeerFilaString(int fila, int columna) {
            List<string> listaFila = new List<string>();
            while (!string.IsNullOrEmpty(archivoSLD.GetCellValueAsString(fila, columna) )) {
                listaFila.Add(LeerCeldaString(fila,columna));
                columna++;
            }
            //prueba
            //foreach (var item in listaFila) {
            //    Console.WriteLine(item);
            //};
            return listaFila;
        }

        public List<string> LeerColumnaString(int fila, int columna) {
            List<string> listaColumna = new List<string>();
            while (!string.IsNullOrEmpty(archivoSLD.GetCellValueAsString(fila, columna))) {
                listaColumna.Add(LeerCeldaString(fila, columna));
                fila++;
            }
            return listaColumna;
        }
        
    }
}
