using System;

namespace PruebasSebita {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            //PruebaRed redPrueba1 = new PruebaRed();
            //redPrueba1.imprimirEnfermedades();
            Paciente paciente = new Paciente();
            paciente.SetSintomas("Adinamia");
            paciente.SetSintomas("Cefalea");
            paciente.SetSintomas("Disnea");

            Inferencia inferencia = new Inferencia(paciente);
            inferencia.GetConocimiento().imprimirEnfermedades();
            Console.WriteLine("\n\n");
            //inferencia.propagarSignos();
            inferencia.Propagacion();
            Console.WriteLine("\n\n");
            //inferencia.GetConocimiento().imprimirEnfermedades();
            Console.WriteLine("\n\n");
            inferencia.ImprimirEnfermedades();
            //Console.WriteLine(1!=0.0);
        }
    }
}
