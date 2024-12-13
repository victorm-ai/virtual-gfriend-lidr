| Company | Tool | AI Model |
|-----------|-----------|-----------|
| Open AI    | Chat GPT    | GPT4    |

# Prompts for: Database Entity Relationship 

    Crea el código necesario para un diagrama entidad relación de base de datos en mermaid con la imagen que te estoy adjuntando.

![Alt Text](/02%20Resources/Table%20in%20excel.png)

Claro aquí tienes el código de tu diagrama entidad relación en formato mermaid:

    erDiagram
    Users {
        int Id PK
        string Name
        string Account
        string Email
        string Password
        datetime BirthDate
        timestamp Timestamp
    }
    
    Avatars {
        int Id PK
        string Name
        int UserId FK
        int PersonalityId FK
        timestamp Timestamp
    }
    
    Personalities {
        int Id PK
        string Personality
        string Details
        timestamp Timestamp
    }
        
   
    Achievements {
        int Id PK
        string Name
        int Rank
        string Description
        timestamp Timestamp
    }

    Rewards {
        int Id PK
        string Reward
        timestamp Timestamp
    }

    RewardsForAchievements{
        int Id PK
        int AchievementId FK
        int RewardId FK
        timestamp Timestamp
    }
    
    UserAchievements {
        int Id PK
        int AchivementId FK
        int UserId FK
        timestamp Timestamp
    }
    
    ContentType {
        int Id PK
        string ContentType
        timestamp Timestamp
    }

    %% Relaciones
    Users ||--o{ Avatars : "has one"
    Users ||--o{ ContentType : "share many"
    Users ||--o{ Achievements : "has many"
    Achievements ||--o{ Rewards : "has one"

    Avatars ||--o| Personalities : "has one"

# Prompt 09: Relational Database Tables  

    Generame el script para crear la tabla de Usuarios en Microsot SQL Server con la imagen que te adjunto. 

Aquí tienes el script en T-SQL para crear la tabla de Usuarios en Microsoft SQL Server, basándome en la información de la imagen proporcionada:

    CREATE TABLE Usuarios (
        Id INT PRIMARY KEY, -- Unique identifier
        Account NVARCHAR(255) NOT NULL, -- User's account
        Name NVARCHAR(255) NOT NULL, -- User's name
        Email NVARCHAR(255) NOT NULL, -- User's email address
        Password NVARCHAR(255) NOT NULL, -- User's password
        BirthDate DATETIME NOT NULL, -- User's date of birth
        Timespan TIME NOT NULL -- Specific time of registration
    );

**Descripción del Script**

- Id: Definido como clave primaria (PRIMARY KEY) y de tipo INT.
- Account, Name, Email, Password: Usamos NVARCHAR(255) para admitir cadenas Unicode y un tamaño razonable.
- BirthDate: Tipo de datos DATETIME para almacenar la fecha de nacimiento.
- Timespan: Tipo de datos TIME para almacenar el tiempo específico del registro.

- Restricciones:

    Todos los campos son definidos como NOT NULL para asegurar que se ingrese información en cada columna.

Si necesitas agregar índices, relaciones o más detalles, indícalo y puedo ajustar el script.


    Generame el script para crear la tabla de Avatares en Microsot SQL Server con la imagen que te adjunto. 

Aquí tienes el script en T-SQL para crear la tabla Avatares en Microsoft SQL Server, basado en la información proporcionada en la imagen:

    CREATE TABLE Avatares (
    Id INT PRIMARY KEY, -- Unique identifier
    Name NVARCHAR(255) NOT NULL, -- Avatar's name
    UserId INT NOT NULL, -- User creator of avatar
    PersonalityId INT NOT NULL, -- Personality of avatar
    Timespan TIME NOT NULL, -- Specific time of registration

    -- Definición de claves foráneas
    FOREIGN KEY (UserId) REFERENCES Usuarios(Id), -- Relación con tabla Usuarios
    FOREIGN KEY (PersonalityId) REFERENCES Personalidades(Id) -- Relación con tabla Personalidades);

**Descripción del Script**

- Id: Define el identificador único y clave primaria (PRIMARY KEY).
- Name: Tipo NVARCHAR(255) para permitir nombres Unicode con un tamaño razonable.
- UserId: Tipo INT, definido como clave foránea (FOREIGN KEY) que hace referencia al campo Id de la tabla Usuarios.
- PersonalityId: Tipo INT, clave foránea que referencia a Id en la tabla Personalidades.
- Timespan: Tipo TIME, para almacenar el momento específico de registro.

**Consideraciones**

Antes de crear esta tabla, asegúrate de que las tablas Usuarios y Personalidades ya existan en la base de datos.
Si necesitas agregar índices adicionales o restricciones específicas, indícalo y ajustaremos el script.

    Generame el script para crear la tabla de Personalidades en Microsot SQL Server con la imagen que te adjunto. 

Aquí tienes el script en T-SQL para crear la tabla Personalidades en Microsoft SQL Server, basado en la información proporcionada en la imagen:

    CREATE TABLE Personalidades (
    Id INT PRIMARY KEY, -- Unique identifier
    Personality NVARCHAR(255) NOT NULL, -- Personality of avatar
    Details NVARCHAR(MAX), -- Details of personality
    Timespan TIME NOT NULL -- Specific time of registration);

**Descripción del Script**

- Id: Define el identificador único y clave primaria (PRIMARY KEY).
- Personality: Tipo NVARCHAR(255) para almacenar la personalidad del avatar. Se utiliza NVARCHAR para soportar caracteres Unicode.
- Details: Tipo NVARCHAR(MAX) para almacenar los detalles de la personalidad, permitiendo descripciones largas.
- Timespan: Tipo TIME, para almacenar el momento específico de registro.

**Consideraciones**

Puedes agregar restricciones adicionales si es necesario, como valores únicos para el campo Personality (por ejemplo, si cada personalidad debe ser única).
Si deseas extender la tabla con índices adicionales o relaciones con otras tablas, avísame y ajusto el script.

    Generame el script para crear la tabla de Achievements en Microsot SQL Server con la imagen que te adjunto. 

Aquí tienes el script en T-SQL para crear la tabla Achievements en Microsoft SQL Server basado en la información proporcionada en la imagen:

    CREATE TABLE Achievements (
    Id INT PRIMARY KEY, -- Unique identifier
    Name NVARCHAR(255) NOT NULL, -- Name of achievement
    Rank INT NOT NULL, -- Rank of achievement
    Description NVARCHAR(MAX), -- Description of achievement
    Timespan TIME NOT NULL -- Specific time of registration);

**Descripción del Script**

- Id: Identificador único y clave primaria (PRIMARY KEY).
- Name: Tipo NVARCHAR(255) para el nombre del logro. Se utiliza NVARCHAR para admitir caracteres Unicode.
- Rank: Tipo INT, que representa el rango o nivel del logro.
- Description: Tipo NVARCHAR(MAX) para permitir descripciones largas.
- Timespan: Tipo TIME, que almacena el tiempo específico del registro.

**Consideraciones**

Si se requiere que los nombres de los logros sean únicos, se puede agregar una restricción UNIQUE en la columna Name.
Este diseño permite almacenar una descripción detallada y jerarquías de los logros.

¿Te gustaría agregar índices adicionales, relaciones con otras tablas o restricciones específicas? ¡Avísame!

    Generame el script para crear la tabla de Rewards en Microsot SQL Server con la imagen que te adjunto. 

Aquí tienes el script en T-SQL para crear la tabla Rewards en Microsoft SQL Server basado en la información proporcionada en la imagen:

    CREATE TABLE Rewards (
        Id INT PRIMARY KEY, -- Unique identifier
        Reward NVARCHAR(255) NOT NULL, -- Type of reward
        Timespan TIME NOT NULL -- Specific time of registration
    );

**Descripción del Script**

- Id: Identificador único para cada recompensa, definido como clave primaria (PRIMARY KEY).
- Reward: Tipo NVARCHAR(255) para almacenar el tipo de recompensa. Se utiliza NVARCHAR para admitir caracteres Unicode.
- Timespan: Tipo TIME, que almacena el momento específico del registro.

**Consideraciones**

- Si las recompensas necesitan ser únicas, puedes agregar una restricción UNIQUE a la columna Reward.
- Este diseño es simple y permite futuras extensiones, como agregar relaciones con otras tablas (por ejemplo, asignar recompensas a logros o usuarios).

¿Te gustaría agregar más columnas, índices o relaciones específicas? ¡Avísame!

    Generame el script para crear la tabla de RewardsForAchievements en Microsot SQL Server con la imagen que te adjunto. 

Aquí tienes el script en T-SQL para crear la tabla RewardsForAchievements en Microsoft SQL Server, basado en la información proporcionada en la imagen:

    CREATE TABLE RewardsForAchievements (
    Id INT PRIMARY KEY, -- Unique identifier
    AchievementId INT NOT NULL, -- Achievement identifier
    RewardId INT NOT NULL, -- Reward identifier
    Timespan TIME NOT NULL, -- Specific time of registration

    -- Definición de claves foráneas
    FOREIGN KEY (AchievementId) REFERENCES Achievements(Id), -- Relación con tabla Achievements
    FOREIGN KEY (RewardId) REFERENCES Rewards(Id) -- Relación con tabla Rewards);

**Descripción del Script**

- Id: Identificador único para la tabla, definido como clave primaria (PRIMARY KEY).
- AchievementId: Tipo INT, clave foránea (FOREIGN KEY) que hace referencia a la columna Id de la tabla Achievements.
- RewardId: Tipo INT, clave foránea (FOREIGN KEY) que hace referencia a la columna Id de la tabla Rewards.
- Timespan: Tipo TIME, para almacenar el momento específico del registro.

**Consideraciones**

Esta tabla permite asociar múltiples recompensas con logros específicos.
- Asegúrate de que las tablas Achievements y Rewards existan antes de crear esta tabla, ya que tiene dependencias con estas.
- Si es necesario garantizar que una combinación de AchievementId y RewardId sea única (para evitar duplicados), se puede agregar una restricción adicional como esta:

    Generame el script para crear la tabla de UserAchievements en Microsot SQL Server con la imagen que te adjunto. 

Aquí tienes el script en T-SQL para crear la tabla UserAchievements en Microsoft SQL Server, basado en la información proporcionada en la imagen:

    CREATE TABLE UserAchievements (
        Id INT PRIMARY KEY, -- Unique identifier
        AchievementId INT NOT NULL, -- Name of achievement
        UserId INT NOT NULL, -- User who has achieved something
        Timespan TIME NOT NULL, -- Specific time of registration

        -- Definición de claves foráneas
        FOREIGN KEY (AchievementId) REFERENCES Achievements(Id), -- Relación con tabla Achievements
        FOREIGN KEY (UserId) REFERENCES Usuarios(Id) -- Relación con tabla Usuarios);
    
**Descripción del Script**

- Id: Identificador único para cada logro del usuario, definido como clave primaria (PRIMARY KEY).
- AchievementId: Tipo INT, clave foránea (FOREIGN KEY) que hace referencia a la columna Id en la tabla Achievements.
- UserId: Tipo INT, clave foránea (FOREIGN KEY) que hace referencia a la columna Id en la tabla Usuarios.
- Timespan: Tipo TIME, que almacena el momento específico en que se registró el logro.

**Consideraciones**

- Asegúrate de que las tablas Achievements y Usuarios existan antes de crear esta tabla.
- Si es necesario garantizar que cada combinación de UserId y AchievementId sea única, puedes agregar una restricción UNIQUE adicional:

    ALTER TABLE UserAchievements
    ADD CONSTRAINT UQ_UserAchievement UNIQUE (UserId, AchievementId);

¿Te gustaría agregar índices adicionales o ajustar el diseño según tus necesidades? ¡Avísame!

    Generame el script para crear la tabla de ContentType en Microsot SQL Server con la imagen que te adjunto. 

Aquí tienes el script en T-SQL para crear la tabla UserAchievements en Microsoft SQL Server, basado en la información proporcionada en la imagen:

    CREATE TABLE UserAchievements (
        Id INT PRIMARY KEY, -- Unique identifier
        AchievementId INT NOT NULL, -- Name of achievement
        UserId INT NOT NULL, -- User who has achieved something
        Timespan TIME NOT NULL, -- Specific time of registration

        -- Definición de claves foráneas
        FOREIGN KEY (AchievementId) REFERENCES Achievements(Id), -- Relación con tabla Achievements
        FOREIGN KEY (UserId) REFERENCES Usuarios(Id) -- Relación con tabla Usuarios );

**Descripción del Script**

- Id: Identificador único para cada logro del usuario, definido como clave primaria (PRIMARY KEY).
- AchievementId: Tipo INT, clave foránea (FOREIGN KEY) que hace referencia a la columna Id en la tabla Achievements.
- UserId: Tipo INT, clave foránea (FOREIGN KEY) que hace referencia a la columna Id en la tabla Usuarios.
- Timespan: Tipo TIME, que almacena el momento específico en que se registró el logro.

**Consideraciones**

- Asegúrate de que las tablas Achievements y Usuarios existan antes de crear esta tabla.
- Si es necesario garantizar que cada combinación de UserId y AchievementId sea única, puedes agregar una restricción UNIQUE adicional: