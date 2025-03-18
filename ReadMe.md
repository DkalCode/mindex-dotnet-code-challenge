
# Mindex Coding Challenge


## Authors

- [@DkalCode](https://www.github.com/DkalCode)


## Run Locally

Clone the project

```bash
  git clone https://github.com/DkalCode/mindex-dotnet-code-challenge
```

Go to the project directory

```bash
  cd mindex-dotnet-code-challenge
```

Run the project

```bash
  dotnet run
```


## API Reference

#### Get an employee by id.

```http
  GET localhost:8080/api/employee/{id}
```

| Slug | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**. An Employee Id |

#### Creates an employee.

```http
  POST localhost:8080/api/employee
```

| Payload | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Employee` | `Employee` | **Required**. See Schema |

#### Updates an employee.

```http
  PUT localhost:8080/api/employee
```

| Payload | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Employee` | `Employee` | **Required**. See Schema |

#### Get Reporting Stats on an Employee.

```http
  GET localhost:8080/api/reporting/{id}
```

| Slug | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**. An Employee Id |

#### Gets a employee's compensation.

```http
  GET localhost:8080/api/compensation/{id}
```

| Slug | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**. An Employee Id |

#### Creates a compensation for an employee

```http
  POST localhost:8080/api/compensation/{id}
```

| Payload | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Employee` | `Employee` | **Required**. See Schema |

## Employee Schema

```json
{
  "type":"Employee",
  "properties": {
    "employeeId": {
      "type": "string"
    },
    "firstName": {
      "type": "string"
    },
    "lastName": {
          "type": "string"
    },
    "position": {
          "type": "string"
    },
    "department": {
          "type": "string"
    },
    "directReports": {
      "type": "array",
      "items" : "string"
    }
  }
}
```

