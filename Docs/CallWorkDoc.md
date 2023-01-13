# Call Work API

- [Call Work API](#buber-callwork-api)
  - [Create Call Work](#create-callwork)
    - [Create Call Work Request](#create-callwork-request)
    - [Create Call Work Response](#create-callwork-response)
  - [Get Call Work](#get-callwork)
    - [Get Call Work Request](#get-callwork-request)
    - [Get Call Work Response](#get-callwork-response)
  - [Update Call Work](#update-callwork)
    - [Update Call Work Request](#update-callwork-request)
    - [Update Call Work Response](#update-callwork-response)
  - [Delete Call Work](#delete-callwork)
    - [Delete Call Work Request](#delete-callwork-request)
    - [Delete Call Work Response](#delete-callwork-response)

## Create Call Work

### Create Call Request

```js
POST /callwork
```

```json
{
    "callwork": "Let's study building a RESTful API!",
    "description": "How design patterns can help us build scalable and testable software!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "subjects": [
        "Desing Patterns",
        "Unit Test",
        "Error Handling",
        "REST"
    ],
    "technologies": [
        "AspNet Core",
        "Docker",
        "Entity Framework"
    ]
}
```

### Create Call Response

```js
201 Created
```

```yml
Location: {{host}}/calls/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "callwork": "Let's study building a RESTful API!",
    "description": "How design patterns can help us build scalable and testable software!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "subjects": [
        "Desing Patterns",
        "Unit Test",
        "Error Handling",
        "REST"
    ],
    "technologies": [
        "AspNet Core",
        "Docker",
        "Entity Framework"
    ]
}
```

## Get Call 

### Get Call Request

```js
GET /calls/{{id}}
```

### Get Call Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "callwork": "Let's study building a RESTful API!",
    "description": "How design patterns can help us build scalable and testable software!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "subjects": [
        "Desing Patterns",
        "Unit Test",
        "Error Handling",
        "REST"
    ],
    "technologies": [
        "AspNet Core",
        "Docker",
        "Entity Framework"
    ]
}
```

## Update Call

### Update Call Request

```js
PUT /calls/{{id}}
```

```json
{
    "callwork": "Let's study building a RESTful API!",
    "description": "How can design patterns make our code better? Let's find out together!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "subjects": [
        "Desing Patterns",
        "Unit Test",
        "Error Handling",
        "REST"
    ],
    "technologies": [
        "AspNet Core",
        "Docker",
        "Entity Framework"
    ]
}
```

### Update Call Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

## Delete Breakfast

### Delete Breakfast Request

```js
DELETE /breakfasts/{{id}}
```

### Delete Breakfast Response

```js
204 No Content
```
