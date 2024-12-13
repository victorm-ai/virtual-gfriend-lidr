# 2. System Architecture

## _2.1. Architecture diagram_

- ### Chosen architecture
    - Microservices.
    
- ### Architecture representation
    - C4 Model.

- ### Tool 
    - Draw.io

## _C4 Model - Legend of Graphics_

![Alt Text](/02%20Resources/C4%20Legend.png)

## _C4 Model - System Context_

![Alt Text](/02%20Resources/C4%20Model%20-%20%20Level%2001%20System%20Context.png)

## _C4 Model - Container Context_

![Alt Text](/02%20Resources/C4%20Model%20-%20%20Level%2002%20Container%20Context.png)

## _C4 Model - Component Context_

![Alt Text](/02%20Resources/C4%20Model%20-%20%20Level%2003%20Component%20Context.png)

## _2.2. Description of main components_

### API Gateway 

- **Azure API Management**
    - Acts as a gateway for all client requests.
    - Performs API management, authentication, authorisation and traffic control.

### Data Storage     

- **Azure SQL Database** 
    - Relational database for storing structured information.

- **Azure Cosmos DB** 
    - NoSQL database for storing unstructured and semi-structured data.

- **Azure Blob Storage** 
    - Storage of media files, unique content and other binary data.

### Messaging Channel
- **Azure Service Bus:** Reliable messaging between microservices for asynchronous communication.

### Authentication and Authorization
- **Azure Active Directory B2C** 
    - User authentication and identity management.
- **Azure Key Vault** 
    - Secure storage of secrets, keys and certificates.

## _2.3. High-level description of the project and file structure_

### Solution Level

For any Microservice we use the same organizaion of files and folders, let's take the Users Microservice it would be like this:

    /SolutionRoot/
    ├── UsersMicroservice/
    ├── TestsUsersMicroservice/
    └── README.md

### Internal Microservice Structure

    /Microservice/
    ├── Controllers/
    ├── Models/
    ├── DTOs/
    ├── Services/
    ├── Interfaces/
    ├── Data/
    │   ├── Entities/
    │   ├── Migrations/
    │   └── Repositories/
    ├── Configurations/
    ├── Middleware/
    ├── appsettings.json
    ├── UsersMicroservice.csproj
    └── Program.cs

### Description of Folders

**1. Controllers**

Contains the API controllers. Example:

    - UsersController.cs

**2. Models**

Defines the classes that represent the domain entities. Example:

    - User.cs

**3. DTOs**

Stores Data Transfer Objects to define how data is sent or received. Example:

    - UserDTO.cs
    - CreateUserRequest.cs

**4. Services**

Includes the services that contain the business logic. Example:

    - UserService.cs

**5. Interfaces**

Defines the interfaces that implement the services or repositories. Example:

    - IUserService.cs

**6. Data**

Manage access to the database.

    - Entities/: Defines the classes that represent database tables.
    - Migrations/: Contains the migrations for relational databases.
    - Repositories/: Implements the repositories for data access, for example: UserRepository.cs

**7. Configurations**

Microservice specific configurations, such as entity mappings, authentication options or integration with other services.

**8. Middleware**

Custom middleware to handle exceptions, authentication or logging.

**9. Testing**

Microservice-specific unit and embedded tests. Example:

    - UserServiceTests.cs

## _2.4. Infrastructure and deployment_

The deployment is done over Microsoft Azure and the order of the services is done as follows:

    1) Creation and configuration of Azure AD B2C service.
    2) Creation and configuration of the Azure API Gateway service.
    3) Creation and configuration of the Azure App services.
    4) Creation and configuration of the Azure SQL Azure service.
    5) Creation and configuration of the Azure Cosmos DB service.
    6) Creation and configuration of the Azure Blob Storage service.
    7) Creation and configuration of the Azure Key Vault service.

## _2.5. Security_

### Security Mechanisms at Code Level

- **Authentication and Authorisation**
    - JWT token-based authentication: Implement authentication with Azure AD B2C.

    - Roles and permissions: Role-based control (RBAC) to define what users can do in each microservice.

    - CORS (Cross-Origin Resource Sharing): To prevent unauthorised access from untrusted sources.

- **Input Validation**

    - Sanitisation: Clean entries to prevent SQL injections, XSS, or command injections.

    - Strict rules: Client-side and server-side validation.

- **Secure Communication**

    - Encryption in transit: Communications between microservices must use HTTPS/TLS.

- **Logging and Monitoring**

    - Audit logging: Detailed log of critical events such as access, errors, and configuration changes.

    - Real-time alerts: To detect anomalous behaviour.

### Security Mechanisms at the Cloud Infrastructure Level

- **Identity and Access Management**

    - RBAC in Azure: Restrict access to resources according to roles and needs.

    - Managed identities: Managed identities to authenticate microservices with Azure resources without exposing secrets.

 - **Storage Security**

    - Encryption at rest: Enable automatic encryption on all databases (Azure SQL, Cosmos DB, Blob Storage).

    - Restricted Access: Configure allowed IPs and disable direct public access to resources such as Azure Storage.

- **API Protection**

    - API Management: Azure API Management to implement quotas, authentication, and traffic analysis.

    - Rate limiting and policies: Limit requests per client to protect against abuse.

- **Secrecy Management**

    - Azure Key Vault: Store keys, certificates, and passwords in a secure vault.
    - Periodic rotation: Automate rotation of sensitive secrets.

- **Monitoring and Response**

    - Azure Monitor: Monitoring to collect performance and activity metrics.

    | Component | Azure Tool |
    |-----------|------------|
    | Authentication | Azure AD / Azure AD B2C |
    | Data Encryption | Azure Key Vault | 
    | API Protection  | Azure API Management | 
    | Monitoring  | Azure Monitor | 
    | Access Control | Access Management Role-Based  (RBAC)

## _2.6. Testing_

### Solution Structure 

    /Solution/
    ├── Microservice Project/
    ├── NUnit Project/

- The software tests are essentially unit testing with the NUnit framework.
- Each Microservice has a separate unit testing project.
- The intention is that before any deployment to the cloud, all unit tests must pass.