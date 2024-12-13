| Company | Tool | AI Model |
|-----------|-----------|-----------|
| Open AI    | Chat GPT    | GPT4    |

# Prompts for: Data Dictionary

    Dado el modelo de datos propuesto con estas entidades:

    - Usuario
    - Avatar
    - Personalidad
    - Interacción
    - Recordatorio
    - Actividad
    - Logro
    - Recompensa
    - Configuración de Seguridad
    - Configuración Parental
    - Contenido Exclusivo
    - Diario
    - Mensaje
    - Emoción

    Escoge cuales deberían pertenecer a una base de datos relacional y cuales a una base de datos no relacional.

    Después de eso, haz un diccionario de datos para cada una de ellas.

Aquí te presento una separación de las entidades de datos para tu arquitectura con una base de datos relacional y otra no relacional, junto con el diccionario de datos para cada una.

## Clasificación de Entidades en Bases de Datos

### Base de Datos Relacional: 

Las entidades que se benefician de la consistencia, las relaciones bien definidas, y las operaciones transaccionales.

- Usuario
- Avatar
- Personalidad
- Interacción
- Recordatorio
- Actividad
- Logro
- Configuración de Seguridad
- Configuración Parental

### Base de Datos No Relacional

Entidades que necesitan almacenamiento flexible y escalar horizontalmente, o aquellas que almacenan documentos, datos no estructurados, o contenido altamente dinámico.

- Recompensa
- Contenido Exclusivo
- Diario
- Mensaje
- Emoción

### Diccionario de Datos para Entidades Relacionales

**Usuario**

- IDUsuario: Identificador único (int, PK)
- Nombre: Nombre del usuario (varchar, 100)
- Correo Electrónico: Correo del usuario (varchar, 255, único)
- Contraseña: Hash de contraseña (varchar, 255)
- FechaRegistro: Fecha de creación del usuario (datetime)

**Avatar**

- IDAvatar: Identificador único (int, PK)
- IDUsuario: Relación con Usuario (int, FK)
- NombreAvatar: Nombre del avatar (varchar, 100)
- Descripción: Descripción de apariencia o personalidad (varchar, 255)

**Personalidad**

- IDPersonalidad: Identificador único (int, PK)
- IDAvatar: Relación con Avatar (int, FK)
- Tipo: Tipo de personalidad (varchar, 50)
- Rasgos: Descripción de rasgos (varchar, 255)

**Interacción**

- IDInteracción: Identificador único (int, PK)
- IDUsuario: Relación con Usuario (int, FK)
- Fecha: Fecha de la interacción (datetime)
- Descripción: Descripción de la interacción (varchar, 255)

**Recordatorio**

- IDRecordatorio: Identificador único (int, PK)
- IDUsuario: Relación con Usuario (int, FK)
- Mensaje: Mensaje del recordatorio (varchar, 255)
- FechaProgramada: Fecha y hora del recordatorio (datetime)

**Actividad**

- IDActividad: Identificador único (int, PK)
- IDUsuario: Relación con Usuario (int, FK)
- TipoActividad: Tipo de actividad (varchar, 50)
- Fecha: Fecha de la actividad (datetime)

**Logro**

- IDLogro: Identificador único (int, PK)
- IDUsuario: Relación con Usuario (int, FK)
- NombreLogro: Nombre del logro (varchar, 100)
- Descripción: Descripción del logro (varchar, 255)
- FechaConseguido: Fecha de obtención (datetime)

**Configuración de Seguridad**

- IDSeguridad: Identificador único (int, PK)
- IDUsuario: Relación con Usuario (int, FK)
- FactorAutenticación: Activado o no (boolean)
- NotificacionesSeguridad: Configuración de notificaciones (boolean)

**Configuración Parental**

- IDParental: Identificador único (int, PK)
- IDUsuario: Relación con Usuario (int, FK)
- NivelRestricción: Nivel de restricción (int)
- ReportesActividades: Si se generan reportes (boolean)

### Diccionario de Datos para Entidades No Relacionales

**Recompensa**

- IDRecompensa: Identificador único
- Nombre: Nombre de la recompensa
- Descripción: Detalles sobre la recompensa
- Requisitos: Condiciones para desbloquearla

**Contenido Exclusivo**

- IDContenido: Identificador único
- Tipo: Tipo de contenido (audio, video, texto)
- URL: Ruta de almacenamiento del contenido
- Descripción: Descripción del contenido

**Diario**

- IDEntrada: Identificador único
- IDUsuario: Identificador del usuario
- Fecha: Fecha de la entrada
- Contenido: Contenido completo del diario (texto)

**Mensaje**

- IDMensaje: Identificador único
- IDUsuario: Relación con Usuario
- Fecha: Fecha del mensaje
- Contenido: Contenido del mensaje

**Emoción**

- IDEmoción: Identificador único
- IDUsuario: Relación con Usuario
- Tipo: Tipo de emoción (felicidad, tristeza, etc.)
- Intensidad: Nivel de la emoción (escala 1-10)

Esto proporciona un modelo organizado para implementar tanto bases de datos relacionales como no relacionales en la arquitectura de microservicios en Azure. Las entidades relacionales se beneficiarán de las garantías ACID, mientras que las entidades no relacionales tendrán más flexibilidad y escalabilidad.