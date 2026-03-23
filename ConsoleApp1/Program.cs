//SIMULADOR DE DECISIONES PARA PLATAFORMA DE STREAMING


int totalEvaluados = 0;
int publicados = 0;
int rechazados = 0;
int enRevision = 0;
int impactoAlto  = 0;
int impactoMedio  = 0;
int impactoBajo  = 0;
int opcion;


string tipo = "";
int duracion = 0;
string clasificacion = "";
int hora = 0;

void MostrarMenu()

{
	Console.WriteLine("Menu");
	Console.WriteLine("Simulador de Decisiones - Plataforma de Streaming");
	Console.WriteLine("1.evaluar nuevo contenido");
	Console.WriteLine("2.mostrar reglas del sistema ");
	Console.WriteLine("3.mosstra estadistica de la seccion");
	Console.WriteLine("4.reiniciar estadisticas");
	Console.WriteLine("5. salir");
	
}
do
{
	MostrarMenu();
	opcion = LeerNumero("seleccione una opcion:");
	switch (opcion)
	{
		case 1:
			EvaluarContenido();

			break;
		case 2:
			MotrarReglas();

			break;

		case 3:
			MostarEstadisticas();


			break;

		case 4:
			ReiniciarEstadisticas();

			break;

		case 5:
			Console.WriteLine("\n Resumen final ");
			MostarEstadisticas();
			Console.WriteLine("Programa finalizado");

			break;

		default:
			Console.WriteLine("Opción inválida.Intente de Nuevo");
			break;
	}
} while (opcion != 5);
int LeerNumero(string mensaje)
{
	int numero;

	Console.Write(mensaje);

	while (!int.TryParse(Console.ReadLine(), out numero))
	{
		Console.Write(" Entrada invalida .Ingrese un número entero: ");
	}

	return numero;
}
void EvaluarContenido()
{
	Console.WriteLine("\n Evaluar contenido nuevo");
	string tipo = "";
	bool tipoValido = false;
	while (!tipoValido)
	{
		Console.WriteLine("tipo de contenido (pelicula /serie / documental / evento)");

		tipo = Console.ReadLine().ToLower();
		if (tipo == "pelicula" || tipo == "serie" || tipo == "documental" || tipo == "evento")
			tipoValido = true;
		else
			Console.WriteLine("Tipo inválido. Opciones: pelicula, serie, documental, evento.");
	}
	int duracion = LeerNumero("Duración en minutos: ");
	string clasificacion = "";
	bool clasificacionValida = false;

	while (!clasificacionValida)
	{
		Console.WriteLine("clasificacion(todo / +13 / +18)");
		clasificacion = Console.ReadLine().ToLower();
		if (clasificacion == "todo" || clasificacion == "+13" || clasificacion == "+18")
			clasificacionValida = true;
		else
			Console.WriteLine("Clasificación inválida. Opciones: todo, +13, +18.");
	}

	int hora;
	do
	{
		hora = LeerNumero("Hora programada (0-23): ");
		if (hora < 0 || hora > 23)
			Console.WriteLine("Hora fuera de rango. Ingrese un valor entre 0 y 23.");
	}
	while (hora < 0 || hora > 23);
	string produccion = "";
	bool produccionValida = false;

	while (!produccionValida)
	{
		Console.Write("Nivel de producción (bajo / medio / alto): ");
		produccion = Console.ReadLine().ToLower();
		if (produccion == "bajo" || produccion == "medio" || produccion == "alto")
			produccionValida = true;
		else
			Console.WriteLine("Nivel inválido. Opciones: bajo, medio, alto.");
	}
	totalEvaluados++;
	string razonRechazo = "";
	bool valido = ValidarContenido(tipo, duracion, clasificacion, hora, produccion, ref razonRechazo);

	if (!valido)

	{

		Console.WriteLine("\nRazón del rechazo: " + razonRechazo);
		Console.WriteLine("DECISIÓN FINAL: * RECHAZAR *");
		rechazados++;
		return;
	}
	string impacto = CalcularImpacto(duracion, produccion, hora);
	Console.WriteLine("Nivel de impacto calculado: " + impacto.ToLower());
}
bool ValidarContenido(string tipo, int duracion, string clasificacion, int hora, string produccion ,ref string razon)

