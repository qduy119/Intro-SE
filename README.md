# Intro-SE

## [Upload Assets Documentation](https://cloudinary.com/documentation/upload_images#example_1_upload_multiple_files_using_a_form_unsigned)

## Authentication

**Register:** **POST** /register

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

**Login:** **POST** /authenticate

**Request**
```js
{
  "email": "string",
  "password": "string"
}
```

**Logout:** **POST** /logout

**Refresh Token:** **POST** /refresh-token

**Request**
```js
{
  "refreshToken": "string"
}
```

**Lưu trong cookie refresh_token**

**Gọi khi gặp 401 -> nếu vẫn trả về 401 -> Login lại**

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

**Request**
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
      "images": null,
      "categoryId": null
    },
  ]
}
```


**Get Item by Id:** **GET** /api/items/3

```js
{
  "id": 3,
  "thumbnail": "https://picsum.photos/640/480/?image=5",
  "name": "Sit commodi voluptatem.",
  "description": "Quis ut in odit voluptatem necessitatibus qui laudantium velit necessitatibus labore maxime voluptatibus eum in e",
  "price": 10.73,
  "discount": 10.88,
  "stock": 1,
  "images": null,
  "categoryId": null
}
```

**Create:** **POST** /api/items

**Edit:** **PUT** /api/items/1

**Request**
```js
{
  "id": 1, // chỉ cho Edit
  "thumbnail": "string",
  "name": "string",
  "description": "string",
  "price": 0,
  "discount": 0,
  "stock": 0,
  "images": "string",
  "categoryId": 1
}
```

**Delete:** **DELETE** /api/items/1

