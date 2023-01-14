# Call Work API

- [Call Work API](#call-work-api)
  - [Create Call Work](#create-call-work)
    - [Create Call Request](#create-call-request)
    - [Create Call Response](#create-call-response)
  - [Get Call](#get-call)
    - [Get Call Request](#get-call-request)
    - [Get Call Response](#get-call-response)
  - [Update Call](#update-call)
    - [Update Call Request](#update-call-request)
    - [Update Call Response](#update-call-response)
  - [Delete Call](#delete-call)
    - [Delete Call Request](#delete-call-request)
    - [Delete Call Response](#delete-call-response)

## Create Call Work

### Create Call Request

```js
POST /callwork
```

```json
{
    "title": "Let's study building a RESTful API!",
    "description": "How design patterns can help us build scalable and testable software!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "subjects": [
        "Design Patterns",
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
    "title": "Let's study building a RESTful API!",
    "description": "How design patterns can help us build scalable and testable software!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-08T11:00:00",
    "subjects": [
        "Design Patterns",
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
    "title": "Let's study building a RESTful API!",
    "description": "How design patterns can help us build scalable and testable software!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "subjects": [
        "Design Patterns",
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
    "title": "Let's study building a RESTful API!",
    "description": "How can design patterns make our code better? Let's find out together!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "subjects": [
        "Design Patterns",
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

## Delete Call

### Delete Call Request

```js
DELETE /callwork/{{id}}
```

### Delete Call Response

```js
204 No Content
```
