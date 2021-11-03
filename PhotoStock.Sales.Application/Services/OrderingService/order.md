// 1. Utworzenie zamówienia
POST /Order/
{
  "orderId":"{uuid}"  
}

Response
location /Order/{orderId}/
Body - {orderId}

// 2. Pobranie listy zdjęć
Get /PictureCatalog
Response
{ 
  "Pictures":[
      Picture{
        "id" : "{uuid}",
        ....
      }
 }}

// 2. pobranie zawartości zamówienia
GET /Order/{OrderId}
{
  Items:[{
    OrderItem{
      "pictureId":"{uuid}",
      "quantity":"1"
    }
  }]
}

//3. Dodanie / usunięcie zdjęcia
POST /Order/{id}/Pictures
{  
  "pictureId":"{pictureId_from_catalog}"
}
Response 201 Created
location /Order/{id}/Items/{pictureId}

//4. Pobranie oferty do zamówienia   
GET /Order/{orderId}/Offer/
{
  Offer:[{
    Picture{
      id:"uuid",
      quantity:"1",
      price:"123123",
      currency:"PLN"
    }
  }]

}

//5. Zatwierdzenie oferty
POST /Order/{orderId}/Confirmation/
{
  Offer:[{
    Picture{
      id:"uuid",
      quantity:"1",
      price:"123123",
      currency:"PLN"
    }
  }]
}

    