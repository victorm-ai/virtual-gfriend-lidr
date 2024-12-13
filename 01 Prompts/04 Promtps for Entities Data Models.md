| Company | Tool | AI Model |
|-----------|-----------|-----------|
| Open AI    | Chat GPT    | GPT4    |

# Prompts for: Entity Data Models

    Dime cuales serían las entidades principales a considerar en esta aplicación de "novia virtual". El objetivo es hacer el modelo de datos correspondiente.

Para el modelo de datos de la aplicación de "novia virtual", se deben considerar las siguientes entidades principales:

- **Usuario:** Representa a los usuarios registrados en la aplicación.

- **Avatar:** Representa al avatar personalizado creado por el usuario.

- **Personalidad:** Define los diferentes tipos de personalidades que un avatar puede tener.

- **Interacción:** Registra las interacciones entre el usuario y el avatar (chat, voz, videollamada, juegos, etc.).

- **Recordatorio:** Almacena los recordatorios configurados por el usuario.

- **Actividad:** Registra las actividades compartidas entre el usuario y el avatar (ver películas, leer libros, etc.).

- **Logro:** Representa los logros obtenidos por el usuario.

- **Recompensa:** Almacena las recompensas obtenidas por el usuario.

- **Configuración de Seguridad:** Contiene configuraciones de seguridad y privacidad del usuario.

- **Configuración Parental:** Almacena las configuraciones parentales para usuarios menores de edad.

- **Contenido Exclusivo:** Almacena el contenido exclusivo disponible para los usuarios.

- **Diario:** Almacena las entradas del diario personal del usuario.

- **Mensaje:** Registra los mensajes intercambiados en el chat.

- **Emoción:** Registra el reconocimiento de emociones del usuario.

## Modelo de Datos Propuesto

A continuación se describe el modelo de datos con sus respectivas entidades y relaciones.

### Entidad: Usuario

- ID: Identificador único.
- Nombre de Usuario: Nombre del usuario.
- Correo Electrónico: Email del usuario.
- Contraseña: Contraseña del usuario.
- Fecha de Nacimiento: Fecha de nacimiento del usuario.
- Tipo de Usuario: Tipo de usuario (normal, menor de edad).

### Entidad: Avatar

- **ID:** Identificador único.
- **Nombre:** Nombre del avatar.
- **Usuario ID:** Referencia al usuario que creó el avatar.
- **Personalidad ID:** Referencia a la personalidad del avatar.

### Entidad: Personalidad

- **ID:** Identificador único.
- **Descripción:** Descripción de la personalidad.

### Entidad: Interacción

- **ID:** Identificador único.
- **Usuario ID:** Referencia al usuario.
- **Avatar ID:** Referencia al avatar.
- **Tipo de Interacción:** Tipo de interacción (chat, voz, videollamada, juego, etc.).
- **Fecha y Hora:** Fecha y hora de la interacción.

### Entidad: Recordatorio

- **ID:** Identificador único.
- **Usuario ID:** Referencia al usuario.
- **Descripción:** Descripción del recordatorio.
- **Fecha y Hora:** Fecha y hora del recordatorio.

### Entidad: Actividad

- **ID:** Identificador único.
- **Usuario ID:** Referencia al usuario.
- **Avatar ID:** Referencia al avatar.
- **Descripción:** Descripción de la actividad.
- **Fecha y Hora:** Fecha y hora de la actividad.

### Entidad: Logro

- **ID:** Identificador único.
- **Descripción:** Descripción del logro.
- **Recompensa ID:** Referencia a la recompensa asociada.

### Entidad: Recompensa

- **ID:** Identificador único.
- **Descripción:** Descripción de la recompensa.

### Entidad: Configuración de Seguridad

- **ID:** Identificador único.
- **Usuario ID:** Referencia al usuario.
- **Configuraciones:** Detalles de las configuraciones de seguridad y privacidad.

### Entidad: Configuración Parental

- **ID:** Identificador único.
- **Usuario ID:** Referencia al usuario menor de edad.
- **Padre/Tutor ID:** Referencia al padre/tutor.
- **Restricciones:** Detalles de las restricciones configuradas.

### Entidad: Contenido Exclusivo

- **ID:** Identificador único.
- **Descripción:** Descripción del contenido exclusivo.
- **Fecha de Publicación:** Fecha de publicación del contenido.

### Entidad: Diario

- **ID:** Identificador único.
- **Usuario ID:** Referencia al usuario.
- **Entrada:** Texto de la entrada del diario.
- **Fecha y Hora:** Fecha y hora de la entrada.

### Entidad: Mensaje

- **ID:** Identificador único.
- **Interacción ID:** Referencia a la interacción de chat.
- **Texto:** Texto del mensaje.
- **Fecha y Hora:** Fecha y hora del mensaje.

### Entidad: Emoción

- **ID:** Identificador único.
- **Usuario ID:** Referencia al usuario.
- **Tipo de Emoción:** Tipo de emoción reconocida.
- **Fecha y Hora:** Fecha y hora del reconocimiento.

### Relaciones entre Entidades

- Usuario 1..* --- 1..* Avatar
- Avatar 1..1 --- 1..1 Personalidad
- Usuario 1..* --- 1..* Interacción
- Interacción 1..1 --- 1..* Mensaje
- Usuario 1..* --- 1..* Recordatorio
- Usuario 1..* --- 1..* Actividad
- Avatar 1..* --- 1..* Actividad
- Usuario 1..* --- 1..* Diario
- Usuario 1..* --- 1..* Logro
- Logro 1..1 --- 1..1 Recompensa
- Usuario 1..* --- 1..1 Configuración de Seguridad
- Usuario 1..* --- 1..1 Configuración Parental
- Padre/Tutor 1..* --- 1..1 Configuración Parental
- Usuario 1..* --- 1..* Contenido Exclusivo
- Usuario 1..* --- 1..* Emoción

Este modelo de datos cubre las principales funcionalidades y entidades necesarias para la aplicación de "novia virtual", permitiendo una interacción fluida y personalizada entre el usuario y el avatar, al tiempo que garantiza la seguridad y privacidad de los datos.