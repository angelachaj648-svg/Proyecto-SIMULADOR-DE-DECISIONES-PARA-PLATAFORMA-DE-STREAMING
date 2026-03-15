//SIMULADOR DE DECISIONES PARA PLATAFORMA DE STREAMING
int totalEvaluados = 0;
int publicados = 0;
int rechazados = 0;
int enRevision = 0;
int impactoAlto  = 0;
int impactoMedio  = 0;
int impactoBajo  = 0;
int opcion = 0;

void MostrarMenu()

{
	Console.WriteLine("Simulador de Streaming");
	Console.WriteLine("1.evaluar nuevo contenido");
	Console.WriteLine("2.mostrar reglas del sistema ");
	Console.WriteLine("3.mosstra estadistica de la seccion");
	Console.WriteLine("4.reiniciar estadisticas");
	Console.WriteLine("5. salir");
	Console.WriteLine("Seecione una opcion");
}
do
{
	MostrarMenu();
	switch (opcion)
	{
		case 1:
			Console.WriteLine("EvaluarContenido");
			break;
		case 2:
			Console.WriteLine("MostrarReglas");
			break;

		case 3:
			Console.WriteLine("MostrarEstadisticas");
			break;

		case 4:
			Console.WriteLine("ReiniciarEstadisticas");
			break;

		case 5:
			Console.WriteLine("\nPrograma finalizado.");
			break;

		default:
			Console.WriteLine("Opción inválida.");
			break;
	}
} while (opcion != 5);
int LeerNumero(string mensaje)
{
	int numero;

	Console.Write(mensaje);

	while (!int.TryParse(Console.ReadLine(), out numero))
	{
		Console.Write("Ingrese un número válido: ");
	}

	return numero;
}





