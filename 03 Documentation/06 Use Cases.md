# Use Cases

## _UC-01: Creation and personalisation of the Avatar_
 
### Description
Allow users to create and customize an avatar according to their preferences.
    
### Actors
- User

### Preconditions
- The user must be registered and authenticated in the mobile application.

### Postconditions
- A custom avatar is created and saved for the user.

### Main Flow
- The user accesses the avatar creation option.
- The mobile application presents options for physical characteristics (hair, clothes, accessories).
- The user selects the desired characteristics.
- The mobile application saves the selections and creates the avatar.
- The user accesses the personality customisation option.
- The mobile application presents personality options (funny, caring, intellectual).
- The user selects the desired personality.
- The mobile application saves the avatar personality.

 ## _UC-02: Chat communication with the avatar_

### Description
Allow users to communicate with the avatar via text chat.

### Actors
- User.

### Preconditions
- The user must be registered and authenticated in the mobile application.
- The user must have created an avatar.

### Postconditions 
- The conversation is saved in the database.

### Main Flow
- The user  accesses the chat option .
- User types a text message.
- The avatar responds to the user's message.
- The user can continue the conversation by typing more messages.

## _UC-03: Voice communication with the avatar_

### Description
Allow users to communicate with the avatar by voice.

### Actors
- User.
        
### Preconditions
- The user must be registered and authenticated in the mobile application.
- The user must have created an avatar.

### Postconditions 
- The voice conversation is saved in the database.

### Main Flow
- The user  accesses the voice communication option .
- User speaks to the avatar.
- The mobile application analyses the voice input and generates a response.
- The avatar responds to the user by voice.
- The user can continue the conversation by speaking further.
 
## _UC-04: Video call communication with the Avatar_

###  Description
Allow users to make video calls with the avatar.

### Actors
- User.

### Preconditions
- The user must be registered and authenticated in the mobile application.
- The user must have created an avatar.

### Postconditions
- The video call is registered in the database.

###  Main Flow
- The user  accesses the video call option .
- The user initiates a video call with the avatar.
- The avatar appears on the screen with animations showing emotions and gestures.
- The user and the avatar converse via video.
- The user ends the video call.

 ## _UC-05: Time Management and organisation_

### Description
Allow users to set custom reminders for events, appointments and daily tasks.

### Actors
- User.
    
### Preconditions
- User must be registered and authenticated in the mobile application.
- The user must have created an avatar.

### Postconditions
- Reminders are saved in the database.
- The user is notified when the notification arrives at the scheduled time..

###  Main Flow

- User accesses the reminder configuration option.
- The user creates a new reminder by entering details such as date, time and description.
- The mobile application saves the reminder.
- The avatar notifies the user when the event or task is approaching.

##  _UC-06: Avatar and learning the Avatar_

### Description

Use machine learning techniques to make the avatar adapt and learn from user interactions.

### Actors

- Avatar / Model.

### Preconditions

- The user must be registered and authenticated in the mobile application.
- The user must have created an avatar.        
- The user must interact with the avatar.

### Postconditions

- The avatar improves its responses and behaviour based on interactions.

### Main Flow

- The mobile application logs all user interactions with the avatar.
- The model analyses the interaction data.
- The mobile application adjusts AI models to improve the avatar's responses and behaviour.
- The avatar responds in a more appropriate and personalised way in future interactions.

## _UC-07: Emotion Recognition_

### Description 
Implement emotion recognition so that the avatar responds appropriately to the emotional state of the user.

### Actors
- User.
- Avatar.

### Preconditions
- The user must be registered and authenticated in the mobile application.
- The user must have created an avatar.   
- The user must interact with the avatar.

### Postconditions
- The model adapts the avatar's responses according to the user's emotions.

### Main Flow
- The user interacts with the avatar.
- The model analyses text and voice inputs to detect emotions.
- The model adjusts the avatar's responses based on the detected emotion.
- The avatar provides an appropriate response to the user's emotional state.

## _UC-08: Personal data protection_

### Description 
Ensure the protection of personal data and conversations through encryption and privacy policies.
    
## Actors
- User.

### Preconditions 
- The user must be registered and authenticated in the mobile application.
- The user must have created an avatar.   
- The user must interact with the avatar.

###  Postconditions
- Personal data and conversations are protected.

### Main Flow
- The mobile application encrypts all personal data and user conversations.
- The mobile application allows the user to review and manage their personal data.
- The user can request deletion of their personal data.

## _UC-09: Rewards and Achievements_

##  Description 
Introduce achievements and rewards to encourage continued interaction with the avatar.
    
### Actors
- User.

### Preconditions
- The user must be registered and authenticated in the mobile application.
- The user must have created an avatar.   
- The user must interact with the avatar.

### Postconditions
- Achievements and rewards are logged and displayed to the user.

### Main Flow
- The user accesses the achievements and rewards option.
- The mobile appplication presents a list of available achievements.
- The user performs actions to achieve the achievements.
- The mobile application awards rewards and records achievements.

## _UC-10: Shared Content_

###  Description
Content shared between the user and his avatar (images, videos or doc files).

### Actors
- User.

### Preconditions
- The user must be registered and authenticated in the mobile application.
- The user must have created an avatar.   
- The user must interact with the avatar.

### Postconditions
- The content in file format is stored in the database.
- The avatar analyzes the file content and elaborates an appropriate response to the user.

### Main Flow
- The user shares an image, video or document file.
- The avatar analyzes it and responds based on the user's question.

## _Use Cases Diagram_

![Alt Text](/02%20Resources/Use%20Cases.png)