# API REST

## Cheil Backend

## General

- Method that returns a list of hotels, full list without filters
- Method to list hotels filtering by: Category, by ratings
-  Method that returns the hotels ordered by Price (from highest to lowest and / or
vice versa).
- Methods for all CRUD hotels.

# Requirements

- Allowed editors: Visual Studio Code, Visual Studio.
- API must be deploy in .NET CORE 3.1
- Database must be MySQL or MariaDB.



### Step by Step

1. Clone Repository

https://github.com/julianamonr03/Api_hotel.git

3. Create Database MySQL

```
CREATE DATABASE `hotel` ;

CREATE TABLE `hotel`.`new_table` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Category_hotel` VARCHAR(45) NOT NULL,
  `Price` INT NOT NULL,
  `Client_calif` VARCHAR(45) NOT NULL,
  `Photo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE);


INSERT INTO `hotel`.`specifications` (`Name`, `Category_hotel`, `Price`, `Client_calif`, `Photo`) VALUES ('Hotel Hilton', '5 Stars', '250000', '4.8 Excellent service and place.', 'test.png');

INSERT INTO `hotel`.`specifications` (`Name`, `Category_hotel`, `Price`, `Client_calif`, `Photo`) VALUES ('Hotel Villa del mar', '4 Stars', '190000', '4 Great room service and a lot of events for enjoy.', 'skybar.jpeg');

```

**Important**


In the file appsettings.json - Line 3

You have to change to your Database configuration
```
Data Source=<YOURSERVER>;Initial Catalog=<YOURDATABASE>;User Id=<YOURID>;password=<YOURPASSWORD>
```

2. Project Initialization Inside the folder **Hotel_api**

> dotnet run



## **Endpoints**
​
| HTTP Method | Descripcion |
| ------ | ------ |
| GET | Return a Json with all Hotel values. |
| POST | Create a new instance for Hotel. (Name, price, category, client calification) |
| UPDATE | Update Hotel attributes with id. |
| DELETE | Delete all attributes from a specific id.|


<!-- Contact info -->

## Author
- **Juliana Monroy** <img src="https://github.com/deut-erium/deut-erium/blob/master/assets/gandalf_parrot.gif" width="30px"/>

[<img align="center" alt="contact | Twitter" width="22px" src="https://github.com/deut-erium/deut-erium/blob/master/assets/twitter.svg" />](https://twitter.com/julianamonroy03)
[<img align="center" alt="contact | LinkedIn" width="22px" src="https://github.com/deut-erium/deut-erium/blob/master/assets/linkedin.svg" />](https://www.linkedin.com/in/juliana-monroy-perez/)
[<img align="center" alt="contact | Instagram" width="22px" src="https://github.com/hargun79/hargun79/blob/master/Assets/Instagram.svg" />](https://www.instagram.com/julianamonr03/)
