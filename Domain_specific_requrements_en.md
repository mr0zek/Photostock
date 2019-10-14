# PhotoStock 

### Specific requirements
Specific requirements (buyer side)
The scope of works will regard handling orders of the buying party 
The buyer will have the possibility of preliminary booking of photos

#### 1.
Customers can add photos from the catalogue to their order. Adding the same photo to the order many times does not make sense. 
The system also makes it impossible for one user to buy the same photo a few times (different orders).

#### 2.
Customers can edit their order before they finally submit it. 
The order is not biding until it is submitted. Practically, it is treated as preliminary booking. 

Prices may change in the course of completing an order. The rule is that a customer always reserves products at (the current catalog prices) prices currently biding in the catalogue (and not at the prices he has seen), however, he also has to see the prices that will apply.

Before confirming the order customers have to see the current offer applying to their order proposed by the system. The offer should present products with their current prices (in the future together with current special offers).

It may happen that a given piece of art is not available any more (e.g. because it was deleted from the catalogue). For sure, customers should be able to see such a product, however, as an inactive one. 

The offer is not biding. Customers can confirm or reject such an offer. By confirming the offer customers officially make a purchase. If the currently biding offer is different from the one that the customer has seen, purchase cannot be realized and the customer should see a new offer.

#### 3.
When the customer confirms the order (offer), the system does not allow the purchase to proceed if the customer does not have enough money (the account is topped up in a prepaid form by an external system).

#### 4.
The system should store digitally signed history of the customer's purchases (what, when and for how much) to be used as evidence in potential legal proceedings or court case. For each purchase a fact of purchase should be generated. It should contain prices from the offer and is not subject to any change even when catalogue prices and discounts change. 

#### 5.
As the purchase is under way it is verified if the customer has enough means (credit). If not, he cannot finalize the purchase unless he is a VIP customer. In that case he will be given credit unless he has exceeded credit limit. If the customer has enough means (according to the above rules), he is charged and the fact of payment is registered.


