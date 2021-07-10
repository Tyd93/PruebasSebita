using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasSebita {
    class Sintomatologia {
        string nombre;
        string tipo;
        bool presencia;
        List<Enlace> conexiones;

        public Sintomatologia() {
            this.conexiones = new List<Enlace>();
            this.presencia = false;
        }
        public Sintomatologia(string nombre, string tipo) {
            this.nombre = nombre;
            this.tipo = tipo;
            this.presencia = false;
            this.conexiones = new List<Enlace>();
        }

        public void Encontrado() {
            this.presencia = true;
        }

        public void AddEnlaces(double peso, Enfermedad enfermedad) {
            conexiones.Add(new Enlace(peso, enfermedad));
        }

        public bool getPresencia() {
            return this.presencia;
        }

        public List<Enlace> GetEnlaces() {
            return conexiones;
        }
    }
}
