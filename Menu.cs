using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1
{
    internal class Menu
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void MostrarMenúPrincipal()
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1- Agregar Empleado");
            Console.WriteLine("2- Consultar Empleado");
            Console.WriteLine("3- Modificar Empleado");
            Console.WriteLine("4- Borrar Empleado");
            Console.WriteLine("5- Inicializar Arreglos");
            Console.WriteLine("6- Reportes");
            Console.WriteLine("7- Salir");
        }
        public void Ejecutar()
        {
            bool salir = false;

            while (!salir)
            {
                MostrarMenúPrincipal();
                Console.Write("Seleccione una opción: ");
                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            AgregarEmpleado();
                            break;
                        case 2:
                            Console.Write("Ingrese la cédula: ");
                            string cedulaConsulta = Console.ReadLine();
                            ConsultarEmpleado(cedulaConsulta);
                            break;
                        case 3:
                            Console.Write("Ingrese la cédula del empleado a modificar: ");
                            string cedulaModificacion = Console.ReadLine();
                            ModificarEmpleado(cedulaModificacion);
                            break;
                        case 4:
                            Console.Write("Ingrese la cédula del empleado a borrar: ");
                            string cedulaBorrado = Console.ReadLine();
                            BorrarEmpleado(cedulaBorrado);
                            break;
                        case 5:
                            InicializarArreglos();
                            break;
                        case 6:
                            MostrarMenúReportes();
                            break;
                        case 7:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida, ingrese un número válido");
                }
            }
        }
        public void AgregarEmpleado()
        {
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la dirección del empleado: ");
            string dirección = Console.ReadLine();
            Console.Write("Ingrese el teléfono del empleado: ");
            string teléfono = Console.ReadLine();
            Console.Write("Ingrese el salario del empleado: ");
            decimal salario;
            if (decimal.TryParse(Console.ReadLine(), out salario))
            {
                Empleado empleado = new Empleado(cedula, nombre, dirección, teléfono, salario);
                empleados.Add(empleado);
                Console.WriteLine("Empleado agregado con éxito.");
            }
            else
            {
                Console.WriteLine("Salario no válido, ingrese un valor numérico.");
            }
        }

        public void ConsultarEmpleado(string cedula)
        {
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine("Información del empleado:");
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario:C}");
            }
            else
            {
                Console.WriteLine("Empleado no existe");
            }
        }

        public void ModificarEmpleado(string cedula)
        {
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine("Información actual del empleado:");
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario:C}");

                Console.WriteLine("Ingrese los nuevos datos del empleado:");
                Console.Write("Nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Salario: ");
                decimal salario;
                if (decimal.TryParse(Console.ReadLine(), out salario))
                {
                    empleado.Salario = salario;
                    Console.WriteLine("Empleado modificado con éxito");
                }
                else
                {
                    Console.WriteLine("Salario no válido, no fue posible modificar el empleado");
                }
            }
            else
            {
                Console.WriteLine("Empleado no encontrado, no fue posible realizar la modificación");
            }
        }

        public void BorrarEmpleado(string cedula)
        {
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("Empleado eliminado con éxito");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado, no fue posible realizar el borrado");
            }
        }
        public void InicializarArreglos()
        {
            empleados.Clear();
            Console.WriteLine("Arreglos correctamente inicializados");
        }

        public void MostrarMenúReportes()
        {
            Console.WriteLine("Menú de Reportes");
            Console.WriteLine("1- Consultar empleado con número de cédula");
            Console.WriteLine("2- Listar todos los empleados ordenados por nombre");
            Console.WriteLine("3- Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("4- Calcular y mostrar el salario más alto y el más bajo");
            Console.WriteLine("5- Volver al menú principal");
            int opcionReporte;
            if (int.TryParse(Console.ReadLine(), out opcionReporte))
            {
                switch (opcionReporte)
                {
                    case 1:
                        Console.Write("Ingrese la cédula del empleado: ");
                        string cedulaConsulta = Console.ReadLine();
                        ConsultarEmpleado(cedulaConsulta);
                        break;
                    case 2:
                        ListarEmpleadosOrdenadosPorNombre();
                        break;
                    case 3:
                        CalcularPromedioDeSalarios();
                        break;
                    case 4:
                        CalcularSalarioMásAltoYBajo();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Opción no válido");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida, favor ingrese un número válido");
            }
        }
        public void ListarEmpleadosOrdenadosPorNombre()
        {
            var empleadosOrdenados = empleados.OrderBy(e => e.Nombre);
            Console.WriteLine("Empleados ordenados por nombre:");
            foreach (var empleado in empleadosOrdenados)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}");
            }
        }

        public void CalcularPromedioDeSalarios()
        {
            if (empleados.Count > 0)
            {
                decimal promedioSalarios = empleados.Average(e => e.Salario);
                Console.WriteLine($"Promedio de salarios: {promedioSalarios:C}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados para calcular el promedio de salarios");
            }
        }

        public void CalcularSalarioMásAltoYBajo()
        {
            if (empleados.Count > 0)
            {
                decimal salarioMásAlto = empleados.Max(e => e.Salario);
                decimal salarioMásBajo = empleados.Min(e => e.Salario);
                Console.WriteLine($"Salario más alto: {salarioMásAlto:C}");
                Console.WriteLine($"Salario más bajo: {salarioMásBajo:C}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados para calcular los salarios más alto y más bajo");
            }
        }
    }
}

