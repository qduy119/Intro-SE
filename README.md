# Intro-SE

## [Upload Assets Documentation](https://cloudinary.com/documentation/upload_images#example_1_upload_multiple_files_using_a_form_unsigned)

## Authentication

**Register:** **POST** /register

**Login:** **POST** /authenticate

```js
{
  "email": "string",
  "password": "string"
}
```


**Request**
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

**Response**
```js
{
    "access_token": "ndFEk",
    "refresh_token": "Wlt",
    "access_token_expirydate": "2023-12-07T17:54:43.9672826Z",
    "refresh_token_expirydate": "2023-12-07T21:53:43.9945353Z"
}
```

**Refresh Token:** **POST** /refresh-token

**Request**
```js
{
  "refreshToken": "string"
}
```

**Response**
```js
{
    "access_token": "ndFEk",
    "refresh_token": "Wlt",
    "access_token_expirydate": "2023-12-07T17:54:43.9672826Z",
    "refresh_token_expirydate": "2023-12-07T21:53:43.9945353Z"
}
```

## Category

**Get All:** **GET** /api/categories

**Paging:** **GET** /api/categories?page=3&per_page=2&keyword=do

**Resonpse**
```js
{
  "page": 1,
  "per_page": 13,
  "total": 13,
  "total_pages": 1,
  "data": [
    {
      "id": 2,
      "thumbnail": "string",
      "name": "string",
      "description": "string"
    },
  ]
}
```



**Create:** **POST** /api/categories

**Edit:** **PUT** /api/categories/1

```js
{
  "id": 1, // chỉ cho edit
  "thumbnail": "string",
  "name": "string",
  "description": "string"
}
```

**Delete:** **DELETE** /api/categories/1

## Product/Item

**Get All:** **GET** /api/items

**Paging:** **GET** /api/items?page=3&per_page=2&keyword=do

**Resonpse**
```js
{
  "page": 1,
  "per_page": 100,
  "total": 100,
  "total_pages": 1,
  "data": [
    {
      "id": 1,
      "thumbnail": "https://picsum.photos/640/480/?image=233",
      "name": "Autem commodi qui.",
      "description": "Voluptatem quidem hic provident voluptate et occaecati aperiam placeat sapiente a quas aut non quae voluptas",
      "price": 10.27,
      "discount": 10.12,
      "stock": 4,
      "images": null
    },
  ]
}
```


**Create:** **POST** /api/items

**Edit:** **PUT** /api/items/1

```js
{
  "id": 1, // chỉ cho Edit
  "thumbnail": "string",
  "name": "string",
  "description": "string",
  "price": 0,
  "discount": 0,
  "stock": 0,
  "images": "string"
}
```

**Delete:** **DELETE** /api/items/1

