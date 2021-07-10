using System;

namespace PruebasSebita {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            //PruebaRed redPrueba1 = new PruebaRed();
            //redPrueba1.imprimirEnfermedades();
            Inferencia inferencia = new Inferencia();
            inferencia.GetConocimiento().imprimirEnfermedades();
            inferencia.propagarSignos();
            inferencia.GetConocimiento().imprimirEnfermedades();
            //Console.WriteLine(1!=0.0);
        }
    }
}
