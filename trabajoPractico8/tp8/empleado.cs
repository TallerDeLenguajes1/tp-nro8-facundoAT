using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp8
{

    class empleado
    {
        public string nombre;
        public string apellido;
        public DateTime fechaNacimiento;
        public estadoCivilEnum estadoCivil;// casado,soltero true-false
        public generoEnum genero; //femenino,masculino  true-falsa
        public DateTime fechaDeIngreso;
        public double sueldoBasico;
        public cargoEnum cargo;  //porque no puedo poner public                                
        public int hijos;//int cargo;


        //constructor
        public empleado(string _nombre, string _apellido, DateTime _fechaNacimiento, estadoCivilEnum _estadoCival, generoEnum _genero, DateTime _fechaDeIngreso, double _sueldoBasico, cargoEnum _cargo, int _hijos)
        {
            nombre = _nombre;
            apellido = _apellido;
            fechaNacimiento = _fechaNacimiento;
            estadoCivil = _estadoCival;
            genero = _genero;
            fechaDeIngreso = _fechaDeIngreso;
            sueldoBasico = _sueldoBasico;
            cargo = _cargo;
            hijos = _hijos;
        }

        public void mostrar()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Apellido: " + apellido);
            Console.WriteLine("Fecha de nacimiento:{0}-{1}-{2}", fechaNacimiento.Day, fechaNacimiento.Month, fechaNacimiento.Year);
            Console.WriteLine("Estado Civil: " + estadoCivil);
            Console.WriteLine("Genero: " + genero);
            Console.WriteLine("Fecha de ingreso a la empresa: {0}-{1}-{2}", fechaDeIngreso.Day, fechaDeIngreso.Month, fechaDeIngreso.Year);
            Console.WriteLine("Sueldo basico: " + sueldoBasico);
            Console.WriteLine("Cargo: " + cargo);
            Console.WriteLine("Hijos: "+ hijos);
        }
        public int antiguedadEmpleado() => (DateTime.Today.Year - fechaDeIngreso.Year);

        public int edadEmpleado() => (DateTime.Today.Year - fechaNacimiento.Year);

        public int jubilacion()
        {
            if (genero == generoEnum.femenino)
                return (60 - edadEmpleado());
            else
                return (65 - edadEmpleado());
        }
        public double salario()
        {
            double adicional;
            if (antiguedadEmpleado() <= 20)
            {
                adicional = (0.02 * sueldoBasico) * antiguedadEmpleado();
            }
            else
            {
                adicional = (0.25 * sueldoBasico);
            }
            if (cargo == cargoEnum.ingeniero || cargo == cargoEnum.especialista) // 3 ingeniero , 4 especialista
            {
                adicional = (adicional * 0.5) + adicional;
            }
            if (estadoCivil == estadoCivilEnum.casado && hijos > 2)
            {
                adicional = adicional + 5000;
            }
            return (adicional + sueldoBasico);

        }
    }
    //public int Suma() => (3 + 7);

}
