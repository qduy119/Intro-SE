# Intro-SE

## Authentication

**Register:** **POST** /register

```js
{
  "email": "string",
  "password": "string",
  "phoneNumber": "string",
  "fullName": "string",
  "avatar": "string",
  "gender": "string",
  "dateOfBirth": "2023-12-07T16:05:47.439Z"
}
```

**Login:** **POST** /authenticate

```js
{
  "email": "string",
  "password": "string"
}
```

**Refresh Token:** **POST** /refresh-token

```js
{
  "refreshToken": "string"
}
```

## Category

**Get All:** **GET** /api/categories

**Paging:** **GET** /api/categories?page=3&per_page=2&keyword=do

**Create:** **POST** /api/categories
**Edit:** **PUT** /api/categories/1

```js
{
  "id": 0,
  "thumbnail": "string",
  "name": "string",
  "description": "string"
}
```

**Delete:** **DELETE** /api/categories/1