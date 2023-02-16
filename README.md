# Lit Fibre Software Engineer C# Exercise

Please fork this repo and push your workings to your own fork.

### You'll need
Your preferred Git client.
Visual Studio 2022 w/ .NET 6.

Optionally:
Curl/Postman/Insomnia - the project includes the Swagger frontend so not strictly necessary.

### Guidelines
1. Try and keep your work confined to the three projects we've provided in the solution. Best practices may dictate that there should be more separation but for the sake of the exercise, we'd like to keep it simple.
2. Complete as much of the exercise as you can, as well as you can, within the assigned timeframe, but don't worry if you feel at the end that you could have done more. We're happy to discuss your ideas with you afterwards.

## The exercise
### Task 1
Implement the `IMemoryDatabase` interface for the `Order` model. As the interface name implies, this should be a simple in-memory DB, 3rd party libraries shouldn't be necessary here. We've provided some seed data in `orders.json` that you can use to initialize the DB.

### Task 2
Implement a number of RESTful endpoints in the `LitFibre.Interviews.SoftwareEngineer.Controllers.OrderController` API controller that interact with the order database. The endpoints should be the following:
1. Read all orders.
2. Read an order by ID.
3. Add an order.
4. Delete an order.
5. Update an order.
6. Read all orders that contain a specified product code.
7. Read all orders that were placed after a specified date.

You don't need to create a frontend to consume these endpoints, we will test them with Swagger/Postman.

### If you finish early
Feel free to expand on the API, database and models if you feel it will help demonstrate your knowledge of C#, data structures, web APIs, dependency injection, or whatever you'd like to show off. This is entirely optional.

### GLHF!
