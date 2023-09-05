# ProductApi
 managment products


Candidate Architecture (Clean Architecture and DDD)

![image](https://user-images.githubusercontent.com/10835457/235828011-0a51ab4d-2d2e-4dca-b8d2-a92291df23c4.png)

The application was configured in docker containers to have easy access to its use and deployment it.

![image](https://github.com/alejolesor/ProductApi/assets/10835457/3b035f45-f7e6-4feb-bc59-fa802a8c07b6)


container: postgres_image   (database)
container: productManagement.Api  (api)

To run the application you can follow the following steps:

![image](https://github.com/alejolesor/ProductApi/assets/10835457/8f0b7b73-b774-47e6-82eb-01aa49127212)


![image](https://github.com/alejolesor/ProductApi/assets/10835457/fdc56871-1e05-4c50-8fb7-43a8c03eb5ef)


1) In the root of the project execute the following commands:
   
   a)` docker-compose build`
   b) `docker-compose up -d`
