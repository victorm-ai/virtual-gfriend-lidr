# 4. API Specification
    
## _4.1. Users Microservice_

| Endpoint | Method | Description | Parameters | Body Request | Response | Bearer Token |
|----------|--------|-------------|------------|--------------|----------|--------------|
| /api/users/getusers | GET | Retrieves a list of all registered users. | None | None | 200 OK: List of users (JSON array). | Yes |
| /api/users/getuser/{userId} | GET |  Retrieve user details by user id. | userId(int, required) | None | 200 OK: User details (JSON object).<br> 404 Not Found: User not found. | Yes
| /api/users/createuser | POST | Create a new user. | None | json {""} | 201 Created: User successfully created (JSON object).<br> 400 Bad Request: Invalid data in the request. | Yes
| /api/users/updateuser/{userId} | PUT | Update the data of an existing user. | userId(int, required) | json {""} | 200 OK: User successfully updated (JSON object).<br> 404 Not Found: User not found.<br> 400 Bad Request: Invalid data in the request.| Yes
| /api/users/deleteuser/{userId} | DELETE | Deletes an existing user. | userId(int, required) | None | 204 No content: User successfully deleted. 404 Not found: User not found. | Yes

### Response Body Examples

**GET /api/users**

    [
        {
            "id": 1,
            "name": "Juan Pérez",
            "email": "juan.perez@example.com"
        },
        {
            "id": 2,
            "name": "Ana López",
            "email": "ana.lopez@example.com"
        }
    ]

**POST /api/users**

    {
        "name": "Juan Pérez",
        "email": "juan.perez@example.com"
    }

## _4.2. Avatars Microservice_

| Endpoint | Method | Description | Parameters | Body Request | Response | Bearer Token |
|----------|--------|-------------|------------|--------------|-----------|-------------|
| /api/avatars/getavatars | GET | Retrieves a list of all created avatars. | None | None | 200 OK: List of avatars (JSON array). | Yes
| /api/avatars/getavatar/{avatarId} | GET | Retrieve avatar details by avatar id. | avatarId(int, required) | None | 200 OK: Avatar details (JSON object).<br> 404 Not Found: Avatar not found. | Yes
| /api/avatars/createavatar | POST | Create a new avatar. | None | json {""} | 201 Created: Avatar successfully created (JSON object). <br> 400 Bad Request: Invalid data in the request. | Yes
| /api/avatars/updateavatar/{avatarId} | PUT | Update the data for an existing avatar. | avatarId(int, required) | json {""} | 200 OK: Avatar successfully updated (JSON object). <br> 404 Not Found: Avatar not found. <br> 400 Bad Request: Invalid data in the request. | Yes
| /api/avatars/deleteavatar/{avatarId} | DELETE | Deletes an existing avatar. | avatarId(int, required) | None | 204 No content: Avatar successfully deleted. <br> 404 Not found: Avatar not found. | Yes

## _4.3. Achievements Microservice_

| Endpoint | Method | Description | Parameters | Body Request | Response | Bearer Token |
|----------|--------|-------------|------------|--------------|----------|--------------|
| /api/achievements/getachievements | GET | Retrieves a list for all existing achievements. | None | None | 200 OK: List of achievements (JSON array). | Yes
| /api/achievements/getachievements/{userId} | GET | Retrieves the achievements by user id. | id (int, required) | None | 200 OK: Achievements details (JSON object). <br> 404 Not Found: Achievements not found. | Yes
| /api/achievements/saveachievement/{userId}/{achievementId} | POST | Set a new achievement. | id(int, required)<br> achievementId(int, required) | json {""} | 201 Created: Achievement successfully created (JSON object). <br> 400 Bad Request: Invalid data in the request. | Yes

## _4.4. Interactions Microservice_

| Endpoint | Method | Description | Parameters | Body Request | Response | Bearer Token |
|----------|--------|-------------|------------|--------------|----------|--------------|
| /api/interactions/getinteractions/{userId}/{date} | GET | Retrieves a list of interactions between specific user id and his avatar. | userId(int, required)<br>date(datetime, required) | None | 200 OK: List of interactions (JSON array). | Yes 
| /api/interactions/{userId}/{interactionTypeId}/{date} | GET |Retrieves a list of interactions between specific user id and his avatar by interaction type. | userId(int, required) <br>dateTime(datetime, required)<br>interactionType(int, required) | json {""} | 201 Created: Interaction successfully created (JSON object).<br> 400 Bad Request: Invalid data in the request. | Yes
| /api/interactions/saveuserinteraction | POST | Save a new interaction between an user and his avatar. | userId(int, required)<br>interactionType(int, required) | json {""} | 201 Created: Interaction successfully created (JSON object).<br> 400 Bad Request: Invalid data in the request. | Yes

## _4.5. Activities Microservice_

| Endpoint | Method | Description | Parameters | Body Request | Response | Bearer Token |
|----------|--------|-------------|------------|--------------|----------|--------------|
| /api/activities/getactivities/{userId}/{date} | GET | Retrieves a list of all activities by user id and date. | id(int, required)<br> date(datetime, required) | None | 200 OK: Activities details (JSON object). <br> 404 Not Found: Activities not found. | Yes
| /api/activities/saveactivity/{userId} | POST | Set a new activity. | userId(int, required)| json {""} | 201 Created: Activity successfully created (JSON object). <br> 400 Bad Request: Invalid data in the request. | Yes
| /api/activities/updateactivity/{userId}/{activityId} | PUT | Update an activity for specific user. | activityId(int, required) | json {""} | 200 OK: Activity successfully updated (JSON object). <br> 404 Not Found: Activity not found. <br> 400 Bad Request: Invalid data in the request. | Yes
| /api/activities/deleteactivity/{userId}/{activityId} | DELETE | Deletes an activity for specific user. | activityId(int, required) | None | 204 No content: Activity successfully deleted. <br> 404 Not found: Activity not found. | Yes

## _4.6. AI Love Microservice_

| Endpoint | Method | Description | Parameters | Body Request | Response | Bearer Token |
|----------|--------|-------------|------------|--------------|----------|--------------|
| /api/ailove/sendmessage | POST | Request a LLM response from GPT model based on user input. | None | json {""} | 201 Created: Response successfully created (JSON object). <br> 400 Bad Request: Invalid data in the request. | Yes
