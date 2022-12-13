
# Appointment API


## Autores

- [@Abnoan Muniz](https://github.com/Abnoan)


## Running locally

This zip file attached


Install the dependencies

```bash
  dotnet restore
```

Start Application

```bash
  dotnet run
```


## Api Documentation

#### Get a paginated list of all appointments booked. 

```http
  GET /api/appointments
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :---------------------------------- |
| `query` | `string` | Any string to filter Animal Type or Appointment Type  |
| `page` | `int` |  Number of the page |


#### Return an appointment

```http
  GET /api/appointments/${id}
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. Id of an Appointment |

#### Create an Appointment

```http
  POST /api/appointments/
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :------------------------------------------ |
| `petName`      | `string` | **Mandatory**. Name of the pet |
| `appointmentAt`      | `dateTime` | **Mandatory**. Date to schedule |
| `animalType`      | `int` | **Mandatory**. Type of Animal : 0 = Dog, 1 = Cat, 2 = Bird, 3= Other |
| `animalDescription`      | `string` | Optional description of animal |
| `appointmentType`      | `int` | **Mandatory**. Type of appointment :  0 = Wellness Visit, 1 = Surgery, 2 = Grooming, 3 = Dental, 4 = Other.|
| `appointmentDescription`      | `string` | Optional description of appointment |

#### Uptade an appointment

```http
  PUT /api/appointments/${id}
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. Id of an Appointment |
| `petName`      | `string` | Name of the pet |
| `appointmentAt`      | `dateTime` | Date to schedule |
| `animalType`      | `int` | Type of Animal : 0 = Dog, 1 = Cat, 2 = Bird, 3= Other |
| `animalDescription`      | `string` | Description of animal |
| `appointmentType`      | `int` | Type of appointment :  0 = Wellness Visit, 1 = Surgery, 2 = Grooming, 3 = Dental, 4 = Other.|
| `appointmentDescription`      | `string` | Description of appointment |

#### Cancel an appointment

```http
  DELETE /api/appointments/${id}
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. Id of an Appointment |

## Improvements

For the unit tests, I only created a few basic tests, in the real world, we will need to increase de code coverage, with more unit tests, integration tests, and more.

