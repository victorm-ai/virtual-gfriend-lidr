| Company | Tool | AI Model |
|-----------|-----------|-----------|
| Open AI    | Chat GPT    | GPT4    |

# Prompts for: Use Cases

    Ahora genera todos los casos de uso necesarios para cumplir esos requerimientos funcionales propuestos.

Claro, aquí tienes los casos de uso necesarios para cumplir con los requerimientos funcionales propuestos para la aplicación móvil de "novia virtual" con un avatar de IA:

## Documento de Casos de Uso

- ### UC-01: Creación y Personalización del Avatar

    - **Descripción**: Permitir a los usuarios crear y personalizar un avatar según sus preferencias.
        
    - **Actores**
        - Usuario.

- ### Precondiciones

    - El usuario debe estar registrado y autenticado en la aplicación.

- ### Postcondiciones

    - Un avatar personalizado se crea y guarda para el usuario.

- ### Flujo Principal

    - El usuario accede a la opción de creación de avatar.
    - El sistema presenta opciones de características físicas (cabello, ropa, accesorios).
    - El usuario selecciona las características deseadas.
    - El sistema guarda las selecciones y crea el avatar.
    - El usuario accede a la opción de personalización de la personalidad.
    - El sistema presenta opciones de personalidades (divertido, cariñoso, intelectual).
    - El usuario selecciona la personalidad deseada.
    - El sistema guarda la personalidad del avatar.

### Flujo Alternativo

- Si el usuario decide no completar la personalización, el sistema guarda el avatar con las opciones por defecto.

- ### UC-02: Comunicación por Chat de Texto

    - **Descripción**: Permitir a los usuarios comunicarse con el avatar mediante un chat de texto.
    - **Actores**
        - Usuario.

    - **Precondiciones**

        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**

        - La conversación se guarda en el sistema.

    - **Flujo Principal**

        - El usuario accede a la opción de chat.
        - El usuario escribe un mensaje de texto.
        - El sistema analiza el mensaje y genera una respuesta.
        - El avatar responde al mensaje del usuario.
        - El usuario puede continuar la conversación escribiendo más mensajes.

- ### UC-03: Comunicación por Voz

    - **Descripción**: Permitir a los usuarios comunicarse con el avatar mediante voz.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - La conversación de voz se guarda en el sistema.

    - **Flujo Principal**

        - El usuario accede a la opción de comunicación por voz.
        - El usuario habla al avatar.
        - El sistema analiza la entrada de voz y genera una respuesta.
        - El avatar responde al usuario mediante voz.
        - El usuario puede continuar la conversación hablando más.

- ### UC-04: Videollamadas con el Avatar
    - **Descripción**: Permitir a los usuarios realizar videollamadas con el avatar.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - La videollamada se registra en el sistema.

    - **Flujo Principal**

        - El usuario accede a la opción de videollamada.
        - El usuario inicia una videollamada con el avatar.
        - El avatar aparece en la pantalla con animaciones que muestran emociones y gestos.
        - El usuario y el avatar conversan mediante video.
        - El usuario finaliza la videollamada.

- ### UC-05: Juegos y Minijuegos con el Avatar

    - **Descripción**: Permitir a los usuarios jugar juegos y minijuegos con el avatar.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - Los resultados del juego se guardan en el sistema.

    - **Flujo Principal**

        - El usuario accede a la opción de juegos.
        - El sistema presenta una lista de juegos disponibles.
        - El usuario selecciona un juego.
        - El usuario y el avatar juegan el juego seleccionado.
        - El sistema guarda los resultados del juego.

- ### UC-06: Actividades Compartidas con el Avatar
    - **Descripción**: Permitir a los usuarios realizar actividades compartidas con el avatar, como ver películas o leer libros.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**

        - La actividad se registra en el sistema.

    - **Flujo Principal**

        - El usuario accede a la opción de actividades compartidas.
        - El sistema presenta una lista de actividades disponibles.
        - El usuario selecciona una actividad.
        - El usuario y el avatar realizan la actividad juntos.
        - El sistema guarda la actividad realizada.

