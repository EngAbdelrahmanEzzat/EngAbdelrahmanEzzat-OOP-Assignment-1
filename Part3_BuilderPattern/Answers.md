# Tasks 3.1 and 3.3 - Answers

## Task 3.1
1. Why is a single 20-parameter constructor a problem?
A constructor with 20 parameter make it hard to to manage this ,hard to maintain
The can easy make mistake as you might put the parameter int the place of another 
parameter.also if you added new parameter you must put it in the constructor 
and it is hard to manage and easy to full.

2. Is this purely a "constructor is too long" problem?
No. There is a deeper design problem. The class contains several different concepts that are only loosely related, such as billing address, shipping address, and order,payment information.
Putting all these responsibilities into one class makes the class harder to understand, validate, maintain, and reuse


## Task 3.3
1. why is this composed version better than the single big builder from Task 3.2?

The composed version follows the Single Responsibility Principle more closely. AddressBuilder is responsible only for constructing and validating an address, while OrderBuilder is responsible only for order and payment information.

AddressBuilder can independently validate that an address contains all required information, so the parent object does not need to know the rules for street, city, ZIP code, or country.

The same AddressBuilder can be reused for both the billing and shipping addresses. Without it, the address-building logic would have to be duplicated for each address.

the call site becomes easier to read because the construction is divided into meaningful groups. Instead of passing or setting around twenty unrelated properties in one place, the caller can clearly see which values belong to the billing address, shipping address, and order information.