# 3. Data Model
    
## _3.1. Description of main entities_

- ### User 
    - Represents the users registered in the mobile application.     

- ### Avatar
    - Represents the custom avatar created by the user.

- ### Personality 
    - Defines the different types of personalities that an avatar can have.

- ### Interaction 
    - Records the interactions between the user and the avatar (chat, voice, video call).

- ### Reminder 
    - Stores reminders configured by the user.

- ### Achievement
    - Represents the achievements obtained by the user.

- ### Reward 
    - Stores the rewards obtained by the user.

- ### Content 
    - Stores content shared by users and avatars.

## _3.2. Diagram of the data model_

![Alt Text](/02%20Resources/ER%20V2.0.png)

### Relational database information

- ### Users
   
    | **Property**    | **Description**                    | Value type | Key |
    |-----------------|------------------------------------|------------|-----|
    | **Id**          | Unique identifier.                 | int        |PK   |
    | **Account**     | User's account.                    | string     |
    | **Name**        | User's name.                       | string     |
    | **Email**       | User's email address.              | string     |
    | **Password**    | User's password.                   | string     |
    | **BirthDate**   | User's date of birth.              | date time  |
    | **Timestamp**    | Specific time of registration.     | timespan   |
  
- ### Avatars

    | **Property**       | **Description**              | Value type | Key |
    |--------------------|------------------------------|------------|-----|
    | **Id**             | Unique identifier.           | int        | PK  |
    | **Name**           | Avatar's name.               | string     |
    | **UserId**         | User creator of avatar.      | int        | FK  |
    | **PersonalityId**  | Personality of avatar.       | int        | FK  |
    | **Timestamp**       | Specific time of registration.| timespan   |

- ### Personalities

    | **Property**       | **Description**                    | Value type | Key |
    |--------------------|------------------------------------|------------|-----|
    | **Id**             | Unique identifier.                 | int        | PK
    | **Personality**    | Personality of avatar.             | string     |
    | **Physical Appearance**  | Physical appearance of avatar.       | string        |   |
    | **Details**        | Details of personality.            | string     |
    | **Timestamp**       | Specific time of registration.     | timespan   |

- ### Achievements

    | **Property**      | **Description**                   | Value type | Key |
    |-------------------|-----------------------------------|------------|-----|
    | **Id**            | Unique identifier.                | int        | PK  |
    | **Name**          | Name of achievement.              | string     | 
    | **Rank**          | Rank of achievement.              | int        | 
    | **Description**   | Description of achievement.       | string     |     
    | **Timestamp**      | Specific time of registration.    | timespan   |

 - ### Rewards

    | **Property**      | **Description**                    | Value type | Key |
    |-------------------|------------------------------------|------------|-----|
    | **Id**            | Unique identifier.                 | int        | PK  |
    | **Reward**        | Type of reward.                    | string     |
    | **Timestamp**      | Specific time of registration.     | timespan   |

 - ### RewardsForAchievements

    | **Property**      | **Description**                    | Value type | Key |
    |-------------------|------------------------------------|------------|-----|
    | **Id**            | Unique identifier.                 | int        | PK  |
    | **AchievementId** | Achievement identifier.            | int        | FK
    | **RewardId**      | Reward identifier.                 | int        | FK
    | **Timestamp**      | Specific time of registration.     | timespan   |

- ### UserAchievements

    | **Property**      | **Description**                    | Value type | Key |
    |-------------------|------------------------------------|------------|-----|
    | **Id**            | Unique identifier.                 | int        | PK  |
    | **AchivementId**  | Name of achievement.               | int        | FK  |
    | **UserId**        | User who has achieved something.   | int        | FK  |
    | **Timestamp**      | Specific time of registration.     | timespan   |

- ### ContentType 
    - Stores content type shared between users and avatars.

    | **Property**      | **Description**                     | Value type | Key |
    |-------------------|-------------------------------------|------------|-----|
    | **Id**            | Unique identifier.                  | int        | PK  |
    | **Content**       | Content type shared between the user and his avatar.| string      |
    | **Timestamp**      | Specific time of registration.      | timespan   |

### No SQL database information

- ### Interactions
  - Store the interactions and shared content between the user and his avatar (text, voice or video calls).

          {
            "Interactions": 
            {
                "Id": int,
                "UserId": int,
                "AvatarId": int,
                "InteractionType": string,
                "ContentInteraction" : string
                "Timestamp": string
            }
        }    

    | **Property**            | **Description**                     | Value type 
    |-------------------------|-------------------------------------|------------
    | **Id**                  | Unique identifier.                  | int        
    | **UserId**              | User's identifier                   | int        
    | **AvatarId**            | Avatar's identifier                 | int        
    | **InteractionType**     | Type of interaction (text, voice or video). | string      
    | **ContentInteraction**  | Shared content.                     | text / binary        
    | **Timespan**        | Specific time of registration.          | timespan   

- ### Activities

  - Store the reminders for users (events, appointments, meetings...).

          {
            "Activities": 
            {
                "Id": int,
                "UserId": int,
                "ActivityId": int,
                "Name": string,
                "When" : string
                "Timestamp": string
            }
        }    


    | **Property**      | **Description**                    | Value type |
    |-------------------|------------------------------------|------------|
    | **Id**            | Unique identifier.                 | int        | 
    | **UserId**        | User creator of reminder.          | int        |
    | **ActivityId**    | Unique identifier.                 | int        |
    | **Name**          | Reminder's name.                   | string     |
    | **When**          | Reminder's date.                   | date time  |    
    | **Timespan**      | Specific time of registration.     | timespan   |