- ### UC-07: Asistencia y Apoyo Emocional
    - **Descripción**: Proveer consejos, motivación y apoyo emocional a los usuarios mediante el avatar.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - Las interacciones de apoyo se guardan en el sistema.

    - **Flujo Principal**

        - El usuario accede a la opción de apoyo emocional.
        - El usuario describe su situación o problema.
        - El sistema analiza la información y genera una respuesta de apoyo.
        - El avatar proporciona consejos y motivación al usuario.
        - El usuario puede continuar la conversación para recibir más apoyo.

- ### UC-08: Uso de Diario Personal

    - **Descripción**: Permitir a los usuarios escribir sus pensamientos en un diario y recibir comentarios del avatar.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - Las entradas del diario se guardan en el sistema.

    - **Flujo Principal**

        - El usuario accede a la opción de diario personal.
        - El usuario escribe una entrada en el diario.
        - El sistema analiza la entrada y genera un comentario del avatar.
        - El avatar proporciona un comentario basado en la entrada del usuario.
        - El sistema guarda la entrada del diario y el comentario del avatar.

- ### UC-09: Configuración de Recordatorios
    - **Descripción**: Permitir a los usuarios configurar recordatorios personalizados para eventos, citas y tareas diarias.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - Los recordatorios se guardan en el sistema y se notifican al usuario.

    - **Flujo Principal**

        - El usuario accede a la opción de configuración de recordatorios.
        - El usuario crea un nuevo recordatorio ingresando detalles como fecha, hora y descripción.
        - El sistema guarda el recordatorio.
        - El sistema notifica al usuario cuando el evento o tarea se acerca.

- ### UC-10: Gestión del Tiempo y Organización
    - **Descripción**: Proveer herramientas de gestión del tiempo y organización personal a los usuarios.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - La información de organización se guarda en el sistema.

    - **Flujo Principal**

        - El usuario accede a la opción de gestión del tiempo.
        - El usuario crea o modifica eventos en su agenda.
        - El sistema guarda los eventos y tareas organizadas.
        - El sistema proporciona notificaciones y recordatorios según la agenda del usuario.

- ### UC-11: Adaptación y Aprendizaje del Avatar
    - **Descripción**: Utilizar técnicas de aprendizaje automático para que el avatar se adapte y aprenda de las interacciones con el usuario.
    - **Actores**
        - Sistema.

    - **Precondiciones**
        - El usuario debe interactuar con el avatar.

    - **Postcondiciones**
        - El avatar mejora sus respuestas y comportamiento basado en las interacciones.

    - **Flujo Principal**

        - El sistema registra todas las interacciones del usuario con el avatar.
        - El sistema analiza los datos de las interacciones.
        - El sistema ajusta los modelos de IA para mejorar las respuestas y el comportamiento del avatar.
        - El avatar responde de manera más adecuada y personalizada en futuras interacciones.

- ### UC-12: Reconocimiento de Emociones
    - **Descripción**: Implementar el reconocimiento de emociones para que el avatar responda de manera adecuada al estado emocional del usuario.
    
    - **Actores**
        - Usuario.
        - Sistema.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - El sistema adapta las respuestas del avatar según las emociones del usuario.

    - **Flujo Principal**

        - El usuario interactúa con el avatar.
        - El sistema analiza las entradas de texto y voz para detectar emociones.
        - El sistema ajusta las respuestas del avatar según la emoción detectada.
        - El avatar proporciona una respuesta adecuada al estado emocional del usuario.

- ### UC-13: Integración con Redes Sociales
    - **Descripción**: Permitir a los usuarios integrar la aplicación con sus redes sociales para compartir momentos y logros.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.
        - El usuario debe otorgar permisos de acceso a sus redes sociales.

    - **Postcondiciones**
        - Los momentos y logros se publican en las redes sociales del usuario.

    - **Flujo Principal**

        - El usuario accede a la opción de integración con redes sociales.
        - El usuario otorga permisos de acceso a sus redes sociales.
        - El usuario selecciona momentos o logros para compartir.
        - El sistema publica el contenido en las redes sociales del usuario.

- ### UC-14: Compatibilidad con Dispositivos y Apps
    - **Descripción**: Asegurar que la aplicación sea compatible con dispositivos de hogar inteligente y otras aplicaciones populares.

    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - La aplicación se conecta y funciona con otros dispositivos y aplicaciones.

    - **Flujo Principal**

        - El usuario accede a la opción de configuración de dispositivos.
        - El usuario selecciona dispositivos y aplicaciones para conectar.
        - El sistema establece la conexión con los dispositivos y aplicaciones seleccionadas.
        - El usuario puede interactuar con el avatar a través de estos dispositivos y aplicaciones.

