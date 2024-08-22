# Hacker News API

This project provides a **RESTful API** to retrieve the top stories from **Hacker News API**. It was Was built using **.NET Core** and follows **Clean Architecture** principles for **maintainability** and **testability**.

## Assumptions
- First, the Application requests the endpoint https://hacker-news.firebaseio.com/v0/beststories.json to get the list  of IDs, after that, the API iterates each **Id** to get the **Story details** calling the https://hacker-news.firebaseio.com/v0/item/{id}.json, 
- To transforms the `time` from **unix** to the **ISO UTC Offset** form, I'm using the format `yyyy-MM-ddTHH:mm:sszzz`.
- To define the `commentCount` the API counts the items of teh `kids` array.
- To get only the **n** Best Stories, the API uses the `Take()` **Linq** method.
- To sort the Best Stories list by `score` descending, the API uses `OrderByDescending()` **Linq** method.
- To avoid overloading the **Hacker News API**, I implemented a **Cache Mechanism** that **stores in memory** the information about the Best Stories with a time expiration of **n** minutes. After the **cache time expiration** has expired, the following request will call the  **Hacker News API** and store the values in the cache again.

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
- **Expiration**: Cached data has a configurable expiration time to ensure freshness. The default value is 5 minutes, and it's possible to customize it, just modify the `CacheExpirationTimeMinutes` key in the `appsettings.json` file.

## Technologies Used
- **.NET Core**: The foundation of the API.
- **ASP.NET Core Web API**: Used to build the RESTful API.
- **Swagger**: Provides interactive documentation for the API.
- **Microsoft.Extensions.Caching.Memory**: Used for in-memory caching.
- **HttpClient**: Used to make requests to the Hacker News API.
- **Newtonsoft.Json**: Used for JSON serialization and deserialization.

## Custom Settings
- **BestStoryIdsCacheName**: (`required`, `string`, `default: "BestStoryIds"`) Cache name for the list of best story IDs.
- **CacheExpirationTimeMinutes**: (`required`, `double`, `default: 5.0`) Expiration time for cached data in minutes.
- **DateFormat**: (`required`, `string`, `default: "yyyy-MM-ddTHH:mm:sszzz"`) Date format
```json
{
    "BestStoryIdsCacheName": "BestStoryIds",
    "CacheExpirationTimeMinutes": 5.0,
    "DateFormat": "yyyy-MM-ddTHH:mm:sszzz"
  }
```

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
**Path**: `/api/beststories/{n}`\
**Parameters**: `n` : (`optional`, `integer`, `default: 5`) The number of best stories to retrieve.\
**Example**: `http://localhost:5164/api/beststories/2`
```curl
curl -X 'GET' \
  'http://localhost:5164/api/beststories/2' \
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

## Contributing
Contributions are welcome! Please open an issue or submit a pull request.

## License
This project is licensed under the MIT License.

## Author
Mail: [gopichardoces@gmail.com](gopichardoces@gmail.com) \
Linkedin: [gopichardoces](https://www.linkedin.com/in/gopichardoces/)\
GitHub: [gopichardo](https://github.com/gopichardo)