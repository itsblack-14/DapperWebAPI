Post Request / Response
----------------------------------------
```json
{
  "name": "John Doe",
  "email": "john.doe@example.com",
  "dateOfBirth": "1990-05-15T00:00:00.000Z",
  "address": "123 Main Street, Springfield, USA"
}
```
```json
{
  "statusCodes": 200,
  "message": "Success",
  "result": null
}
```

Get Response
----------------------------------------
```json
{
  "statusCodes": 200,
  "message": "Success",
  "result": [
    {
      "id": "71a7722d-c26b-47e2-8557-08161e1a9635",
      "name": "John Doe",
      "email": "john.doe@example.com",
      "dateOfBirth": "1990-05-15T00:00:00",
      "address": "123 Main Street, Springfield, USA"
    },
    {
      "id": "40db89f2-668b-4dde-b84b-3d63ba8e61f8",
      "name": "Zin Ko",
      "email": "john.doe@example.com",
      "dateOfBirth": "1990-05-15T00:00:00",
      "address": "123 Main Street, Springfield, USA"
    }
  ]
}
```

Get{id} Response
----------------------------------------
```json
{
  "statusCodes": 200,
  "message": "Success",
  "result": {
    "id": "71a7722d-c26b-47e2-8557-08161e1a9635",
    "name": "John Doe",
    "email": "john.doe@example.com",
    "dateOfBirth": "1990-05-15T00:00:00",
    "address": "123 Main Street, Springfield, USA"
  }
}
```

Put{id} Request / Response
----------------------------------------
```json
{
  "id": "71a7722d-c26b-47e2-8557-08161e1a9635",
  "name": "John Doe Update",
  "email": "john.doe@example.com",
  "dateOfBirth": "1990-05-15T00:00:00.000Z",
  "address": "123 Main Street, Springfield, USA"
}
```
```json
{
  "statusCodes": 200,
  "message": "Success",
  "result": null
}
```

Delete{id} Response
----------------------------------------
```json
{
  "statusCodes": 200,
  "message": "Success",
  "result": null
}
```