- ### UC-15: Protección de Datos Personales
    - **Descripción**: Garantizar la protección de datos personales y conversaciones mediante encriptación y políticas de privacidad.
    
    - **Actores**
        - Usuario.
        - Administrador del Sistema

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - Los datos personales y las conversaciones están protegidos.

    - **Flujo Principal**

        - El sistema encripta todos los datos personales y conversaciones del usuario.
        - El administrador del sistema asegura el cumplimiento de las políticas de privacidad.
        - El sistema permite al usuario revisar y gestionar sus datos personales.
        - El usuario puede solicitar la eliminación de sus datos personales.

- ### UC-16: Controles Parentales
    - **Descripción**: Incluir controles parentales para usuarios menores de edad.
    
    - **Actores**
        - Usuario.
        - Padre/Tutor.
        - Usuario Menor de Edad.

    - **Precondiciones**

        - El usuario menor de edad debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - Las actividades del usuario menor de edad son monitoreadas y controladas.

    - **Flujo Principal**

        - El padre/tutor accede a la opción de controles parentales.
        - El padre/tutor configura las restricciones y permisos para el usuario menor de edad.
        - El sistema monitorea y aplica las restricciones configuradas.
        - El usuario menor de edad interactúa con la aplicación bajo las restricciones establecidas.

- ### UC-17: Sistema de Recompensas y Logros
    - **Descripción**: Introducir logros y recompensas para fomentar la interacción continua con el avatar.
    
    - **Actores**
        - Usuario.

    - **Precondiciones**
        - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - Los logros y recompensas se registran y muestran al usuario.

    - **Flujo Principal**

        - El usuario accede a la opción de logros y recompensas.
        - El sistema presenta una lista de logros disponibles.
        - El usuario realiza acciones para alcanzar los logros.
        - El sistema otorga recompensas y registra los logros alcanzados.

- ### UC-18: Contenido Exclusivo y Actualizaciones

    - **Descripción**: Ofrecer contenido exclusivo y actualizaciones periódicas con nuevas funcionalidades y opciones de personalización.

    - **Actores**
        - Usuario.

    - **Precondiciones**
    - El usuario debe estar registrado y autenticado en la aplicación.

    - **Postcondiciones**
        - El contenido exclusivo y las actualizaciones se aplican y muestran al usuario.

    - ### Flujo Principal

        - El usuario recibe notificaciones de nuevo contenido exclusivo y actualizaciones.
        - El usuario accede a la opción de contenido exclusivo.
        - El sistema muestra las nuevas funcionalidades y opciones de personalización.
        - El usuario utiliza el nuevo contenido y actualiza su avatar y preferencias.

Este conjunto de casos de uso cubre las funcionalidades necesarias para la aplicación de "novia virtual" y asegura que todos los aspectos requeridos estén claramente definidos para el desarrollo.

| Company | Tool | AI Model |
|-----------|-----------|-----------|
| PlanText    | PlanText    | Unknown    |

# Prompt 04: Use Cases

    Genera el código para hacer diagrama de casos de uso con Mermaid. Deja como actor a el "Usuario" y los nombres de los casos de uso con los que interactue directamente.

## Código para Casos de Uso

    @startuml
    left to right direction

    skin rose

    actor User as U

    rectangle "Mobile Application | My Virtual Girlfriend"{
        usecase "Creation and Personalisation of the Avatar" as UC1
        usecase "Text Chat Communication" as UC2
        usecase "Voice Communication" as UC3
        usecase "Video calls with the Avatar" as UC4
        usecase "Time Management and Organisation" as UC5
        usecase "Avatar Adaptation and Learning" as UC6
        usecase "Emotion Recognition" as UC7
        usecase "Personal Data Protection" as UC8
        usecase "Rewards and Achievements" as UC9
        usecase "Exclusive Content and Updates" as UC10
    }

    U --> (UC1) 
    U --> (UC2)
    U --> (UC3)
    U --> (UC4)
    U --> (UC5)
    U --> (UC6)
    U --> (UC7)
    U --> (UC8)
    U --> (UC9)
    U --> (UC10)

    @enduml

![Alt Text](/02%20Resources/Use%20Cases.png)
