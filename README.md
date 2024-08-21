# Hacker News API

This project provides a RESTful API to retrieve the top stories from Hacker News. It's built using .NET Core and follows clean architecture principles for maintainability and testability.

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/hacker-news-net-core-api.git
2. **Navigate to the project directory:**
   ```shell
   cd hacker-news-net-core-api
   ```
3. **Restore dependencies:**
   ```shell
   dotnet restore
   ```
4. **Run the API:**
   ```shell
   dotnet run --project Presentation/WebApi/
   ```
5. Access the API:
   1. The API will be available at http://localhost:5164/.
   2. You can find the Swagger documentation at http://localhost:5164/swagger/index.html.


## Available Endpoints
### Best Stories
**Method**: `GET`\
**Path**: `/api/besthistories/{n}`\
**Parameters**: `n` : (optional, integer, default: 5) The number of best stories to retrieve.\
**Example**: `http://localhost:5164/api/besthistories/2`
```curl
curl -X 'GET' \
  'http://localhost:5164/api/besthistories/2' \
  -H 'accept: text/plain'
```
**Response body**
```json
[
  {
    "title": "Mpv – A free, open-source, and cross-platform media player",
    "uri": null,
    "postedBy": null,
    "time": "1723920996",
    "score": 1079,
    "commentCount": 0
  },
  {
    "title": "Kim Dotcom's extradition to the U.S. given green light by New Zealand",
    "uri": null,
    "postedBy": null,
    "time": "1723723550",
    "score": 851,
    "commentCount": 0
  },
]
```
## Application Architecture
This API is built using a clean architecture approach, separating concerns into distinct layers:

- **Presentation Layer**: Handles API requests and responses, using ASP.NET Core Web API.
- **Application Layer**: Contains business logic and orchestrates interactions between the domain and infrastructure layers.
- **Domain Layer**: Defines the core business rules and entities.
- **Infrastructure Layer**: Provides access to external resources like databases, APIs, and caching mechanisms.

## Dependency Injection
The API utilizes dependency injection to manage the creation and lifetime of objects. This promotes loose coupling and testability.

- **Services**: Services are registered in the `Program.cs` file, making them available for injection into other classes.
- **Interfaces**: Interfaces are used to define contracts for services, allowing for flexibility and testability.

## Cache Mechanism
The API uses `Microsoft.Extensions.Caching.Memory` to cache data from the Hacker News API. This improves performance by reducing the number of requests to the external API.

- **Caching Strategy**: The API caches the list of best story IDs and individual story details.
- **Expiration**: Cached data has a configurable expiration time to ensure freshness. Default value is 5 minutes and its possible to customize it, just modify the `CacheExpirationTimeMinutes` key in the `appsettings.json` file.

## Technologies Used
- **.NET Core**: The foundation of the API.
- **ASP.NET Core Web API**: Used to build the RESTful API.
- **Swagger**: Provides interactive documentation for the API.
- **Microsoft.Extensions.Caching.Memory**: Used for in-memory caching.
- **HttpClient**: Used to make requests to the Hacker News API.
- **System.Text.Json** and **Newtonsoft.Json**: Used for JSON serialization and deserialization.

## Contributing
Contributions are welcome! Please open an issue or submit a pull request.

## License
This project is licensed under the MIT License.