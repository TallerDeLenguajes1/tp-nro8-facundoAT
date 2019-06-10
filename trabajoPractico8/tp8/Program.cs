using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tp8
{

    public enum cargoEnum { auxiliar = 1, administrativo = 2, ingeniero = 3, especialista = 4, investigador = 5 };
    public enum estadoCivilEnum { casado, soltero }
    public enum generoEnum { femenino, masculino }
    class Program
    {
        static void Main(string[] args)

        {
            List<empleado> listaEmpl = new List<empleado>();
            empleado empl;

            string[] infJunta;
            string[] infSeparada;
            string rutaDelDocumento = @"C:\repositorios\repositorio8\tp-nro8-facundoAT\trabajoPractico8\tp8\empleados2.csv";
            infJunta = File.ReadAllLines(rutaDelDocumento);
            //Console.WriteLine("Arreglo sin separar caracteristicas de empleados");
            //foreach (var inf in infJunta)
            //{
            //    Console.WriteLine(inf);
            //}

            //Console.WriteLine("Arreglo con caracteristicas de empleado");
            //foreach (var item in infSeparada)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("--------------------Empleados en mi archivo------------------------");

            //CARGO MI LISTA CON LOS EMPLEADOS DEL ARCHIVO
            for (int i = 0; i < infJunta.Count(); i++)
            {
                infSeparada = infJunta[i].Split(';');
                empl = empledosParaArreglo(infSeparada);
                listaEmpl.Add(empl);
            }
            mostrar(listaEmpl);
            Console.WriteLine("-------------------------------------------------------------------");
            //AGREGO LOS EMPLEDOS DE MI LISTA AL ARCHIVO
            for (int i = 0; i < listaEmpl.Count(); i++)
            {
                escribirArchivo(rutaDelDocumento, listaEmpl[i]);
            }
            BackUpEmpleados();
            Console.ReadKey();

        } 
        //             FUNCIONES FUERA DEL MAIN
        public static int cantidadEmpleados(List<empleado> empresa) => empresa.Count();
        public static double montoTotal(List<empleado> empresa)
        {
            double total = 0;
            for (int i = 0; i < empresa.Count(); i++)
            {
                total = empresa[i].salario() + total;
            }
            return (total);
        }
        public static void mostrar(List<empleado> empresa)
        {
            for (int i = 0; i < empresa.Count(); i++)
            {
                Console.WriteLine("----- Empleado {0} -----", i + 1);
                empresa[i].mostrar();
            }
        }
        public static empleado cargoEmpleados()
        {
            string[] nombresArreglo = { "facu", "martin", "andres", "mario", "juan" };
            string[] apellidosArreglo = { "Toconás", "Gonzales", "Torres", "Alvarez", "Riquelme" };


            Random rand = new Random(); //    preguntar porque es asi
            int aleatorio = rand.Next(5);

            string nombreAleatorio = nombresArreglo[aleatorio];

            aleatorio = rand.Next(5);
            string apellidoAleatorio = apellidosArreglo[aleatorio];

            int anioAleatorio = rand.Next(1930, 2000);
            int mesAleatorio = rand.Next(1, 12);
            int diaAleatorio = rand.Next(1, 29);
            DateTime nacimientoAleatorio = new DateTime(anioAleatorio, mesAleatorio, diaAleatorio);

            anioAleatorio = rand.Next(2000, 2018);
            mesAleatorio = rand.Next(1, 12);
            diaAleatorio = rand.Next(1, 29);
            DateTime ingresoAleatorio = new DateTime(anioAleatorio, mesAleatorio, diaAleatorio);
            //Console.WriteLine(nombreAleatorio);
            //Console.WriteLine(apellidoAleatorio);
            estadoCivilEnum estadoCivilAleatorio = (estadoCivilEnum)rand.Next(1, 2);
            generoEnum generoAleatorio = (generoEnum)rand.Next(1, 2);

            double basicoAleatorio = (double)rand.Next(10000, 20000);
            cargoEnum cargoAleatorio = (cargoEnum)rand.Next(1, 5);
            int hijosAleatorio = (int)rand.Next(1, 4);
            empleado empl = new empleado(nombreAleatorio, apellidoAleatorio, nacimientoAleatorio, estadoCivilAleatorio, generoAleatorio, ingresoAleatorio, basicoAleatorio, cargoAleatorio, hijosAleatorio);
            //empl.mostrar();


            return empl;
        }
        public static empleado empledosParaArreglo(string[] infSeparada)
        {
            // antes de separar la funcion
            string nombre = infSeparada[0];
            string apellido = infSeparada[1];
            //fecha de nacimiento
            string[] fecha = infSeparada[2].Split('/');
            int anio = int.Parse(fecha[2]);
            int mes = int.Parse(fecha[1]);
            int dia = int.Parse(fecha[0]);
            DateTime fechaNac = new DateTime(anio, mes, dia);
            //estado civil
            //estadoCivilEnum estadoC = (estadoCivilEnum)int.Parse(infSeparada[3]); no funciono
            estadoCivilEnum estCivil;
            if (infSeparada[3] == "casado")
            {
                estCivil = (estadoCivilEnum)0;
            }
            else
            {
                estCivil = (estadoCivilEnum)1;
                //if (infSeparada[3]=="soltero")
                //{
                //    estCivil = (estadoCivilEnum)1;
                //}
            }

            //genero
            generoEnum genero;
            if (infSeparada[4] == "femenino")
            {
                genero = (generoEnum)0;
            }
            else
            {
                genero = (generoEnum)1;
                //if (infSeparada[4]=="masculino")
                //{
                //    estCivil = (estadoCivilEnum)1;
                //}
            }

            //fecha de ingreso
            string[] fecha2 = infSeparada[5].Split('/');
            int anio1 = int.Parse(fecha2[2]);
            int mes1 = int.Parse(fecha2[1]);
            int dia1 = int.Parse(fecha2[0]);
            DateTime fechaIngreso = new DateTime(anio1, mes1, dia1);
            // sueldo
            double sueldo = int.Parse(infSeparada[6]);

            // cargo  { auxiliar = 1, administrativo = 2, ingeniero = 3, especialista = 4, investigador = 5 };
            string carg = infSeparada[7];
            cargoEnum cargo;
            if (carg == "auxiliar")
            {
                cargo = (cargoEnum)1;
            }
            else
            {
                if (carg == "administrativo")
                {
                    cargo = (cargoEnum)2;
                }
                else
                {
                    if (carg == "ingeniero")
                    {
                        cargo = (cargoEnum)3;
                    }
                    else
                    {
                        if (carg == "especialista")
                        {
                            cargo = (cargoEnum)4;
                        }
                        else
                        {
                            cargo = (cargoEnum)5; // investigador
                        }

                    }

                }
            }
            //hijos
            int hijos;
            hijos = int.Parse(infSeparada[8]);

            ////// MOSTRANDO
            //Console.WriteLine("Nombre: " + nombre);
            //Console.WriteLine("Apellido: " + apellido);
            //Console.WriteLine("fecha: {0}/{1}/{2}", dia, mes, anio);
            //Console.WriteLine("Estado Civil: " + estCivil);
            //Console.WriteLine("Estado Civil: " + genero);

            ///
            empleado empl = new empleado(nombre, apellido, fechaNac, estCivil, genero, fechaIngreso, sueldo, cargo, hijos);
            //empl.mostrar();
            return (empl);
        }
        public static void escribirArchivo(string ruta, empleado empl)
        {
            string fecha;
            using (StreamWriter file = new StreamWriter(ruta, true))
            {
                file.Write(empl.nombre + ";");
                file.Write(empl.apellido + ";");
                fecha = Convert.ToDateTime(empl.fechaNacimiento).ToString("dd/MM/yyyy");
                file.Write(fecha + ";");
                file.Write(empl.estadoCivil + ";");
                file.Write(empl.genero + ";");
                fecha = Convert.ToDateTime(empl.fechaDeIngreso).ToString("dd/MM/yyyy");
                file.Write(fecha + ";");
                file.Write(empl.sueldoBasico + ";");
                file.Write(empl.cargo + ";");
                file.Write(empl.hijos);
                file.Write("\n");
                file.Close();
            }
        }
        public static void BackUpEmpleados()
        {
            string[] discos;
            discos = Directory.GetLogicalDrives();
            int x = 1;

            Console.WriteLine("Seleccione la unidad donde quiere hacer el BackUp y crear la carpeta BackUpAgenda, si no existe.(1 o 2 )");
            int opc = int.Parse(Console.ReadLine());
            foreach (var item in discos)
            {
                Console.WriteLine("{0}: {1}", x++, item);
            }
            //Directory.CreateDirectory(@"C:\trabajos2\trabajos3\trabajos4\trabajos5\");
            if (!Directory.Exists(@"C:\BackUpAgenda"))
            {
                Directory.CreateDirectory(@"C:\BackUpAgenda");
                Console.WriteLine("Carpeta BackUpAgenda creada.");
            }
            else
            {
                Console.WriteLine("La carpeta BackUpAgenda ya existe");
            }
            string extension = ".bk";
            string rutaArchivo = @"C:\repositorios\repositorio8\tp-nro8-facundoAT\trabajoPractico8\tp8\empleados2.csv";
            string rutaDeCopia = Path.Combine(@"C:\BackUpAgenda", Path.ChangeExtension("empleados2.csv", extension));//(carpeta nueva)+(archivoCopia)

            //string cambio=Path.ChangeExtension("empleados2.csv", extension);
            //Console.WriteLine(cambio);
            if (!File.Exists(rutaDeCopia))
            {
                //Console.WriteLine(rutaDeCopia);
                File.Copy(rutaArchivo, rutaDeCopia, false); //false no permite sobreescribir el archivo
                Console.WriteLine("Copia realizada");
            }
            else
            {
                Console.WriteLine("Ya existe una copia del archivo en esa Carpeta");
            }
            //Directory.Delete(@"C:\trabajos");
            Console.ReadKey();
        }
    }

}