{
	
	if (clasificacion == "+13")
		

	{
		if (hora < 6 || hora > 22)
		{
			razon = "Contenido +13 solo puede programarse entre las 6 y las 22 horas. Hora ingresada: " + hora;
			return false;
		}
	}
	else if (clasificacion == "+18")
	{
		if (hora > 5 && hora < 22)
		{
			razon = "Contenido +18 solo puede programarse entre las 22 y las 5 horas. Hora ingresada: " + hora;
			return false;


		}
	}
	if (tipo == "pelicula")
	{
		if (duracion < 60 || duracion > 180)
		{
			razon = "Película debe durar entre 60 y 180 minutos. Duración ingresada: " + duracion;
			return false;
		}
	}
	
	else if (tipo == "serie")
	{
		if (duracion < 20 || duracion > 90)
		{
			razon = "Serie debe durar entre 20 y 90 minutos. Duración ingresada: " + duracion;
			return false;
		}
	}
	
	else if (tipo == "documental")
	{
		if (duracion < 30 || duracion > 120)
		{
			razon = "Documental debe durar entre 30 y 120 minutos. Duración ingresada: " + duracion;
			return false;
		}
	}

	else if (tipo == "evento")
	{
		if (duracion < 30 || duracion > 240)
		{
			razon = "Evento en vivo debe durar entre 30 y 240 minutos. Duración ingresada: " + duracion;
			return false;
		}
	}

	if (produccion == "bajo" && clasificacion == "+18")
	{
		razon = "Producción baja solo es válida para clasificación 'todo público' o '+13', no para '+18'.";
		return false;

	}
	return true;
		
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

void TomarDecision(string impacto, string tipo, int duracion, int hora)
{

	{
		if (impacto == "alto")
		{
			Console.WriteLine("Razón: El contenido tiene impacto Alto (producción alta, duración >120 min, o horario 20-23h).");
			Console.WriteLine("DECISIÓN FINAL: * ENVIAR A REVISIÓN *");
			enRevision++;
		}
		else if (impacto == "medio")
		{
			Console.WriteLine("Razón: El contenido cumple todas las reglas y tiene impacto Medio.");
			Console.WriteLine("DECISIÓN FINAL: * PUBLICAR *");
			publicados++;
		}
		else
		{
			Console.WriteLine("Razón: El contenido cumple todas las reglas y tiene impacto Bajo.");
			Console.WriteLine("DECISIÓN FINAL: * PUBLICAR *");
			publicados++;
		}
	}

}

	void MotrarReglas()
	{
		Console.WriteLine("/n..Reglas del sistema..");
		Console.WriteLine("/Clasificacion y horario");
		Console.WriteLine("Todo publico:Cualquier hora");
		Console.WriteLine("+13: entre 6 y 22");
		Console.WriteLine("+18:entre 22 y 5");
		Console.WriteLine("[Duración válida por tipo de contenido]");
		for (int i = 1; i <= 4; i++)
		{
			if (i == 1)
				Console.WriteLine("Pelicula: 60-180 minutos");
			else if (i == 2)
				Console.WriteLine("Serie: 20-90");
			else if (i == 3)
				Console.WriteLine("Documental: 30-120 minutos");
			else
				Console.WriteLine("Evento en vivo: 30-240 minutos");
		}
		Console.WriteLine("\n[Nivel de producción]");
		Console.WriteLine("  Bajo  : solo válido para 'todo público' o '+13'");
		Console.WriteLine("  Medio : válido para cualquier clasificación");
		Console.WriteLine("  Alto  : válido para cualquier clasificación");

		Console.WriteLine("\n[Clasificación de impacto]");
		Console.WriteLine("  Alto  : producción alta, duración >120 min, o programado entre 20-23h");
		Console.WriteLine("  Medio : producción media, o duración entre 60-120 min");
		Console.WriteLine("  Bajo  : producción baja y duración <60 min");

		Console.WriteLine("\n[Decisión final]");
		Console.WriteLine("  Publicar        : impacto Bajo o Medio");
		Console.WriteLine("  Enviar revisión : impacto Alto");
		Console.WriteLine("  Rechazar        : incumple alguna regla obligatoria");
	}


void  MostarEstadisticas()
{
	Console.WriteLine("/nEstadisticas");
	Console.WriteLine("Total evaluados: " + totalEvaluados);
	Console.WriteLine("Publicados:" + publicados);
	Console.WriteLine("Rechazados:" + rechazados);
	Console.WriteLine("En revicion: " + enRevision);

	string impactoPredominante = "Bajo";
	if (impactoAlto >= impactoMedio && impactoAlto >= impactoBajo)
		impactoPredominante = "Alto";
	else if (impactoMedio >= impactoAlto && impactoMedio >=  impactoBajo)
		impactoPredominante = "Medio";

	Console.WriteLine("Impacto predominante:" + impactoPredominante);

	if (totalEvaluados > 0)
		{
			double porcentaje = (double)publicados / totalEvaluados * 100;
			Console.WriteLine("Porcentaje de aprobación: {porcentaje:F1}%");
		}
		else
		{
			Console.WriteLine("Porcentaje de aprobación: 0%");
		}

}

void ReiniciarEstadisticas()
{
	totalEvaluados = 0;
	publicados = 0;
	rechazados = 0;
	enRevision = 0;

	impactoAlto = 0;
	impactoMedio = 0;
	impactoBajo = 0;

	Console.WriteLine("Estadisticas reiniciando ");
}

	





			
	





























		