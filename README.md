# ODataHeroes - An ASP.NET Core boilerplate to demonstrate OData Integration

ODataHeroes is a boilerplate solution, built to demonstrate OData API implementation in an ASP.NET Core (.NET 5) API

# What is OData?

OData stands for Open Data. It is an ISO/IEC approved, OASIS standard that defines a set of best practices for building and consuming RESTful APIs. It can help enhance an API to have extensive capabilities by itself, while we don't need to worry much about the data processing and response transformations as a whole and instead concentrate only on building the business logic for the API. OData adds one layer over the API treating the endpoint itself as a resource and adds the transformation capabilities via the URL.

One can integrate the prowess of OData into an ASP.NET Core API by installing the OData nuget available for .NET Core and get started.

# Getting Started

To get started, follow the below steps:

1. Install .NET 5 SDK
2. Clone the Solution into your Local Directory
3. Navigate to the Cloned directory and run the solution

# Testing the Solution

The solution contains necessary seeding code and uses SQLite database, so once the solution starts you'd already have data ready.

Once the solution is running, open a browser and try the below URLs to see OData in action. 

# To view the Metadata:

```
https://localhost:5001/odata/$metadata
```

# Simple Get:

```
https://localhost:5001/odata/heroes
```

# Get with OData Queries:

```
https://localhost:5001/odata/heroes?$filter=Id gt 100&$select=Id,Name&$skip=100&$top=100
```

# Get Count:

```
https://localhost:5001/odata/heroes/$count
```

# Get by Id:

```
https://localhost:5001/odata/heroes(1500)
```

The complete explanation of this sample is available at:

https://referbruv.com/blog/posts/working-with-odata-integrating-an-existing-aspnet-core-3x-api

Leave a Star if you find the solution useful. For more detailed articles and how-to guides, visit https://referbruv.com

<a href="https://www.buymeacoffee.com/referbruv" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>
