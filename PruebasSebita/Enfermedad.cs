using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasSebita {
    class Enfermedad {
        string nombre;
        double pertenencia;

        public Enfermedad() {
            //Vacio
            this.pertenencia = 0;
        }

        public Enfermedad(string nombre) {
            this.nombre = nombre;
            this.pertenencia = 0;
        }

        public void SetNombre(string nombre) {
            this.nombre = nombre;
        }

        public string GetNombre() {
            return nombre;
        }

        public void SetPertenencia(double peso) {
            this.pertenencia = peso;
        }

        public double GetPertenencia() {
            return pertenencia;
        }

        public void AddPertenencia(double peso) {
            this.pertenencia += peso;
        }

        public override string ToString() {
            return nombre + " " + pertenencia.ToString();
        }
    }
}
