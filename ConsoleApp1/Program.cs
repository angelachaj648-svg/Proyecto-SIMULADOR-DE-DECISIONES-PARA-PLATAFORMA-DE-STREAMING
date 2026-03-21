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
	Console.WriteLine("Menu");
	Console.WriteLine("Simulador de Streaming");
	Console.WriteLine("1.evaluar nuevo contenido");
	Console.WriteLine("2.mostrar reglas del sistema ");
	Console.WriteLine("3.mosstra estadistica de la seccion");
	Console.WriteLine("4.reiniciar estadisticas");
	Console.WriteLine("5. salir");
	Console.WriteLine("Seecione una opcion");
	opcion =int.Parse(Console.ReadLine());
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
void EvaluarContenido()
{
	Console.WriteLine("\n Evaluar contenido ");
	Console.WriteLine("tipo pelicula /serie / documental / evento)");
	string tipo =

Console.ReadLine().ToLower();
	int duracion = LeerNumero("duracion en minutos");
	Console.WriteLine("clasificacion(todo / +13 / +18)");
	string clasificacion = Console.ReadLine().ToLower();

	int hora;
	do
	{
		hora = LeerNumero("Hora programada (0-23): ");
	}
	while (hora < 0 || hora > 23);

}
Console.Write("Nivel de producción (bajo / medio / alto): ");
string produccion = Console.ReadLine().ToLower();

totalEvaluados++;

string tipo = "";
int duracion = 0;
string clasificacion = "";
int hora = 0;



bool valido = ValidarContenido(tipo, duracion, clasificacion, hora, produccion);

if (!valido)
{
	Console.WriteLine("DECISIÓN: Rechazar contenido.");
	rechazados++;
	return;
}

string impacto = CalcularImpacto(duracion, produccion, hora);

TomarDecision(impacto);

bool ValidarContenido(string tipo, int duracion, string clasificacion, int hora, string produccion)
{
	bool valido = true;
	if (clasificacion == "+13")
	{
		if (hora < 6 || hora > 22)
			valido = false;
	}
	else if (clasificacion == "+18")
	{
		if (!(hora >= 22 || hora <= 5))
			valido = false;
	}
	if (tipo == "pelicula")
	{
		if (duracion < 60 || duracion > 180)
			valido = false;
	}
	else if (tipo == "serie")
	{
		if (duracion < 20 || duracion > 90)
			valido = false;
	}
	else if (tipo == "documental")
	{
		if (duracion < 30 || duracion > 120)
			valido = false;
	}
	else if (tipo == "evento")
	{
		if (duracion < 30 || duracion > 240)
			valido = false;
	}
	else
	{
		valido = false;
	}
	if (produccion == "bajo")
	{
		if (clasificacion == "+18")
			valido = false;
	}
	return valido;
}

string CalcularImpacto(int duracion,string produccion,int hora)
{
	string impacto;


	if (produccion == "alto" || duracion > 120 || (hora >= 20 && hora <= 23))
	{
		impacto = "alto";
		impactoAlto++;
	}
	else if (produccion == "medio" || (duracion >= 60 && duracion <= 120))
	{
		impacto = "medio";
		impactoMedio++;
	}
	else
	{
		impacto = "bajo";
		impactoBajo++;
	}
	return impacto;

}

void TomarDecision(string impacto)
{
	if (impacto == "alto")
	{
		Console.WriteLine("Desicion:Enviar a Revision");
		enRevision++;
	}
	else if (impacto == "medio")
	{
		Console.WriteLine("Desicion:Publicar con ajustes");
		publicados++;
	}
}

void MotrarReglas ()
{
	Console.WriteLine("/n..Reglas del sistema..");
	Console.WriteLine("/Clasificacion y horario");
	Console.WriteLine("Todo publico:Cualquier hora");
	Console.WriteLine("+13: entre 6 y 22");
	Console.WriteLine("+18:entre 22 y 5");
	Console.WriteLine("/nDuracion por tipo");
	





























		