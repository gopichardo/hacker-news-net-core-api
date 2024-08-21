# API
This project contains an API to get the Best Stories from Hacker News.


## Start the API
1. Enter to the root folder
   ```shell
   cd hacker-news-net-core-api
   ```
2. Restore all the projects executing this command 
   ```shell
   dotnet restore
   ```
3. Start the API executing this command 
   ```shell
   dotnet run --project Presentation/WebApi/
   ```
4. API will be available on `http://localhost:5164/`
5. You can find swagger documentation on `http://localhost:5164/swagger/index.html`


## Available Endpoints
### Best Stories
**Method**: `GET`\
**Path**: `/api/besthistories/{n}`\
**Parameters**: `n` type=int, optional, default value=5\

**Example**: `http://localhost:5164/api/besthistories/2`
```shell
curl -X 'GET' \
  'http://localhost:5164/api/besthistories/2' \
  -H 'accept: text/plain'
```
**Code** 200\
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
