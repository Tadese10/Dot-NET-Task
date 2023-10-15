Project Name
# Dot-NET-Task

For this project, I leveraged on Onion architecture which has different layers.

Domain Layer
The heart of Onion Architecture, the Domain Layer, encapsulates the core business logic of the application, including entities, value objects, business rules, and interfaces that outline contracts with other layers.

Application Layer
The Application Layer serves as a bridge between the Presentation and Domain layers. It houses application services that dictate application flow and map data between the Domain and Presentation layers.

Infrastructure Layer
The Infrastructure Layer encompasses all technical components of the application, such as data storage, logging, messaging, and more. It also implements the interfaces defined in the Domain Layer.

Persistence Layer
Handling all data storage and retrieval operations, the Persistence Layer communicates directly with the underlying database or other persistent storage mechanisms. This layer encapsulates and implements the data access logic, safeguarding data consistency and integrity. It interacts with the Domain Layer via the defined interfaces, translating between the language of the domain and that of the database.

Presentation Layer
The Presentation layer is responsible for presenting the application output to the users, like web pages, APIs, and user interfaces. It communicates with the Application layer to get the information from the Domain layer.