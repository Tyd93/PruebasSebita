using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace PruebasSebita{

    public class Paciente {
        private string nombre;
        private string rut;
        private string edad;
        private string sexo;
        private List<string> sintomas;
        private List<string> signos;
        private Enfermedad enfermedad;

        public Paciente() {
            sintomas = new List<string>();
            signos = new List<string>();
            enfermedad = new Enfermedad();
        }
        public bool ValidarSexo(string sexo){
            bool resultado = Regex.IsMatch(sexo, @"\s*(F|f)(E|e)(M|m)(E|e)(N|n)(I|i)(N|n)(O|o)\s*|\s*(M|m)(A|a)(S|s)(C|c)(U|u)(L|l)(I|i)(N|n)(O|o)\s*");
            if (resultado) SetSexo(sexo);
            return resultado;
        }

        public bool ValidarEdad(string edad){
            bool resultado = Regex.IsMatch(edad, "^[1-9]{1}$|^[1-9]{1}[0-9]{1}$|^1[0-1]{1}[0-9]{1}$|^120$");
            if (resultado) SetEdad(edad);
            return resultado;
        }

        public bool ValidarRut(string rut){
            rut = rut.Replace(".", "").ToUpper();
            Regex expression = new Regex("^([0-9]{8}-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expression.IsMatch(rut)){
                Console.WriteLine("Error, no corresponde a un rut");
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0]))){
                return false;
            }
            SetRut(rut);
            return true;
        }

        public static string Digito(int rut){
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0){
                multiplicador++;
                if (multiplicador == 8) {
                    multiplicador = 2;
                }    
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11){
                return "0";
            }
            else if (suma == 10){
                return "K";
            }
            else{
                return suma.ToString();
            }
        }

        public bool ValidarNombre(string nombre){
            bool resultado = Regex.IsMatch(nombre, @"^([A-Z]|[a-z]\s?)+$");
            if (resultado) SetNombre(nombre);
            return resultado;
        }

        private void SetEdad(string edad){
            this.edad = edad;
        }

        public string GetEdad() {
            return this.edad;
        }
        private void SetRut(string rut){
            this.rut = rut;
        }

        public string GetRut() {
            return this.rut;
        }
        private void SetNombre(string nombre) {
            this.nombre = nombre;
        }

        public string GetNombre() {
            return this.nombre;
        }
        private void SetSexo(string sexo){
            this.sexo = sexo;
        }

        public string GetSexo() {
            return this.sexo;
        }
        public string EnfermedadToString(){
            return "\nLa enfermedad del paciente "+ this.nombre + " es " + this.enfermedad.GetNombre() + " "+ "this.enfermedad.GetEtiqueta()" + " con una pertenencia del " + this.enfermedad.GetPertenencia();
        }
       
      
        public void SetSintomas(string sintomas){
            this.sintomas.Add(sintomas);
        }

        public void SetSignos(string signos){
            //esto es una prueba de sincronizaciin, no es dificil
            this.signos.Add(signos);
        }
        
        public void SetEnfermedad(string nombre, float posibilidad){
            // this.enfermedad = new Enfermedad(nombre);
            this.enfermedad.SetNombre(nombre);
            this.enfermedad.SetPertenencia(posibilidad);
        }
        

        public List<string> GetDatos(){
            List<string> retornoLista = new List<string>();
            retornoLista.Add(this.nombre);
            retornoLista.Add(this.rut);
            retornoLista.Add(this.edad.ToString());
            retornoLista.Add(this.sexo);
            return retornoLista;
        }

        public List<string> GetSignos(){
            return signos;
        }

        public List<string> GetSintomas(){
            return sintomas;
        }

    }

}
