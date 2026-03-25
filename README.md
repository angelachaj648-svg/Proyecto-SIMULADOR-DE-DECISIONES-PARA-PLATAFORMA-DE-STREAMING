Simulador de Decisiones - Plataforma de Streaming:
1...Descripción del sistema:
Este programa simula cómo una plataforma de streaming decide si un contenido se publica, se rechaza o se envía a revisión.
El usuario puede ingresar información sobre un contenido como:
Tipo (película, serie, documental o evento)
Duración
Clasificación (+13, +18, todo público)
Hora de transmisión
Nivel de producción
Con base en estos datos, el sistema:
Verifica si cumple las reglas
Calcula el impacto del contenido
Toma una decisión final
El programa funciona asi y esto se vera
Muestra un menú con opciones:
1.Evaluar contenido
2.Mostrar reglas
3.Ver estadísticas
4.Reiniciar estadísticas
5.Salir
El usuario selecciona una opción y el sistema responde según lo seleccionado.
2...Instrucciones para ejecutar el programa:
Abrir el proyecto en Visual Studio
Ejecutar el programa (F5 o botón "Iniciar")
Elegir una opción del menú
Ingresar los datos que se solicitan
Ver el resultado final en pantalla
Lógica del sistema :
Validación
El sistema revisa que:
La clasificación coincida con la hora
La duración sea correcta según el tipo
La producción sea válida para el tipo de contenido
Si algo no cumple →  Se rechaza
En el cálculo de impacto
El contenido puede ser:
Alto → producción alta, duración larga o horario nocturno
Medio → condiciones intermedias
Bajo → contenido 
Decisión final;
Impacto alto → Enviar a revisión
Impacto medio o bajo → Publicar
Si no cumple reglas → Rechazar
Estadísticas;
El sistema guarda los datos de:
Total de contenidos evaluados
Cuántos fueron publicados
Cuántos fueron rechazados
Cuántos están en revisión
Impacto más frecuente
Porcentaje de aprobación
3...Explicación del proyecto
Este proyecto fue desarrollado para que asimilemos como funciona una plataforma para ver cuando  se debe publicar y que el usuario realize sus comprobaciones 
Utilizando menus para poder seleccionar de una mejor manera y hacer que el programa se entienda usando:
Validaciones de datos
Uso de funciones y procedimientos
Toma de decisiones con condiciones (if y switch)
Simula un caso real donde una plataforma necesita decidir qué contenido mostrar a sus usuarios.
