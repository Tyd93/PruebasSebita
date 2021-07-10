using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasSebita {
    class Enlace {
        double pesoConexion;
        Enfermedad referencia;

        public Enlace(double peso, Enfermedad referencia) {
            this.pesoConexion = peso;
            this.referencia = referencia;
        }

        public Enfermedad getEnfermedad() {
            return referencia;
        }

        public double getPeso() {
            return pesoConexion;
        }
    }
}
