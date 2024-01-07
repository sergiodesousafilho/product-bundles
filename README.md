# product-bundles

This project aims to demonstrate how to create a recursive structure that describes the components needed for assembling products.


### How to run the project locally

- Set up a connection string with valid credentials for a local SQL Server database in the appsettings.Development.json file located at the root of the project.
- If the EF Core CLI is not installed on your machine, navigate through the terminal to the project folder and execute the following command:
    > `dotnet tool install --global dotnet-ef`
- To create or update the database, run the following command:
    > `dotnet ef database update`


### Example Data

- I haven't created a product registration screen yet. To populate the project with products, you must manually register the products in the database.
I am also including a script to insert sample data, in case you prefer. The insert-sample-data.sql file is located in the scripts folder at the root of the repository.
- The logic used in the registration screen for new bundles allows only the creation of bundles containing child bundles that are already registered in the database.
So, for the example of the bicycle, it would be necessary to first register the bundle of the bicycle wheel before being able to create the bundle of the bicycle using the wheel bundle.


### Challenge Solution

- The solution for determining how many bundles could be constructed with the products registered in the database is found at the bottom of the Home screen, under the title "Information."
   This area displays a table with the maximum quantity of each type of bundle that could be built with the currently available products.
- This answer does not include logic to build different root bundles (P0) simultaneously.
   Therefore, if there are bundles that use the same products as other bundles, it should be noted that this result is displaying the total possible bundles to be built if all inventory products were used for that specific root bundle.
- The requested diagram is in the diagrams folder at the root of the repository.
- The Amount column in the Product table indicates how many items of a product are in stock.
- The Amount column in the BundleProduct table indicates how many items of a product are needed to build a bundle.
- The Amount column in the BundleRelation table indicates how many child bundles are needed to create a parent bundle.


### Considerations

There are many possible improvements in this project, for example:

- I used lazy loading to speed up development, but it is not a good practice for a production project.
- I used a very simplified version of DDD to organize the project. It could include more layers, dependency inversion with interfaces, etc.
- Queries in a loop would certainly be a problem in real projects and could be avoided in various ways, such as:
  - Loading all objects into memory first with a query for everything or with eager loading if the database is small.
  - Performing recursive SQL queries, also only if the amount of data is not too large.
  - Including a NoSQL database with pre-populated data containing the entire hierarchy of bundles. This would require an ETL project to periodically feed the NoSQL database.
  - Among other possible approaches. All of this would depend on specific details of a real project.


### Troubleshooting

- If Google Chrome blocks the browser's access to the system due to the SSL certificate, you can type "thisisunsafe" on the keyboard with the browser in the foreground to disable this certificate block.