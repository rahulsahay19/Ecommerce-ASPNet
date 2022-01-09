# Ecommerce project using .Net Core and many other components
Ecommerce Microservice soln using .Net

## Still under development

**Overall Architecture inspired from eshopOnContainers** 
![microservices_Overall](https://user-images.githubusercontent.com/3886381/148683755-bbfa3257-d1cb-4f25-b1c8-1a85786aaffe.png)

**Docker Up** 
![Docker_Up](https://user-images.githubusercontent.com/3886381/148684115-a2848fbd-e594-4a26-bfc6-abc80d24aa08.png)

**Portainer Page (Container Management)** 
![Portainer_Page](https://user-images.githubusercontent.com/3886381/148683680-ab6b8b39-e1a8-4bd9-ae34-ea0e20aa89f2.png)

**Kibana Page (Distributed Logging)** 
![Kibana_Page](https://user-images.githubusercontent.com/3886381/148637593-f4e2c0d7-2769-4066-821d-e49f3eca17ec.png)

**Health Check (Using WatchDog)** 
![Watch_Dog](https://user-images.githubusercontent.com/3886381/148683595-48f4af3d-0f03-480a-ad6d-f13946fedda2.png)
It involves different microservices such as
**Catalog, Basket, Discount** and **Ordering** microservices with **NoSQL (MongoDB, Redis)** and **Relational databases (PostgreSQL, Sql Server)** 
with **RabbitMQ Event Driven Communication** as messaging architecture and gatway **Ocelot API Gateway**.

#### Catalog microservice which includes; 
* ASP.NET Core Web API application 
* REST API principles, CRUD operations
* **MongoDB database** connection and containerization
* Repository Pattern Implementation
* Swagger Open API implementation	

#### Basket microservice which includes;
* ASP.NET Web API application
* REST API principles, CRUD operations
* **Redis database** connection and containerization
* Consume Discount **Grpc Service** for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using **MassTransit and RabbitMQ**
  
#### Discount microservice which includes;
* ASP.NET **Grpc Server** application
* Build a Highly Performant **inter-service gRPC Communication** with Basket Microservice
* Exposing Grpc Services with creating **Protobuf messages**
* Using **Dapper for micro-orm implementation** to simplify data access and ensure high performance
* **PostgreSQL database** connection and containerization

#### Microservices Communication
* Sync inter-service **gRPC Communication**
* Async Microservices Communication with **RabbitMQ Message-Broker Service**
* Using **RabbitMQ Publish/Subscribe Topic** Exchange Model
* Using **MassTransit** for abstraction over RabbitMQ Message-Broker system
* Publishing BasketCheckout event queue from Basket microservices and Subscribing this event from Ordering microservices	
* Create **RabbitMQ EventBus.Messages library** and add references Microservices

#### Ordering Microservice
* Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices
* Developing **CQRS with using MediatR, FluentValidation and AutoMapper packages**
* Consuming **RabbitMQ** BasketCheckout event queue with using **MassTransit-RabbitMQ** Configuration
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup
	
#### API Gateway Ocelot Microservice
* Implement **API Gateways with Ocelot**
* Sample microservices/containers to reroute through the API Gateways
* Run multiple different **API Gateway/BFF** container types	
* The Gateway aggregation pattern in Shopping.Aggregator

#### Microservices Cross-Cutting Implementations
* Implementing **Centralized Distributed Logging with Elastic Stack (ELK); Elasticsearch, Logstash, Kibana and SeriLog** for Microservices
* Use the **HealthChecks** feature in back-end ASP.NET microservices
* Using **Watchdog** in separate service that can watch health and load across services, and report health about the microservices by querying with the HealthChecks

#### Microservices Resilience Implementations
* Making Microservices more **resilient Use IHttpClientFactory** to implement resilient HTTP requests
* Implement **Retry and Circuit Breaker patterns** with exponential backoff with IHttpClientFactory and **Polly policies**

#### Admin Monitoring
* Use **Portainer** for Container lightweight management UI which allows you to easily manage your different Docker environments
* **pgAdmin PostgreSQL Tools** feature rich Open Source administration and development platform for PostgreSQL

#### Docker Compose establishment with all microservices on docker;
* Containerization of microservices
* Containerization of databases
* Override Environment variables

## Run The Project
You will need the following tools:

* [Jet Brains Rider](https://www.jetbrains.com/rider/)
* [Visual Studio 2019 or later](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 5 or later](https://dotnet.microsoft.com/download/dotnet-core/5)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installing
Follow these steps to get your development environment set up: (Before Run Start the Docker Desktop)
1. Clone the repository
2. Make sure docker for dekstop is installed allot below config 
* **Memory: 4 GB**
* CPU: 2
3. Then, from root run docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d. This should print something like this

**Docker Up** 
![Docker_Up](https://user-images.githubusercontent.com/3886381/148684115-a2848fbd-e594-4a26-bfc6-abc80d24aa08.png)

4. You can now access **microservices** as shown below:

* **Catalog API -> http://localhost:9000/swagger/index.html**
* **Basket API -> http://localhost:9001/swagger/index.html**
* **Discount API -> http://localhost:9002/swagger/index.html**
* **Ordering API -> http://localhost:9004/swagger/index.html**
* **Shopping.Aggregator -> http://localhost:9005/swagger/index.html**
* **API Gateway -> http://localhost:9010/Catalog**
* **Rabbit Management Dashboard -> http://localhost:15672**   -- guest/guest
* **Portainer -> http://localhost:9090**   -- admin/admin1234
* **pgAdmin PostgreSQL -> http://localhost:5050**   -- admin@aspnetrun.com/admin1234
* **Elasticsearch -> http://localhost:9200**
* **Kibana -> http://localhost:5601**
* **StatusCheck -> http://localhost:9007**

* **Note:- In case localhost is not resolving the docker port on your local machine. Then, you can try host.docker.internal as well to resolve the issue. Although, I haven't faced any issue
on Macbook. For Mac, localhost can be substituted with docker.for.mac.localhost. But, for me it worked with localhost itself.

### Installing
UI, Identity Service and Kubernetes deployment part still pending.


